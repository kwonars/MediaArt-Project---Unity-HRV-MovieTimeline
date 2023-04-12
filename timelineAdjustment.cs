using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For parent Actors object
public class timelineAdjustment : MonoBehaviour
{
    [HideInInspector]
    DateTime initialTime;
    TimeSpan elapsedTime;
    List<TimeSpan> allStartTime = new List<TimeSpan>();
    List<TimeSpan> allMovieLength = new List<TimeSpan>();
    List<List<TimeSpan>> allTimeData = new List<List<TimeSpan>>();
    List<bool> initialPlay = new List<bool>();
    int numberOfChildren;
    
    
    // Start is called before the first frame update
    void Start()
    {
        initialTime = DateTime.Now;
        numberOfChildren = transform.childCount;
        // Debug.Log(numberOfChildren);

        for (int i = 0; i < numberOfChildren; i++)
        {
            allTimeData.Add(transform.GetChild(i).gameObject.GetComponent<timeSet>().getTimeData());
            allStartTime.Add(allTimeData[i][0]);
            allMovieLength.Add(allTimeData[i][1]);
            
            transform.GetChild(i).gameObject.SetActive(false);
            initialPlay.Add(true);
            // Debug.Log(i);
            // Debug.Log(allStartTime[i]);
            // Debug.Log(allMovieLength[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = DateTime.Now - initialTime;
        for (int i = 0; i < numberOfChildren; ++i)
        {
            if (elapsedTime > allStartTime[i] && elapsedTime <= allStartTime[i] + allMovieLength[i])
            {
                transform.GetChild(i).gameObject.SetActive(true);
                if(initialPlay[i])
                {
                    transform.GetChild(i).gameObject.GetComponent<HVR.HvrActor>().timestampProvider.Play();
                    initialPlay[i] = false;
                }
            }
            else if (elapsedTime > allStartTime[i] + allMovieLength[i])
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
