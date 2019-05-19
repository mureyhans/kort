using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int CardsInDeck;
    private int UnitCards;
    private int SpecialCards;
    private int HeroCards;

    [SerializeField] DeckPanel deckPanel = null;
    [SerializeField] CardsCollection cardsCollection = null;
    [SerializeField] StatPanel statPanel = null;

    private void Awake()
    {
        CardsInDeck = deckPanel.getCountCardsInDeck();
        UnitCards = deckPanel.getCountUnitCards();
        SpecialCards = deckPanel.getCountSpecialCards();
        HeroCards = deckPanel.getCountHeroCards();
        statPanel.SetStats(CardsInDeck, UnitCards, SpecialCards, HeroCards);
        statPanel.UpdateStatValues();

        cardsCollection.OnCardRightClickedEvent += MoveCardToDeck;
        deckPanel.OnCardRightClickedEvent += MoveCardToCollection;
    }
    public void Update()
    {
        CardsInDeck = deckPanel.getCountCardsInDeck();
        UnitCards = deckPanel.getCountUnitCards();
        SpecialCards = deckPanel.getCountSpecialCards();
        HeroCards = deckPanel.getCountHeroCards();
        statPanel.SetStats(CardsInDeck, UnitCards, SpecialCards, HeroCards);
        statPanel.UpdateStatValues();
    }

    public void MoveCardToDeck(Card card) //equip
    {

        if (!deckPanel.IsFull()) //deck ga penuh
        {
            if (deckPanel.AddCard(card))
            {
                if (cardsCollection.RemoveCard(card))
                {
                    Debug.Log("Card added to the deck.");
                    //int idx = cardsCollection.FindIndexCard(card);
                    //cardsCollection.SetCard(idx, null); //hapus untuk tampilan
                } else {
                    Debug.Log("failed to add card");
                    cardsCollection.AddCard(card); //put back
                }
            }
            else
            {
                Debug.Log("failed to remove card from collection");
            }
        } else {
            Debug.Log("Deck is full.");
        }
    }
    public void MoveCardToCollection(Card card) //unequip
    {
        if(!cardsCollection.IsFull()) // deck ga penuh
        {
            if (deckPanel.RemoveCard(card))
            {
                cardsCollection.AddCard(card);
                Debug.Log("Card added to the collection.");
            } else {
                Debug.Log("Failed to remove card.");
            }
        } else {
            Debug.Log("Card Collection is full.");
        }
    }



}
