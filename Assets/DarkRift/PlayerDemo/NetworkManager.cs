﻿using UnityEngine;
using System.Collections;

//Access the DarkRift namespace
using DarkRift;

public class NetworkManager : MonoBehaviour {

	//The server IP to connect to.
	public string serverIP = "127.0.0.1";

	//The player that we will instantiate when someone joins.
	public GameObject playerObject;

	//A reference to our player
	Transform player;

	void Start(){
		//Connect to the DarkRift Server using the Ip specified (will hang until connected or timeout)
		DarkRiftAPI.Connect(serverIP);

		//Setup a reciever so we can create players when told to.
		DarkRiftAPI.onDataDetailed += RecieveData;

		//Tell others that we've entered the game and to instantiate a player object for us.
		if( DarkRiftAPI.isConnected ){
			//Get everyone else to tell us to spawn them a player (this doesnt need the data field so just put whatever)
			DarkRiftAPI.SendMessageToOthers(TagIndex.Controller, TagIndex.ControllerSubjects.JoinMessage, "hi");
			//Then tell them to spawn us a player! (this time the data is the spawn position)
			DarkRiftAPI.SendMessageToAll(TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, new Vector3(0f,0f,0f));
		}
	}

	void OnApplicationQuit(){
		//You will want this here otherwise the server wont notice until someone else sends data to this
		//client.
		DarkRiftAPI.Disconnect();
	}

	void RecieveData(ushort senderID, byte tag, ushort subject, object data){
		//When any data is recieved it will be passed here, 
		//we then need to process it if it's got a tag of 0 and, if 
		//so, create an object. This is where you'd handle most adminy 
		//stuff like that.

		//Ok, if data has a Controller tag then it's for us
		if( tag == TagIndex.Controller ){

			//If a player has joined tell them to give us a player
			if( subject == TagIndex.ControllerSubjects.JoinMessage ){
				//Basically reply to them.
				DarkRiftAPI.SendMessageToID(senderID, TagIndex.Controller, TagIndex.ControllerSubjects.SpawnPlayer, player.position);
			}
			//Then if it has a spawn subject we need to spawn a player
			if( subject == TagIndex.ControllerSubjects.SpawnPlayer ){
				//Instantiate the player
				GameObject clone = (GameObject)Instantiate(playerObject, (Vector3)data, Quaternion.identity);

				//Tell the network player who owns it so it tunes into the right updates.
				clone.GetComponent<NetworkPlayer>().networkID = senderID;
				//If it's our player being created allow control and set the reference
				if( senderID == DarkRiftAPI.id ){
					clone.GetComponent<CharacterControllerAndroid>().isControllable = true;
					clone.GetComponentInChildren<OpenDiveSensor>().cameraleft.enabled = true;
					clone.GetComponentInChildren<OpenDiveSensor>().cameraright.enabled = true;
					player = clone.transform;
				}
			}
		}
	}
}
