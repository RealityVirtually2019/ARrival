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
    public AudioClip Happy, Angry, idle;
    public AudioClip[] message;
    public int[] GesturePoint = new int[5]
        ;
    public float critePoint;
    public AudioSource ads;
    public float FollowRange;

    int reactScore=0;
    public int PlayScore=0;
    public bool[] GestureSign = new bool[8];


 
	void Start () {
        AlienAni = this.GetComponent<Animator>();
        ads.loop = true;
    }


    IEnumerator DelaySaying(int s){
        yield return new WaitForSeconds(Random.Range(3,s));
        Shoot((int)Random.Range(0,5));
        yield return new WaitForSeconds(5f);
        Say = false;
    }


    void PlaySound(){
        if (AlienAni.GetCurrentAnimatorStateInfo(0).IsName("idle") || AlienAni.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            ads.clip = idle;
                   
            // Do stuf !!
        }


        if (AlienAni.GetCurrentAnimatorStateInfo(0).IsName("Anger"))
        {
            ads.clip = Angry;
            // Do stuf !!
        }


        if (AlienAni.GetCurrentAnimatorStateInfo(0).IsName("Happy"))
        {

            ads.clip = Happy;
            // Do stuf !!
        }



    }





    public void Shoot(int g){
        AlienAni.SetInteger("Gesture",g);
        AlienAni.SetBool("Shoot",true);
        reactScore = GesturePoint[g];
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

    public void RadomRespons(){
        if (!Say)
        {

            Say = true;
            StartCoroutine(DelaySaying(4));



        }



    }



    public void RandomSaying(){

        if (!Say)
        {

            Say = true;


            StartCoroutine(DelaySaying(15));




        }
    }









    bool waitreset;

    public void sendOutMsg(){
        if(!waitreset){
            waitreset=true;
            StartCoroutine(delayRestShot());


        }
        GameObject o= Instantiate(orbit,shootPoint.position,Quaternion.identity) as GameObject;
        Msgorbit m= o.GetComponent<Msgorbit>();
        m.SendOutFromAlien = true;
        m.SendOutmsg(player.transform);

    }





    IEnumerator delayRestShot(){
        yield return new WaitForSeconds(3);
        AlienAni.SetBool("Shoot", false);
        waitreset = false;

    }

    public void changetoOutside(){

        transform.SetParent(parentOutside);

        transform.LookAt(new Vector3(mainPlayer.position.x,this.transform.position.y,mainPlayer.position.z));
    }


	
	// Update is called once per frame
	void Update () {

        FollowPlayer();

        PlaySound();
        //if(Vector3.Distance())

	}


    public void doReaction(int score){

        reactScore += score;


        if(reactScore>2)
        AlienAni.SetTrigger("Happy");
        else 
            AlienAni.SetTrigger("Anger");


        reactScore = 0;

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
