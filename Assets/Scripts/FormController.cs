using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormController : MonoBehaviour {

    public Animator animatorFormNext;
    public Animator animatorFormOver;
    public PlayerController playerCtrl;

    public void OnNextLevel()
    {
        animatorFormNext.SetBool("showForm", true);
        playerCtrl.GotoToNextLevel();

    }

    public void OnNextClose()
    {
        animatorFormNext.SetBool("showForm", false);
    }
    public void OnOverClose()
    {
        animatorFormOver.SetBool("showForm", false);
        playerCtrl.Reset();
    }


    public void OnGameOver()
    {
        animatorFormOver.SetBool("showForm", true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
