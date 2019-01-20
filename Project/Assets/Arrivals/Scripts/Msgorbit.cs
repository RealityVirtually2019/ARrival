using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Msgorbit : MonoBehaviour {
    Transform target=null;
    AudioSource audioSource;
    public AudioClip audioClip;
    public ParticleSystem particleSystem;
    public bool SendOutFromAlien;
    public int Point; 

    public void SendOutmsg(Transform t){

        target = t;
        //audioSource = GetComponent<AudioSource>();

        //audioSource.clip = audioClip;


    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            transform.LookAt(target);
            transform.Translate(new Vector3(0, 0, 0.01f));
        }
		
	}




private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag=="Alien"  && !SendOutFromAlien){




            collision.gameObject.GetComponent<Alien>().doReaction(Point);
            Destroy(this.gameObject);



        }
        if (collision.gameObject.tag == "Player" && SendOutFromAlien)
        {


            Destroy(this.gameObject);
        }
    
    
    
    }




}
