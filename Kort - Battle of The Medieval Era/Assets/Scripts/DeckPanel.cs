using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPanel : CardStorage
{
    public event Action<Card> OnCardRightClickedEvent;
    private void Awake()
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].OnRightClickEvent += OnCardRightClickedEvent;
        }
    }

    /*
        public bool AddCard(Card card)
        {
            for(int i = 0; i < cardSlots.Length; i++)
            {
                if(cardSlots[i].Card == null)
                {
                    RefreshUI();
                    cardSlots[i].Card = card;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveCard(Card card)
        {
            for (int i = 0; i < cardSlots.Length; i++)
            {
                if (cardSlots[i].Card == card)
                {
                    RefreshUI();
                    cardSlots[i].Card = null;
                    return true;
                }
            }
            return false;
        }
    */

}
