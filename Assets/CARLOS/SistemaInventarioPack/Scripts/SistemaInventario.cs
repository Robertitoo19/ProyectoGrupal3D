using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInventario : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    [SerializeField]
    private GameObject inventoryUI;

    [SerializeField]
    private ItemSlot[] slots;

    [SerializeField]
    private ItemSlot[] usableSlots;

    private List<ItemSO> myItems = new List<ItemSO>();

    private int itemsCollected;
    private ItemInfo[] itemInfos;

    private static SistemaInventario instance;
    private void OnEnable()
    {
        gM.OnNewItem += AddNewItem;
    }

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Init()
    {
        itemInfos = new ItemInfo[slots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            itemInfos[i] = slots[i].GetComponentInChildren<ItemInfo>();
        }
    }

    private void AddNewItem(ItemSO itemData)
    {
        if(myItems.Contains(itemData)) //Si ya está en la lista...
        {
            int indexOfStackItem = myItems.FindIndex(x => x.Equals(itemData));
            itemInfos[indexOfStackItem].UpdateStackItem();
        }
        else //Si no está en la lista.... 
        {
            myItems.Add(itemData); //Lo añado.
            slots[itemsCollected].gameObject.SetActive(true); //Y activo el Slot correspondiente.
            itemInfos[itemsCollected].FeedData(itemData); //Y lo alimento con los datos pertinentes.
            itemsCollected++;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ItemInfo itemInfo = usableSlots[0].GetComponentInChildren<ItemInfo>();
            
            if(itemInfo != null)
            {
               itemInfo.UseItem();

            }
        }
    }
}
