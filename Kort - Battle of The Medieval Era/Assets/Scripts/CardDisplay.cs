using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text charNameText;
    public Text charDescText;

    public Image charImage;
    public Image charType;
    public Text charPointText;

    // Start is called before the first frame update
    void Start()
    {
        charNameText.text = card.charName;
        charDescText.text = card.charDesc;
        charImage.sprite = card.charImage;
        charType.sprite = card.charTypeImage;
        charPointText.text = card.charPoint.ToString();
    }
}
