using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CambiarColor : MonoBehaviour
{
    [SerializeField] Player player;
    //private ParticleSystem.MainModule system;
    // Start is called before the first frame update
    /*void Start()
    {
        system = GetComponentInChildren<ParticleSystem>().main;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            system.startColor = Color.red;
        }
    }*/

    [SerializeField]public GameObject cardiogramaVerde;
    [SerializeField]public GameObject cardiogramaNaranja;
    [SerializeField]public GameObject cardiogramaRojo;

     void Start()
    {
        
    }
    void ChecarVidaPlayer()
    {
        if (player.VidaPlayer > 50 )
        {

        }
    }
}
