using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowHandKeyGestureTable : MonoBehaviour {
    public bool[] rightHandTable;

    public bool[] leftHandTable;
    public GameObject Right, Left;

     KeyGestureControl[] RightHandGestures;
     KeyGestureControl[] LeftHandGestures;


	// Use this for initialization
	void Start () {
        RightHandGestures = Right.GetComponents<KeyGestureControl>();
        LeftHandGestures = Left.GetComponents<KeyGestureControl>();
        rightHandTable = new bool[RightHandGestures.Length];
        leftHandTable = new bool[LeftHandGestures.Length];


	}
	
	// Update is called once per frame
	void Update () {


        for (int i = 0; i < LeftHandGestures.Length;i++){

            rightHandTable[i] = RightHandGestures[i].isOk;
            leftHandTable[i] = LeftHandGestures[i].isOk;
        }

		
	}
}
