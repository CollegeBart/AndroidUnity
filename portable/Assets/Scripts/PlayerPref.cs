using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour {

    ActionButton ab;
    
    bool isPaused = false;
    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
        PlayerPrefs.GetFloat("TimeSpend", ab.hours);
        PlayerPrefs.Save();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.GetFloat("TimeSpend", ab.hours);
        PlayerPrefs.Save();
    }
}
