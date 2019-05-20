using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneManager : MonoBehaviour
{


    [SerializeField] DeckPanel deckPanel = null;
    private int CardsInDeck = 0;

    void Update()
    {
        CardsInDeck = deckPanel.getCountCardsInDeck();
    }

    public void LoadScene(string sceneName){
        if(sceneName == "Battlefield")
        {
            if (CardsInDeck >= 10)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                WarningSystemCID.Instance.ShowMessage(deckPanel.getCountCardsInDeck().ToString());
                deckPanel.playAlert();
            }
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
