using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource Sound;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private float vol = 0;
 
    
 
 
    private void Start ()
    {
        Sound = this.GetComponent<AudioSource>();
        vol = 0;
 
        fadeIn = true;
    }
 
 
    // Update is called once per frame
    void FixedUpdate()
    {
        Sound.volume = vol;

        if (fadeIn)
        {
            if (vol < 0.99)
            {
                vol = vol + 0.005f;
            }
            else
            {
                fadeIn = false;
                fadeOut = true;
            }
        }
         if (fadeOut)
        {
            if (vol > 0.05f)
            {
                vol = vol - 0.005f;
            }
            else
            {
                fadeIn = true;
                fadeOut = false;
            }
        }
    }
}
