using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    [SerializeField] private float distanciaIteraccion;

    private Camera cam;
    private Transform InteractuableActual;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        DeteccionInteractuable();
    }

    private void DeteccionInteractuable()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, distanciaIteraccion))
        {
            
        }
    }
}
