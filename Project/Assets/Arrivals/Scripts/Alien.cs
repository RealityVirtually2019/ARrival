using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Alien : MonoBehaviour {
    public Animator AlienAni;
    public Transform parentOutside;
    public Transform mainPlayer;
    public Transform shootPoint;
    public GameObject orbit;
    public Player player;

    public float FollowRange;



    public bool[] GestureSign = new bool[8];






  //  public MLHandKeyPose _HandKeyPose;
    //public SpriteRenderer[] allHints;
	// Use this for initialization????'[''
	void Start () {
        AlienAni = this.GetComponent<Animator>();

       // StartCoroutine(DelayTesting());
        //MLHandKeyPose.Thumb



    }


    IEnumerator DelaySaying(){
        yield return new WaitForSeconds(Random.Range(3,15));
        Shoot((int)Random.Range(0,4));
        yield return new WaitForSeconds(5f);
        Say = false;
    }




    public void Shoot(int g){
        AlienAni.SetInteger("Gesture",g);
        AlienAni.SetBool("Shoot",true);

    }



    public void FollowPlayer(){

        transform.LookAt(new Vector3(mainPlayer.position.x, this.transform.position.y, mainPlayer.position.z));

        if(Vector3.Distance(transform.position,player.transform.position)>FollowRange)
        {
            transform.Translate(new Vector3(0,0,0.005f));

            AlienAni.SetBool("Walk",true);

        }else{

            AlienAni.SetBool("Walk", false);
            RandomSaying();

        }





    }
    bool Say=false;


    public void RandomSaying(){

        if (!Say)
        {

            Say = true;


            StartCoroutine(DelaySaying());




        }
    }











    public void sendOutMsg(){
        AlienAni.SetBool("Shoot", false);
        GameObject o= Instantiate(orbit,shootPoint.position,Quaternion.identity) as GameObject;
        Msgorbit m= o.GetComponent<Msgorbit>();
        m.SendOutFromAlien = true;
        m.SendOutmsg(player.transform);

    }



    public void changetoOutside(){

        transform.SetParent(parentOutside);

        transform.LookAt(new Vector3(mainPlayer.position.x,this.transform.position.y,mainPlayer.position.z));
    }


	
	// Update is called once per frame
	void Update () {

        FollowPlayer();
        //if(Vector3.Distance())

	}


    public void doReaction(){
        AlienAni.SetTrigger("Happy");



    }





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
