using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puertas : MonoBehaviour, IInteractuableCarlos
{
    [SerializeField] private NavMeshAgent agent;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Interactuar()
    {

    }
}
