using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ManualGun : MonoBehaviour
{
    [SerializeField] private ArmaSO myData;

    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, myData.attackDistance))
            {
                Debug.Log(hitInfo.transform.name);
            }
        }
    }
}
