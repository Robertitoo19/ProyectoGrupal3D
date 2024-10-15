using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCardiograma : MonoBehaviour
{
    public Animator cardiogramaAnimator;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            cardiogramaAnimator.SetBool("CardiogramToPlayer", true);
            cardiogramaAnimator.SetBool("CardiogramToSide",false);

        }
        else 
        {
            cardiogramaAnimator.SetBool("CardiogramToPlayer", false);
            cardiogramaAnimator.SetBool("CardiogramToSide", true);
        }
        if(!Input.GetKey(KeyCode.Q) && cardiogramaAnimator.GetBool("CardiogramToSide") == false)
        {
            cardiogramaAnimator.SetBool("CardiogramToPlayer", false);
            cardiogramaAnimator.SetBool("CardiogramToSide", false);
        }
    }
}
