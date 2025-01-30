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
    [SerializeField] private float velocidadRotacion;


    [SerializeField]private enum Type { Objeto}

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
        else if (estaEnRango && Input.GetKeyDown(KeyCode.E))
        {
            TerminarInspeccion();
            Destroy(gameObject);
        }
    }

    private void ComenzarInspeccion()
    {
        estaInspeccionando = true;
        canvasPanel.SetActive(true);

        // Activa el modelo pero no cambies su posición
        itemModel.SetActive(true);
        itemModel.transform.rotation = Quaternion.identity; // Solo ajustar rotación si es necesario

        // Asegúrate de que la cámara de inspección esté activa
        Camera inspectionCamera = GameObject.Find("InspeccionCamara").GetComponent<Camera>();
        if (inspectionCamera != null)
        {
            inspectionCamera.enabled = true;
        }
    }
    private void TerminarInspeccion()
    {
        canvasPanel.SetActive(false);
        Camera inspectionCamera = GameObject.Find("InspeccionCamara").GetComponent<Camera>();
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
