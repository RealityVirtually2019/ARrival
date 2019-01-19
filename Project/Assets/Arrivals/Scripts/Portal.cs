using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Portal : MonoBehaviour {
    public Transform parentOutside;
    public Transform mainPlayer;
    PlayableDirector playableDirector;
	// Use this for initialization
	void Start () {
        playableDirector=GetComponent<PlayableDirector>();
	}
	


    public void changetoOutside()
    {
        playableDirector.Play();
        transform.SetParent(parentOutside);
        transform.LookAt(new Vector3(mainPlayer.position.x, this.transform.position.y, mainPlayer.position.z));
    }


	// Update is called once per frame
	void Update () {
    //    transform.Rotate(new Vector3(0,0,0.3f));
	}
}
