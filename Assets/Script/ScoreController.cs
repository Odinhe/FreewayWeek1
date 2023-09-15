using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private int player1Score;

    public static ScoreController Singleton;


    public TMP_Text playerScoreText;
    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void IncrementPlayer1Score()
    {
        player1Score++;
        playerScoreText.text = player1Score.ToString();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
