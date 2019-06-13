using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour {

    public Image cooldown;
    public float waitTime = 30.0f;

    // Update is called once per frame
    void Update()
    {

            //Reduce fill amount over 30 seconds
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;

    }

}

