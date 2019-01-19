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
    public bool[] GestureSign = new bool[8];






  //  public MLHandKeyPose _HandKeyPose;
    //public SpriteRenderer[] allHints;
	// Use this for initialization
	void Start () {
        AlienAni = this.GetComponent<Animator>();

        StartCoroutine(DelayTesting());
        //MLHandKeyPose.Thumb



    }


    IEnumerator DelayTesting(){
        yield return new WaitForSeconds(3);
        Shoot(0);


    }




    public void Shoot(int g){
        AlienAni.SetInteger("Gesture",g);
        AlienAni.SetBool("Shoot",true);

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
     
        transform.LookAt(new Vector3(mainPlayer.position.x, this.transform.position.y, mainPlayer.position.z));


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
