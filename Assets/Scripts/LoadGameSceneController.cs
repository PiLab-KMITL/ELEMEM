using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameSceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
	

}
