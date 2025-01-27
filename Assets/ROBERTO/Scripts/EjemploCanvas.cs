using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploCanvas : MonoBehaviour
{
    [SerializeField] private EventManagerSO eventManager;

    [SerializeField] private GameObject textoInteraccion;

    private void OnEnable()
    {
        eventManager.OnNewInteractuable += EncenderLetraE;
        eventManager.OnNoInteractuable += ApagarLetraE;
    }
    //modelo-vista-controlador. (MVC)
    private void ApagarLetraE()
    {
        textoInteraccion.SetActive(false);
    }

    private void EncenderLetraE()
    {
        textoInteraccion.SetActive(true);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
