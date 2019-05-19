using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPanel : MonoBehaviour
{

    [SerializeField] List<Card> cards;
    [SerializeField] Transform cardsParent;
    [SerializeField] CardSlot[] cardSlots;
//    [SerializeField] WarningManager warningManager;

    private int countCardsInDeck;
    private int countUnitCards;
    private int countSpecialCards;
    private int countHeroCards;

    /* Set max count di UI nya masih manual */
    private int maxCountCardsInDeck = 20;
    private int maxCountUnitCards = 20;
    private int maxCountSpecialCards = 6;
    private int maxCountHeroCards = 5;


    public event Action<Card> OnCardRightClickedEvent;
    private void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
        for (int i = 0; i < cardSlots.Length; i++)
        {
            cardSlots[i].OnRightClickEvent += OnCardRightClickedEvent;
        }
        countCardsInDeck = cards.Count;
        countUnitCards = getInitialCountUnitCards();
        countSpecialCards = getInitialCountSpecialCards();
        countHeroCards = getInitialCountHeroCards();
    }

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
        if (IsFull() || countCardsInDeck >= maxCountCardsInDeck)
        {
            //warning deck full
            return false;
        }

        if (card.isHeroChar)
        {
            if (AddCounterHeroCard(card))
            {
                cards.Add(card);
                RefreshUI();
                return true;
            } else {
                //warning hero
                return false;
            }
        } else if (card.charTypeEnum == CardType.Weather || card.charTypeEnum == CardType.Buff)
        {
            if (AddCounterSpecialCard(card))
            {
                cards.Add(card);
                RefreshUI();
                return true;
            } else {
                //warning special card
                return false;
            }
        }
        else if(card.charTypeEnum == CardType.Melee || card.charTypeEnum == CardType.Ranged || card.charTypeEnum == CardType.Siege)
        {
            if (AddCounterUnitCard(card))
            {
                cards.Add(card);
                RefreshUI();
                return true;
            } else {
                //warning unit card
                return false;
            }
        } else {
            //undefined card type
            return false;
        }
    }

    private bool AddCounterHeroCard(Card card)
    {
        if (countHeroCards < maxCountHeroCards)
        {
            countUnitCards++;
            countHeroCards++;
            countCardsInDeck++;
            return true;
        } else {
            return false;
        }
    }
    private bool AddCounterUnitCard(Card card) {
        if (countUnitCards < maxCountUnitCards)
        {
            countUnitCards++;
            countCardsInDeck++;
            return true;
        } else {
            return false;
        }
    }
    private bool AddCounterSpecialCard(Card card)
    {
        if (countSpecialCards < maxCountSpecialCards)
        {
            countSpecialCards++;
            countCardsInDeck++;
            return true;
        } else {
            return false;
        }
    }

    public bool RemoveCard(Card card)
    {
        if (card.isHeroChar)
        {
            if (cards.Remove(card))
            {
                countHeroCards--;
                countUnitCards--;
                countCardsInDeck--;
                RefreshUI();
                return true;
            } else return false;
        } else if (card.charTypeEnum == CardType.Weather || card.charTypeEnum == CardType.Buff) {
            if (cards.Remove(card))
            {
                countSpecialCards--;
                countCardsInDeck--;
                RefreshUI();
                return true;
            } else return false;
        } else if (card.charTypeEnum == CardType.Melee || card.charTypeEnum == CardType.Ranged || card.charTypeEnum == CardType.Siege) {
            if (cards.Remove(card))
            {
                countUnitCards--;
                countCardsInDeck--;
                RefreshUI();
                return true;
            } else return false;
        } else {
            //undefined card type
            if (cards.Remove(card))
            {
                RefreshUI();
                return true;
            } else return false;
        }
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

    public int getCountCardsInDeck(){
        return cards.Count;
    }

    public int getCountHeroCards()
    {
        return countHeroCards;
    }

    private int getInitialCountHeroCards()
    {
        int initialCount = 0;
        for(int i = 0; i < cards.Count; i++)
        {
            if (cards[i].isHeroChar)
            {
                initialCount++;
            }
        }
        return initialCount;
    }

    public int getCountUnitCards()
    {
        return countUnitCards;
    }

    private int getInitialCountUnitCards()
    {
        int initialCount = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].charTypeEnum == CardType.Melee || cards[i].charTypeEnum == CardType.Ranged || cards[i].charTypeEnum == CardType.Siege)
            {
                initialCount++;
            }
        }
        return initialCount;
    }

    public int getCountSpecialCards()
    {
        return countSpecialCards;
    }
    private int getInitialCountSpecialCards()
    {
        int initialCount = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].charTypeEnum == CardType.Weather || cards[i].charTypeEnum == CardType.Buff)
            {
                initialCount++;
            }
        }
        return initialCount;
    }

}
