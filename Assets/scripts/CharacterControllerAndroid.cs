using UnityEngine;
using System.Collections;


using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class CharacterControllerAndroid : MonoBehaviour {
	
	public float speed = 10.0f;
	public GameObject ammo;
	bool canFire;
	public float fireRate;
	public float rotSpeed = 20f;
	GameObject myo;
	public float turnThreshold = 1f;
	private Vector3 lastRot = Vector3.zero;
	ThalmicMyo thalmicMyo;
	public bool isControllable = false;
	Vector3 newEulerAngles = Vector3.zero;
	MessageManager messageManager;
	public GameObject firePoint;
	
	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;
	
	// Use this for initialization
	void Start () {
		GameObject messManager = GameObject.FindWithTag ("MessageManager");
		messageManager = messManager.GetComponent<MessageManager> ();
		myo = GameObject.FindWithTag ("Myo");
		thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		resetMyoOrientation ();
	}
	
	void Awake()
	{
		//		this.GetComponentInChildren<OpenDiveSensor>().cameraleft.enabled = false;
		//		this.GetComponentInChildren<OpenDiveSensor>().cameraright.enabled = false;
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		if (isControllable) {
			if (Time.time < 1)
				resetMyoOrientation ();
			
			//if (messageManager.GetMyoRotation() != Vector3.zero)
			//    newEulerAngles = messageManager.GetMyoRotation().eulerAngles;
			//else
			newEulerAngles = myo.transform.rotation.eulerAngles;
			
			if (newEulerAngles.x > 180)
				newEulerAngles.x = newEulerAngles.x - 360;
			if (newEulerAngles.y > 180)
				newEulerAngles.y = newEulerAngles.y - 360;
			if (newEulerAngles.z > 180)
				newEulerAngles.z = newEulerAngles.z - 360;
			newEulerAngles.x *= -1f;
			newEulerAngles.z *= -1f;
			newEulerAngles.y = 0f;
			
			transform.Rotate (new Vector3 (angleCheck (lastRot.x, newEulerAngles.x), angleCheck (lastRot.y, newEulerAngles.y),
			                               angleCheck (lastRot.z, newEulerAngles.z)) * Time.deltaTime * rotSpeed * 100);
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
			lastRot = transform.rotation.eulerAngles;
			
			PoseUpdate();
		}
	}
	
	void resetMyoOrientation()
	{
		myo.transform.rotation = Quaternion.Euler (0, 0, 0);
	}
	
	float angleCheck(float last, float cur)
	{
		if (Mathf.Abs (last - cur) >= turnThreshold)
			return cur;
		else
			return 0;
		
	}
	
	
	
	// Update is called once per frame.
	void PoseUpdate ()
	{
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.Fist) {
				fire ();
				thalmicMyo.Vibrate (VibrationType.Medium);
				
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
				
				// Change material when wave in, wave out or double tap poses are made.
			} else if (thalmicMyo.pose == Pose.WaveIn) {
				//renderer.material = waveInMaterial;
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.WaveOut) {
				//renderer.material = waveOutMaterial;
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} else if (thalmicMyo.pose == Pose.DoubleTap) {
				//renderer.material = doubleTapMaterial;
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}
		}
	}
	
	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;
		
		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}
		
		myo.NotifyUserAction ();
	}
	
	void fire(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit)) {
			if(hit.collider.gameObject.GetComponent<Health>())
				hit.collider.gameObject.GetComponent<Health>().hurt();
		}
		GameObject clone = (GameObject)Instantiate (ammo, transform.position, Quaternion.Euler(transform.eulerAngles));
		//		clone.transform.eulerAngles = ;
		//		clone.transform.localRotation = transform.localRotation;
		
	}
	
}
