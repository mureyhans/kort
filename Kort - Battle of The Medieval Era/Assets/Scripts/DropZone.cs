using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string zoneType = "Trebuchet";
    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        DragCard d = eventData.pointerDrag.GetComponent<DragCard>();
        CardBatt cardCharType = eventData.pointerDrag.GetComponent<CardBatt>();
        if(d != null) {
            if(cardCharType.charType == zoneType){
                d.parentToReturnTo = this.transform;
            } 
        }
    }
}
