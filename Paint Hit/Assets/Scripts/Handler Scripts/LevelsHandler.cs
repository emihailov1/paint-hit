using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsHandler : MonoBehaviour
{
    public static int currentLevel;
    public static int ballsCount;
    public static int totalCircles;

    public static Color currentColor;
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

    public void MakeHurdles1()
    {
        GameObject gameObject = GameObject.Find("Circle" + BallHandler.currentCircleNumber);

        int index = Random.Range(1, 3);

        MeshRenderer mesh = gameObject.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = true;
        mesh.material.color = currentColor;
        gameObject.transform.GetChild(index).gameObject.tag = "red";
    }

    public void MakeHurdles2()
    {
        GameObject gameObject = GameObject.Find("Circle" + BallHandler.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(15,17)
        };

        for(int i=0; i< array.Length; i++)
        {
            MeshRenderer mesh = gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            mesh.material.color = currentColor;
            gameObject.transform.GetChild(i).gameObject.tag = "red";
        }
    }

    public void MakeHurdles3()
    {
        GameObject gameObject = GameObject.Find("Circle" + BallHandler.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(18,20),
        };

        for (int i = 0; i < array.Length; i++)
        {
            MeshRenderer mesh = gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            mesh.material.color = currentColor;
            gameObject.transform.GetChild(i).gameObject.tag = "red";
        }
    }

    public void MakeHurdles4()
    {
        GameObject gameObject = GameObject.Find("Circle" + BallHandler.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(15,17),
            Random.Range(22,24),
        };

        for (int i = 0; i < array.Length; i++)
        {
            MeshRenderer mesh = gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            mesh.material.color = currentColor;
            gameObject.transform.GetChild(i).gameObject.tag = "red";
        }
    }

    public void MakeHurdles5()
    {
        GameObject gameObject = GameObject.Find("Circle" + BallHandler.currentCircleNumber);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(11,13),
            Random.Range(8,10),
            Random.Range(15,17),
        };

        for (int i = 0; i < array.Length; i++)
        {
            MeshRenderer mesh = gameObject.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            mesh.material.color = currentColor;
            gameObject.transform.GetChild(i).gameObject.tag = "red";
        }
    }

}
