using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterflyTimeSet : MonoBehaviour
{
    public string startTime;
    public string bfShowLength;
    public List<TimeSpan> timeData = new List<TimeSpan>();
    public TimeSpan startTimeTimeSpan;
    public TimeSpan bfShowLengthTimeSpan;

    // Start is called before the first frame update
    public List<TimeSpan> getTimeData()
    {        
        float.TryParse(startTime, out float startTimeFloat);
        long startTimeLong = Convert.ToInt64(startTimeFloat*10000000f);
        startTimeTimeSpan = new TimeSpan(startTimeLong);
        timeData.Add(startTimeTimeSpan);

        float.TryParse(bfShowLength, out float bfShowLengthFloat);
        long bfShowLengthLong = Convert.ToInt64(bfShowLengthFloat*10000000f);
        bfShowLengthTimeSpan = new TimeSpan(bfShowLengthLong);
        timeData.Add(bfShowLengthTimeSpan);
        
        // Debug.Log(timeData);
        return timeData;
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
