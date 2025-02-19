using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCardiograma : MonoBehaviour
{
    [SerializeField]public Animator cardiogramaAnimator;

    public bool cardiogramaActivo { get; private set; } = false;


    // Update is called once per frame
    void Update()
    {
        animacionCardiograma();
    }

    private void animacionCardiograma()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            cardiogramaAnimator.SetBool("BrazoToPlayer", true);
            cardiogramaAnimator.SetBool("BrazoToSide", false);
            cardiogramaActivo = true;
        }
        else
        {
            cardiogramaAnimator.SetBool("BrazoToPlayer", false);
            cardiogramaAnimator.SetBool("BrazoToSide", true);
            cardiogramaActivo = false;
        }
        if (!Input.GetKey(KeyCode.Q) && cardiogramaAnimator.GetBool("BrazoToSide") == false)
        {
            cardiogramaAnimator.SetBool("BrazoToPlayer", false);
            cardiogramaAnimator.SetBool("BrazoToSide", false);
        }
        //toca revisar el error de sistema cardioframa no tiene funcionm especifica
    }

}
