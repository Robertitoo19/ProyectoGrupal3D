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

     void Update()
    {
        ChecarVidaPlayer();
    }
    void ChecarVidaPlayer()
    {
        if (player.VidaPlayer > 50 )
        {
            cardiogramaVerde.SetActive(true);
            cardiogramaNaranja.SetActive(false);
            cardiogramaRojo.SetActive(false);
        }
        else if (player.VidaPlayer <= 50 && player.VidaPlayer >20 )
        {
            cardiogramaVerde.SetActive(false);
            cardiogramaNaranja.SetActive(true);
            cardiogramaRojo.SetActive(false);
        }
        else if(player.VidaPlayer <= 20)
        {
            cardiogramaVerde.SetActive(false);
            cardiogramaNaranja.SetActive(false);
            cardiogramaRojo.SetActive(true);
        }
    }
    public bool CardiogramaActivo()
    {
        return cardiogramaVerde.activeSelf || cardiogramaNaranja.activeSelf || cardiogramaRojo.activeSelf;
    }
}
