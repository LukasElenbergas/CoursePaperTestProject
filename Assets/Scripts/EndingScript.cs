using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    private Component[] animators;

    void Start() 
    {
        animators = GetComponentsInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col){

        col.GetComponent<PlayerController>().Invoke("Won", 6f);
        
        Invoke("Enable", 0.3f);
    }

    //This is purely for the firework animator to be enabled on time so that fireworks would start at a proper time
    void Enable()
    {
        foreach(Animator anim in animators)
        {
            if(!anim.enabled)
                anim.enabled = true;
        }
    }
}
