using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneBuff : MonoBehaviour, IDropHandler
{
    public string zoneType;
    public string zoneBuffType;
    public void OnDrop(PointerEventData eventData) {
        if(this.transform.childCount != 0) {
            var children = new List<GameObject>();
            foreach(Transform child in this.transform) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));
        }
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);

        DragCard d = eventData.pointerDrag.GetComponent<DragCard>();
        CardDisplayBattlefield cardComponent = eventData.pointerDrag.GetComponent<CardDisplayBattlefield>();
        CardBatt card = cardComponent.card;
        if(d != null || this.transform.childCount < 1) {
            if(card.charType == zoneType){
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
