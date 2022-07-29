using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int player1Score = 0; 
    private int player2Score = 0;
    public int endScore;

    public Text player1ScoreText; 
    public Text player2ScoreText;

    public void Player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        CheckScore();
    } 
    public void Player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        CheckScore();
    } 
    private void CheckScore()
    {
        if (player1Score == endScore || player2Score == endScore)
            
            //SceneManager.LoadScene(2);
            StartCoroutine(WaitForCelebration());
    }
    IEnumerator WaitForCelebration()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}

