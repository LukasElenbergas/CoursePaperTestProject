using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int startTimeMarioSeconds = 400;

    private float currentTime = 0;
    private int score = 0;
    private int coins = 0;


    public GameObject scoreUI;
    public GameObject coinScoreUI;
    public GameObject timeLeftUI;

    private string scoreString;
    private string coinString;
    private string timeString;

    private int goombaKillSpreeCounter = 0;
    private float goombaLastKillTimer = 0;

    void Awake()
    {
        currentTime = startTimeMarioSeconds;
    }

    void Update()
    {
        if(currentTime > 0 && !transform.parent.GetComponent<PlayerController>().isDead && !transform.parent.GetComponent<PlayerController>().wonGame)
        {
            goombaLastKillTimer = goombaLastKillTimer + Time.deltaTime;

            scoreString = GetScore().ToString("00000");
            scoreUI.gameObject.GetComponent<Text>().text = (scoreString);

            coinString = GetCoins().ToString("00");
            coinScoreUI.gameObject.GetComponent<Text>().text = ("x" + coinString);

            timeLeftUI.gameObject.GetComponent<Text>().text = ("" + (int)GetCurrentTime());

            //Time runs faster in the Mario world
            //1 real world secod is about 3 Mario world ones
            for(int i = 0; i < 3; i++)
                currentTime = currentTime - Time.deltaTime;
        }
        

        if (currentTime <= 0)
            transform.parent.GetComponent<PlayerController>().Lost();

    }
    ////GETS///////////////////////
    public float GetCurrentTime()
    {
        return currentTime;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

    ////OTHER METHODS///////////////
    public void Goomba()
    {
        if (goombaLastKillTimer > 0.5f) //If Goomba was killed more than 0.5 seconds ago, we don't care about it
            goombaKillSpreeCounter = 0;
		
        score += (100 * (2 * goombaKillSpreeCounter)); //More killing, more score

        if (goombaKillSpreeCounter == 0) //Score that we add if no Goomba was killed in the last 0.5 seconds
            score += 100;

        goombaKillSpreeCounter++;
        goombaLastKillTimer = 0f;
    }

    public void Mushroom()
    {
        score += 1000;
    }

    public void Coin()
    {
        score += 200;
        coins++;
    }

    public void Brick()
    {
        score += 50;
    }
}
