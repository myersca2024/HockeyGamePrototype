using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PLevelManager : MonoBehaviour
{
    public static bool activePlayer = true; // true = player1, false = player2
    public int maxRounds = 6;
    public int player1score = 0;
    public int player2score = 0;
    public float startTime = 15f;
    public PPlayerMovement player1;
    public PPlayerMovement player2;
    public GameObject stick;
    public GameObject puck;

    public TMP_Text player1role;
    public TMP_Text player2role;
    public TMP_Text player1score_t;
    public TMP_Text player2score_t;
    public TMP_Text timer;
    public TMP_Text gameOver;

    Vector3 defaultPlayer1Pos;
    Vector3 defaultPlayer2Pos;
    Vector3 defaultStickPos;
    Vector3 defaultPuckPos;
    float currentTime;
    bool gameIsOver;
    int currentRound = 1;

    void Start()
    {
        player1.isPlayerOne = activePlayer;
        player1.isActivePlayer = true;
        player2.isPlayerOne = !activePlayer;
        player2.isActivePlayer = false;
        currentTime = startTime;

        defaultPlayer1Pos = player1.gameObject.transform.position;
        defaultPlayer2Pos = player2.gameObject.transform.position;
        defaultStickPos = stick.transform.position;
        defaultPuckPos = puck.transform.position;

        player1role.text = "Shooter";
        player2role.text = "Goalie";
        player1score_t.text = "0";
        player2score_t.text = "0";
    }

    void Update()
    {
        timer.text = currentTime.ToString("F2");
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            if (!gameIsOver)
            {
                gameIsOver = true;
                End();
            }
        }
    }

    public void Goal()
    {
        if (activePlayer)
        {
            player1score++;
            player1score_t.text = player1score.ToString();
        }
        else
        {
            player2score++;
            player2score_t.text = player2score.ToString();
        }
        if (!gameIsOver)
        {
            gameIsOver = true;
            End();
        }
    }

    public void End()
    {
        if (player1score == player2score && currentRound >= maxRounds)
        {
            player1.canMove = false;
            player2.canMove = false;
            Invoke("Restart", 3f);
        }
        else
        {
            if (currentRound >= maxRounds)
            {
                if (player1score > player2score)
                {
                    player1.canMove = false;
                    player2.canMove = false;
                    Time.timeScale = 0f;
                    GameOver("Player 1 Wins!");
                }
                else if (player2score > player1score)
                {
                    player1.canMove = false;
                    player2.canMove = false;
                    Time.timeScale = 0f;
                    GameOver("Player 2 Wins!");
                }
            }
            else
            {
                player1.canMove = false;
                player2.canMove = false;
                Invoke("Restart", 3f);
            }
        }
    }

    public void GameOver(string msg)
    {
        gameOver.gameObject.SetActive(true);
        gameOver.text = msg;
    }

    public void Restart()
    {
        player1.haveMoved = false;
        activePlayer = !activePlayer;
        player1.gameObject.transform.position = defaultPlayer1Pos;
        player2.gameObject.transform.position = defaultPlayer2Pos;
        stick.transform.position = defaultStickPos;
        puck.transform.position = defaultPuckPos;
        currentTime = startTime;
        player1.canMove = true;
        player2.canMove = true;
        gameIsOver = false;
        player1.isPlayerOne = !player1.isPlayerOne;
        player2.isPlayerOne = !player2.isPlayerOne;

        if (player1role.text == "Shooter")
        {
            player1role.text = "Goalie";
        }
        else
        {
            player1role.text = "Shooter";
        }

        if (player2role.text == "Shooter")
        {
            player2role.text = "Goalie";
        }
        else
        {
            player2role.text = "Shooter";
        }

        currentRound++;
    }
}
