using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text itemNameText;

    [SerializeField]
    private TMP_Text itemCountText;


    private ItemSlot currentSlot;
    private int itemCount;
    private Canvas canvas;
    private CanvasGroup canvasGroup; //Componente necesario para dejar de detecar el raycasting para cuando hagamos el drop en el Slot.

    private RectTransform itemRectTransform;
    private Transform initParent;
    private Vector3 initPosition;

    private ItemSO itemData;



    public Transform InitParent { get => initParent; set => initParent = value; }
    public ItemSlot CurrentSlot { get => currentSlot; set => currentSlot = value; }
    public ItemSO ItemData { get => itemData; }

    private void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        itemRectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void UpdateStackItem()
    {
        itemCount ++;
        itemCountText.text = "x" + itemCount;
    }

    //Alimenta los datos del Item conseguido.
    public void FeedData(ItemSO itemData)
    {
        itemImage.sprite = itemData.icon;
        itemNameText.text = itemData.itemName;
        itemCount = 1;
        itemCountText.text = "x" + itemCount;

        this.itemData = itemData;
        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //Antes de arrastrar, obtenemos sus datos iniciales, por si al acabar el arrastre se deposita en una zona incorrecta.
        initParent = itemRectTransform.parent;
        initPosition = itemRectTransform.localPosition;

        itemRectTransform.SetParent(canvas.transform);
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //PARA MOVER EL OBJETO CON EL RATÓN
    {
        itemRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        //Droppeo fallido
        if(itemRectTransform.parent == canvas.transform)
        {
            itemRectTransform.SetParent(initParent);
            itemRectTransform.localPosition = initPosition;
        }
        else //Droppeo exitoso.
        {

        }
    }

    public void UseItem()
    {
        Debug.Log("Uso: ");
    }
}
