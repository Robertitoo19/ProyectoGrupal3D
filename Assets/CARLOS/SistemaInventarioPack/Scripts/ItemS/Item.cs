using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemSO myData;

    [SerializeField]
    private int id;

    [SerializeField]
    private GameManagerSO gM;

    public ItemSO MyData { get => myData;}

    public void Obtain()
    {
        gM.Monedas++;
        Destroy(this.gameObject);

        gM.Items[id] = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        if(gM.Items.ContainsKey(id))
        {
            if (!gM.Items[id])
            {
                Destroy(gameObject);
            }
        }
        else
        {
            gM.Items.Add(id, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
