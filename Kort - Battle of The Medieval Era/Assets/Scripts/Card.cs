using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string charName;
    public string charDesc;

    public Sprite charImage;
    public Sprite charTypeImage;
    public int charPoint;
}
