using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStorage : MonoBehaviour
{
    [SerializeField] protected List<Card> cards;
    [SerializeField] protected Transform cardsParent;
    [SerializeField] protected CardSlot[] cardSlots;


    private void OnValidate()
    {
        if (cardsParent != null)
            cardSlots = cardsParent.GetComponentsInChildren<CardSlot>();
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < cards.Count && i < cardSlots.Length; i++)
        {
            cardSlots[i].Card = cards[i];
        }

        for (; i < cardSlots.Length; i++)
        {
            cardSlots[i].Card = null;
        }
    }

    public bool AddCard(Card card)
    {
        if (IsFull())
            return false;

        cards.Add(card);
        RefreshUI();
        return true;
    }

    public bool RemoveCard(Card card)
    {
        if (cards.Remove(card)) //BUG : hapus yang pertama ditemukan 
                                // bukan ,sirkular gara2 di hapus lalu diinsert lagi
        {
            RefreshUI();
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return cards.Count >= cardSlots.Length;
    }

    public void SetCard(int index, Card card)
    {
        if (index <= cards.Count)
            cards[index] = card;
    }

    public int FindIndexCard(Card card)
    {
        return cards.FindIndex(a => a.name == card.name);
    }
}
