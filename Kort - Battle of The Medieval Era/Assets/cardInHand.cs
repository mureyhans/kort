using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardInHand : MonoBehaviour
{
    public GameObject handPanel;
    Text totalCardText;
    public static int totalCard = 0;
    // Start is called before the first frame update
    void Start()
    {
        totalCardText = GetComponent<Text>();
        totalCard = getTotalCardInHand();
        totalCardText.text = totalCard.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        totalCard = getTotalCardInHand();
        totalCardText.text = totalCard.ToString();
    }

    private int getTotalCardInHand()
    {
        return this.handPanel.transform.childCount;
    }
}
