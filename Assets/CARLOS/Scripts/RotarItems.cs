using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarItems : MonoBehaviour
{
    [SerializeField] private float velRotacion;
    private bool estaInspeccionando = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaInspeccionando)
        {
            transform.Rotate(Vector3.up, velRotacion * Time.deltaTime);
        }
        
    }
    
}
