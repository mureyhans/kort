using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "CardBatt")]
public class CardBatt : ScriptableObject
{
    public Sprite charImage;
    public Sprite charTypeImage;
    public string charType;
    public int charPoint;
}
