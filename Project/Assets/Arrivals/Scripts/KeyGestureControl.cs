using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
public class KeyGestureControl : MonoBehaviour {

    public string Functioncall;

    public  MLHandKeyPose _keyPoseToTrack;

    private bool _trackLeftHand = true;
    private bool _trackRightHand = true;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        float confidenceLeft = _trackLeftHand ? GetKeyPoseConfidence(MLHands.Left) : 0.0f;
        float confidenceRight = _trackRightHand ? GetKeyPoseConfidence(MLHands.Right) : 0.0f;
        float confidenceValue = Mathf.Max(confidenceLeft, confidenceRight);

     //   Color currentColor = Color.white;

        if (confidenceValue > 0.0f)
        {
            BroadcastMessage(Functioncall);
        }

    
    
    
    
    }


    private float GetKeyPoseConfidence(MLHand hand)
    {
        if (hand != null)
        {
            if (hand.KeyPose == _keyPoseToTrack)
            {
                return hand.KeyPoseConfidence;
            }
        }
        return 0.0f;
    }
}
