using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCardiograma : MonoBehaviour
{
    public Animator cardiogramaAnimator;


    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            cardiogramaAnimator.SetBool("BrazoToPlayer", true);
            cardiogramaAnimator.SetBool("BrazoToSide",false);

        }
        else 
        {
            cardiogramaAnimator.SetBool("BrazoToPlayer", false);
            cardiogramaAnimator.SetBool("BrazoToSide", true);
        }
        if(!Input.GetKey(KeyCode.Q) && cardiogramaAnimator.GetBool("BrazoToSide") == false)
        {
            cardiogramaAnimator.SetBool("BrazoToPlayer", false);
            cardiogramaAnimator.SetBool("BrazoToSide", false);
        }
        //toca revisar el error de sistema cardioframa no tiene funcionm especifica
    }

    
}
