using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlugin : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        using (AndroidJavaClass aJC = new AndroidJavaClass("com.example.a1630077.tpfinal"))
        {
            int id = aJC.CallStatic<int>("GetExtraID");
            Debug.Log("Was launched with ID = " + id);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void NotificationMethod()
    {
        using (AndroidJavaClass aJC = new AndroidJavaClass("com.example.a1630077.tpfinal"))
        {
            aJC.CallStatic("ScheduleNotification", 10000L, "Come press me", 5997348);
        }
    }
}
