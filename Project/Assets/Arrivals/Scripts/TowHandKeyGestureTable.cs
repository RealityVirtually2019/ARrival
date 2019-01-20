using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowHandKeyGestureTable : MonoBehaviour {
    public bool[] rightHandTable;
    public bool[] leftHandTable;
    public bool[] HandsGesture;
    public GameObject Right, Left;
    public bool isSending;
    public Player player;
    public int[] Scores = new int[8]; 

    KeyGestureControl[] RightHandGestures;
    KeyGestureControl[] LeftHandGestures;
    public int point;

	// Use this for initialization
	void Start () {
     
        RightHandGestures = Right.GetComponents<KeyGestureControl>();
        LeftHandGestures = Left.GetComponents<KeyGestureControl>();
        rightHandTable = new bool[RightHandGestures.Length];
        leftHandTable = new bool[LeftHandGestures.Length];

        HandsGesture = new bool[RightHandGestures.Length];
	}


    public void Sending(){
        if(!isSending){
            isSending = true;

            StartCoroutine(delaySending());



        }


    }
    IEnumerator delaySending(){
        yield return new WaitForSeconds(0.5f);
        isSending = false;
        player.updateHandTable(HandsGesture);
        bool toShoot=false;

        point = 0;


        for (int i = 0; i < HandsGesture.Length;i++){

            if (HandsGesture[i])
            {
                toShoot = true;
                point += Scores[i];
            }



        }

        if(toShoot) player.Shoot(point);

    }





	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < LeftHandGestures.Length;i++){

            rightHandTable[i] = RightHandGestures[i].isOk;
            leftHandTable[i] = LeftHandGestures[i].isOk;

            HandsGesture[i] = rightHandTable[i] || leftHandTable[i];

        }

		
	}
}
