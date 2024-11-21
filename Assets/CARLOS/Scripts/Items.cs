using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private GameObject canvasPanel;
    [SerializeField] private GameObject itemModel;
    [SerializeField] private Transform inpeccionPunto;
    [SerializeField] float rangoItem;
     private bool estaEnRango = false;
     private bool estaInspeccionando = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (estaEnRango && !estaInspeccionando && Input.GetKeyDown(KeyCode.E))
        {
            ComenzarInspeccion();
        }
        else if (estaEnRango && Input.GetKeyDown(KeyCode.Escape))
        {
            TerminarInspeccion();
        }
    }

    private void ComenzarInspeccion()
    {
        estaInspeccionando = true;
        canvasPanel.SetActive(true);

        // Activa el modelo y posiciónalo correctamente para la inspección
        itemModel.SetActive(true);
        itemModel.transform.position = inpeccionPunto.position;
        itemModel.transform.rotation = Quaternion.identity; // Ajusta la rotación si es necesario

        // Asegúrate de que la cámara de inspección esté activa
        Camera inspectionCamera = GameObject.Find("Inspection Camera").GetComponent<Camera>();
        if (inspectionCamera != null)
        {
            inspectionCamera.enabled = true;
        }
    }
    private void TerminarInspeccion()
    {
        Camera inspectionCamera = GameObject.Find("Inspection Camera").GetComponent<Camera>();
        if (inspectionCamera != null)
        {
            inspectionCamera.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            estaEnRango = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            estaEnRango = false;
        }
    }
}
