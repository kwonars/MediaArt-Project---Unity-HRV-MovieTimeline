using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterflyAdjustment : MonoBehaviour
{
    [HideInInspector]
    DateTime initialTime;
    TimeSpan elapsedTime;

    long frostEndDelay = 40000000;
    TimeSpan frostEndDelayTimeSpan;

    List<TimeSpan> allStartTime = new List<TimeSpan>();
    List<TimeSpan> allBfShowLength = new List<TimeSpan>();
    List<List<TimeSpan>> allTimeData = new List<List<TimeSpan>>();
    List<ParticleSystem> allParticleSystem = new List<ParticleSystem>();
    List<Animator> allAnimators = new List<Animator>();
    List<bool> initialPlay = new List<bool>();
    int numberOfChildren;
    
    
    // Start is called before the first frame update
    void Start()
    {
        initialTime = DateTime.Now;
        numberOfChildren = transform.childCount;
        // Debug.Log(numberOfChildren);

        
        frostEndDelayTimeSpan = new TimeSpan(frostEndDelay);

        for (int i = 0; i < numberOfChildren; i++)
        {
            allTimeData.Add(transform.GetChild(i).gameObject.GetComponent<butterflyTimeSet>().getTimeData());
            allStartTime.Add(allTimeData[i][0]);
            allBfShowLength.Add(allTimeData[i][1]);
            allParticleSystem.Add(transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>());
            
            transform.GetChild(i).gameObject.SetActive(false);
            initialPlay.Add(true);

            if(transform.GetChild(i).gameObject.GetComponent<Animator>() != null) // if Animator exist in Butterfly object
            {
                allAnimators.Add(transform.GetChild(i).gameObject.GetComponent<Animator>());
                // Debug.Log(i);
            }
            else
            {
                allAnimators.Add(null); // assign null to prevent index error
                // Debug.Log(i);
            }
            // Debug.Log(i);
            // Debug.Log(allStartTime[i]);
            // Debug.Log(allBfShowLength[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = DateTime.Now - initialTime;
        for (int i = 0; i < numberOfChildren; ++i)
        {
            if (elapsedTime > allStartTime[i] && elapsedTime <= allStartTime[i] + allBfShowLength[i])
            {
                transform.GetChild(i).gameObject.SetActive(true);
                // if(initialPlay[i]) // once played
                // {
                //     initialPlay[i] = false;
                //     if(allAnimators[i] != null) // if animator exists in butterfly object
                //     {
                //         allAnimators[i].Play("LaLaLa", 0, 0f);
                //     }
                // }
            }
            else if (elapsedTime > allStartTime[i] + allBfShowLength[i] + frostEndDelayTimeSpan)
            {
                // Debug.Log(allBfShowLength[i]);
                transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false); // butterflyEffect Off
                transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false); // frostEffect Off
            }
            else if (elapsedTime > allStartTime[i] + allBfShowLength[i])
            {
                transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(false); // butterflyEffect Off
                allParticleSystem[i].startLifetime = 0f; // frostEffect Off
            }
        }
    }
}
