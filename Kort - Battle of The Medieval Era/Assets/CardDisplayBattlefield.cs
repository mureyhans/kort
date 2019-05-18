using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayBattlefield : MonoBehaviour
{
    public CardBatt card;

    public Image charArtwork;
    public Image charType;
    public Text charPointText;

    // Start is called before the first frame update
    void Start()
    {
        charArtwork.sprite = card.charImage;
        charType.sprite = card.charTypeImage;
        charPointText.text = card.charPoint.ToString();
    }
}
