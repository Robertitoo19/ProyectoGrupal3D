using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    [SerializeField]
    private RectTransform itemBackground;


    private ItemInfo currentItemInfo;

    public ItemInfo CurrentItemInfo { get => currentItemInfo; set => currentItemInfo = value; }

    private void Awake()
    {
        currentItemInfo = GetComponentInChildren<ItemInfo>();
    }


    //Para droppear datos nuevos en este slot.
    public virtual void OnDrop(PointerEventData eventData)
    {
        Transform itemDroppedTransform = eventData.pointerDrag.transform;
        ItemInfo newItemInfo = eventData.pointerDrag.GetComponent<ItemInfo>();

        if (itemBackground.childCount > 0) //Si hay datos en este slot...primero lleva los actuales al otro.
        {
            currentItemInfo.transform.SetParent(newItemInfo.InitParent);
            currentItemInfo.transform.localPosition = Vector3.zero; //Le pongo en la misma posición.

            //Actualizar al slot destino (newItemInfo.InitParent) con los datos de currentItemInfo
            newItemInfo.InitParent.GetComponentInParent<ItemSlot>().currentItemInfo = currentItemInfo;

        }

        itemDroppedTransform.SetParent(itemBackground); //Le emparento
        itemDroppedTransform.localPosition = Vector3.zero; //Le pongo en la misma posición.

        currentItemInfo = newItemInfo;

    }

}
