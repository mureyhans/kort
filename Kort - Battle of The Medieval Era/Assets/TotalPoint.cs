using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalPoint : MonoBehaviour
{
    public static int totalScore = 0;
    //public DropZoneMinion zoneDrop;
    public GameObject scoreSwordsmen;
    public GameObject scoreArcher;
    public GameObject scoreTrebuchet;

    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalScore = updateScore();
        scoreText.text = totalScore.ToString();
    }

    int updateScore()
    {
        int tempScore = 0;
        tempScore += int.Parse(scoreSwordsmen.GetComponent<Text>().text);
        tempScore += int.Parse(scoreArcher.GetComponent<Text>().text);
        tempScore += int.Parse(scoreTrebuchet.GetComponent<Text>().text);
        return tempScore;
    }
}
