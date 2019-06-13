using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScreen");
    }

    public void PreviousButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }

    public void NextButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial-2");
    }
}
