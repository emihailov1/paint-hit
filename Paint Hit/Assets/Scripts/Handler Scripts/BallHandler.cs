﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    public static Color oneColor;
    public GameObject ball;
    public GameObject dummyBall;

    private float speed = 100;
    public static float rotationSpeed = 130f;
    public static float rotationTime = 3;
    public static int currentCircleNumber;

    private int ballsCount;
    private int circleNumber;
    private int heartsNumber;

    private Color[] ChangingColors;

    public SpriteRenderer spriteRenderer;
    public Material splashMaterial;

    public Image[] balls;
    public GameObject[] hearts;


    void Start()
    {
        ResetGame();
    }

    void ResetGame()
    {
        ChangingColors = ColorScript.colorArray;
        oneColor = ChangingColors[0];

        ChangeBallsCount();

        spriteRenderer.color = oneColor;
        splashMaterial.color = oneColor;

        GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 4))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" + circleNumber;

        ballsCount = LevelsHandler.ballsCount;
        currentCircleNumber = circleNumber;
        LevelsHandler.currentColor = oneColor;

        if(heartsNumber == 0)
        {
            PlayerPrefs.SetInt("hearts", 1);
        }
        heartsNumber = PlayerPrefs.GetInt("hearts", 1);

        for(int i = 0; i < heartsNumber; i++)
        {
            hearts[i].SetActive(true);
        }

        MakeHurdles();
    }

    public void DescreaseHearts()
    {
        heartsNumber--;
        PlayerPrefs.SetInt("hearts", heartsNumber);
        hearts[heartsNumber].SetActive(false);
    }


    void Update()
    {
    }

    void ChangeBallsCount()
    {
        ballsCount = LevelsHandler.ballsCount;
        MeshRenderer mesh = dummyBall.GetComponent<MeshRenderer>();
        mesh.material.color = oneColor;
        for(int i = 0; i < balls.Length; i++)
        {
            balls[i].enabled = false;
        }

        for (int j = 0; j < balls.Length; j++)
        {
            balls[j].enabled = true;
            balls[j].color = oneColor;
        }
    }

    public void HitBall()
    {
        if(ballsCount <= 1)
        {
            base.Invoke("MakeNewCircle",0.4f);
            //Disable button for some time
        }
        ballsCount--;

        if(ballsCount >= 0)
        {
            balls[ballsCount].enabled = false;
        }

        GameObject gameObject = Instantiate<GameObject>(ball, new Vector3(0, 0, -8), Quaternion.identity);
        gameObject.GetComponent<MeshRenderer>().material.color = oneColor;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    void MakeNewCircle()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        GameObject gameObject = GameObject.Find("Circle" + circleNumber);

        for(int i=0; i<24; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;

        if(gameObject.GetComponent<iTween>())
        {
            gameObject.GetComponent<iTween>().enabled = false;
        }
        foreach(GameObject target in array)
        {
            iTween.MoveBy(target, iTween.Hash(new object[]
            {
                "y",
                -2.98f,
                "easeType",
                iTween.EaseType.spring,
                "time",
                0.5
            }));
        }
        circleNumber++;
        currentCircleNumber = circleNumber;

        GameObject gameObject2 = Instantiate(Resources.Load("round" + Random.Range(1, 4))) as GameObject;
        gameObject2.transform.position = new Vector3(0, 20, 23);
        gameObject2.name = "Circle" +circleNumber;

        ballsCount = LevelsHandler.ballsCount;

        oneColor = ChangingColors[circleNumber];
        spriteRenderer.color = oneColor;
        splashMaterial.color = oneColor;

        LevelsHandler.currentColor = oneColor;
        MakeHurdles();

        ChangeBallsCount();
    }

    void MakeHurdles()
    {
        if(circleNumber == 1)
        {
            FindObjectOfType<LevelsHandler>().MakeHurdles1();
        }
        else if (circleNumber == 2)
        {
            FindObjectOfType<LevelsHandler>().MakeHurdles2();
        }
        else if (circleNumber == 3)
        {
            FindObjectOfType<LevelsHandler>().MakeHurdles3();
        }
        else if (circleNumber == 4)
        {
            FindObjectOfType<LevelsHandler>().MakeHurdles4();
        }
        else
        {
            FindObjectOfType<LevelsHandler>().MakeHurdles5();
        }
    }
}
