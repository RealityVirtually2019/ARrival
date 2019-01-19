using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Alien : MonoBehaviour {
    public Animator AlienAni;
    public Transform parentOutside;
    public Transform mainPlayer;





  //  public MLHandKeyPose _HandKeyPose;
    //public SpriteRenderer[] allHints;
	// Use this for initialization
	void Start () {
        //AlienAni = this.GetComponent<Animator>();


        //MLHandKeyPose.Thumb



    }


    public void sendOutMsg(){




    }



    public void changetoOutside(){

        transform.SetParent(parentOutside);

        transform.LookAt(new Vector3(mainPlayer.position.x,this.transform.position.y,mainPlayer.position.z));
    }


	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
            controlGesture(1);
        if (Input.GetKey(KeyCode.Alpha2))
            controlGesture(2);
        if (Input.GetKey(KeyCode.Alpha3))
            controlGesture(3);




	}

    /*
    void setHint(int hindex ,bool onoff){
        if(onoff){
            allHints[hindex].color = new Color(1.0f, 0, 0);
        }else{
            allHints[hindex].color = new Color(0, 0, 0);
        }


    }*/





    void controlGesture(int s){

        AlienAni.SetInteger("Gesture",s);



    }

    public void C(){


        controlGesture(1);
    }



  


    public void OK()
    {

        controlGesture(2);

    }





    public void Thumb()
    {

        controlGesture(3);

    }





}
