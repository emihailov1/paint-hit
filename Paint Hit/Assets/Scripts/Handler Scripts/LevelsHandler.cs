using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsHandler : MonoBehaviour
{
    public static int currentLevel;
    public static int ballsCount;
    public static int totalCircles;
    void Awake()
    {
        if(PlayerPrefs.GetInt("firstTime1") == 0)
        {
            PlayerPrefs.SetInt("firstTime1", 1);
            PlayerPrefs.SetInt("C_Level", 1);
            //Add more to it
        }
        UpgradeLevel();
    }

    void UpgradeLevel()
    {
        currentLevel = PlayerPrefs.GetInt("C_Level",1);
        if(currentLevel == 1)
        {
            ballsCount = 3;
            totalCircles = 2;
        }
        else if (currentLevel == 2)
        {
            ballsCount = 3;
            totalCircles = 3;
        }
        else if (currentLevel == 3)
        {
            ballsCount = 3;
            totalCircles = 4;
        }
        else if (currentLevel == 4)
        {
            ballsCount = 3;
            totalCircles = 5;
        }
        else if (currentLevel >= 5 && currentLevel<= 20)
        {
            ballsCount = 4;
            totalCircles = 5;
        }
        else
        {
            ballsCount = 4;
            totalCircles = 6;
            BallHandler.rotationSpeed = 120;
            BallHandler.rotationTime = 2;
        }
    }

}
