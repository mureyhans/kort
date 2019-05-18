using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneTrebuchet : MonoBehaviour, IDropHandler
{
    public string zoneType;
    public bool buffZone;
    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        DragCard d = eventData.pointerDrag.GetComponent<DragCard>();
        CardDisplayBattlefield cardComponent = eventData.pointerDrag.GetComponent<CardDisplayBattlefield>();
        CardBatt card = cardComponent.card;
        if(d != null) {
            if(card.charType == zoneType){
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
