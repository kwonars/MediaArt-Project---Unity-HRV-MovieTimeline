using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCode : MonoBehaviour
{
    [HideInInspector]
    DateTime initialTime;
    TimeSpan elapsedTime;
    public TimeSpan startTimeTimeSpan;
    public TimeSpan movieLengthTimeSpan;

    // Start is called before the first frame update
    void Start()
    {
        initialTime = DateTime.Now;

        float.TryParse("255", out float startTimeFloat);
        long startTimeLong = Convert.ToInt64(startTimeFloat*10000000f);
        startTimeTimeSpan = new TimeSpan(startTimeLong);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = DateTime.Now - initialTime;

        if (elapsedTime > startTimeTimeSpan)
        {
            // Debug.Log(elapsedTime);
            QuitGame();
        }

    }

    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
