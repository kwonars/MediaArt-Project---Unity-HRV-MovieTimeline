using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For child HrvActor object
public class timeSet : MonoBehaviour
{
    public string startTime;
    public string movieLength;
    public List<TimeSpan> timeData = new List<TimeSpan>();
    public TimeSpan startTimeTimeSpan;
    public TimeSpan movieLengthTimeSpan;

    // Start is called before the first frame update
    public List<TimeSpan> getTimeData()
    {        
        float.TryParse(startTime, out float startTimeFloat);
        long startTimeLong = Convert.ToInt64(startTimeFloat*10000000f);
        startTimeTimeSpan = new TimeSpan(startTimeLong);
        timeData.Add(startTimeTimeSpan);

        float.TryParse(movieLength, out float movieLengthFloat);
        long movieLengthLong = Convert.ToInt64(movieLengthFloat*10000000f);
        movieLengthTimeSpan = new TimeSpan(movieLengthLong);
        timeData.Add(movieLengthTimeSpan);
        
        // Debug.Log(timeData);
        return timeData;
    }
}
