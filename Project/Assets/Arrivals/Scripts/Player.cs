using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject Orbit;
    public Alien alien;
    public bool [] GTable;

    bool isending=false;





	// Use this for initialization
	void Start () {
		
	}

    public void Shoot(){
        if(!isending){
            isending = true;
            GameObject o = Instantiate(Orbit, transform.position, Quaternion.identity) as GameObject;
            Msgorbit b = o.GetComponent<Msgorbit>();
            b.SendOutmsg(alien.transform);
            StartCoroutine(reset());
        }
       
    }



    IEnumerator reset(){
        yield return new WaitForSeconds(5f);


        isending = false;



    }





    public void updateHandTable(bool[] Table){

        GTable = Table;


    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
