using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    private ParticleSystem.MainModule system;
    // Start is called before the first frame update
    void Start()
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
    }
}
