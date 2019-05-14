using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardSlot : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] Card card;

    public Card Card
    {
        get { return card;  }
        set
        {
            card = value;

            if (card == null)
            {
                //image.enabled = false;
            } else
            {
                //image.sprite = card.charImage;
                //image.enabled = true;
            }
        }
    }

    private void OnValidate()
    {
//        if (image == null)
//            image = GetComponent<Image>();
    }


    public Text charNameText;
    public Text charDescText;

    public Image charImage;
    public Image charType;
    public Text charPointText;

    // Start is called before the first frame update
    void Start()
    {
        if (card != null)
        {
            charNameText.text = card.charName;
            charDescText.text = card.charDesc;
            charImage.sprite = card.charImage;
            charType.sprite = card.charTypeImage;
            charPointText.text = card.charPoint.ToString();
        } else { //biar gak error kalau pertama ada card yang gak diinisialisasi
            charNameText.text = null;
            charDescText.text = null;
            charImage.sprite = null;
            charType.sprite = null;
            charPointText.text = null;
        }
    }
    private void Update()
    {
        if(card != null)
        {
            charNameText.text = card.charName;
            charDescText.text = card.charDesc;
            charImage.sprite = card.charImage;
            charType.sprite = card.charTypeImage;
            charPointText.text = card.charPoint.ToString();
        } else { //hapus tampilan
            charNameText.text = null;
            charDescText.text = null;
            charImage.sprite = null;
            charType.sprite = null;
            charPointText.text = null;
        }
    }

    public event Action<Card> OnRightClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Card != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Card);
                Debug.Log("Right Click!");
            }
        }
    }
}
