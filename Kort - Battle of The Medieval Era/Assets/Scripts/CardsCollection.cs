using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCollection : CardStorage
{
    public event Action<Card> OnCardRightClickedEvent;
    private void Awake()
    {
        for(int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].OnRightClickEvent += OnCardRightClickedEvent;
        }
    }
}
