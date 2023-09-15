using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Score : MonoBehaviour
{
    [SerializeField] private int player2Score;


    public static Player2Score Singleton;


    public TMP_Text playerScoreText;
    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void IncrementPlayer2Score()
    {
        player2Score++;
        playerScoreText.text = player2Score.ToString();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
