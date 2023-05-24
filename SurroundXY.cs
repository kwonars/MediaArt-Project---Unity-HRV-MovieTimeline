using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundXY : MonoBehaviour
{
    [HideInInspector]
    GameObject cam;
    Camera camComponent;
    float reducingParameter;
    Vector3 speakerPosition;
    Vector3 currentHMDPosition;
    Vector3 currentHMDForward;
    Vector3 toSpeaker;

    Vector2 speakerPositionXY;
    Vector2 currentHMDPositionXY;
    Vector2 currentHMDForwardXY;
    Vector2 toSpeakerXY;

    AudioSource leftNarration;
    AudioSource rightNarration;

    float angleDifference;
    float soundCoefficient_Left;
    float soundCoefficient_Right;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("XRRig/Camera Offset/Camera");
        // camComponent = cam.GetComponent<Camera>();
        reducingParameter = 4.2f;
        speakerPosition = new Vector3(0f, 1.5f, -1f);
        speakerPositionXY = new Vector2(0f, -1f);

        leftNarration = transform.GetChild(0).gameObject.GetComponent<AudioSource>(); // Left narration
        rightNarration = transform.GetChild(1).gameObject.GetComponent<AudioSource>(); // Right narration
    }

    // Update is called once per frame
    void Update()
    {
        currentHMDPosition = cam.transform.localPosition;
        currentHMDPositionXY.x = cam.transform.localPosition.x;
        currentHMDPositionXY.y = cam.transform.localPosition.z;

        currentHMDForward = cam.transform.forward;
        currentHMDForwardXY.x = cam.transform.forward.x;
        currentHMDForwardXY.y = cam.transform.forward.z;

        toSpeaker = speakerPosition - currentHMDPosition;
        toSpeakerXY.x = toSpeaker.x;
        toSpeakerXY.y = toSpeaker.z;

        angleDifference = Vector2.SignedAngle(toSpeakerXY, currentHMDForwardXY);

        soundCoefficient_Left = -0.1f*reducingParameter*Mathf.Sin(Mathf.Deg2Rad*(angleDifference)) + (1f-0.1f*reducingParameter);
        soundCoefficient_Right = 0.1f*reducingParameter*Mathf.Sin(Mathf.Deg2Rad*(angleDifference)) + (1f-0.1f*reducingParameter);

        leftNarration.volume = soundCoefficient_Left;
        rightNarration.volume = soundCoefficient_Right;

        // Debug.Log(leftNarration.volume);
    }

//     public static float CalculateAngle(Vector3 from, Vector3 to)
//     {    
//         return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
//     }
}
