using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZoneMinion : MonoBehaviour, IDropHandler
{
    public string zoneType;
    public Text point;

    public int pointVal = 0;
    public int multiplier = 1;
    
    public void OnDrop(PointerEventData eventData) {
        // Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);
        DragCard d = eventData.pointerDrag.GetComponent<DragCard>();
        CardDisplayBattlefield cardComponent = eventData.pointerDrag.GetComponent<CardDisplayBattlefield>();
        CardBatt card = cardComponent.card;
        int cardScore = card.charPoint;
        if(d != null) {
            if(card.charType == zoneType){
                d.parentToReturnTo = this.transform;
                pointVal = pointVal + (int.Parse(cardComponent.charPointText.text) * multiplier);
                point.text = pointVal.ToString();
               // TotalPoint.totalScore += cardScore;
            }
        }
    }

    void Update() {
        point.text = pointVal.ToString();
    }
}
