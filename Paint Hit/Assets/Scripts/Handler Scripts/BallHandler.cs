using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    public static Color oneColor;
    private static int CircleCount;

    public GameObject ball;
    public GameObject dummyBall;
    public GameObject button;
    public GameObject levelComplete;
    public GameObject failScreen;
    public GameObject startGameScreen;
    public GameObject circleEffect;
    public GameObject completeEffect;

    private float speed = 100;
    public static float rotationSpeed = 130f;
    public static float rotationTime = 3;
    public static int currentCircleNumber;

    private int ballsCount;
    private int circleNumber;
    private int heartsNumber;
    private int circleCount;

    private Color[] ChangingColors;

    public SpriteRenderer spriteRenderer;
    public Material splashMaterial;

    public Image[] balls;
    public GameObject[] hearts;

    public Text totalBallsText;
    public Text countBallsText;
    public Text levelCompleteText;


    private bool gameFail;


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

        totalBallsText.text = string.Empty + LevelsHandler.totalCircles;
        countBallsText.text = string.Empty + circleCount;

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
            StartCoroutine(HideBtn());
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

    IEnumerator HideBtn()
    {
        if (!gameFail)
        {
            button.SetActive(false);
            yield return new WaitForSeconds(1);
            button.SetActive(true);
        }
    }

    IEnumerator LevelCompleteScreen()
    {
        gameFail = true;

        completeEffect.SetActive(true);

        if (GameObject.Find("Circle0"))
        {
            completeEffect.transform.position = GameObject.Find("Circle0").transform.position;
        }
        else if (GameObject.Find("Circle1"))
        {
            completeEffect.transform.position = GameObject.Find("Circle1").transform.position;
        }
        else if (GameObject.Find("Circle2"))
        {
            completeEffect.transform.position = GameObject.Find("Circle2").transform.position;
        }

        GameObject oldCirlce = GameObject.Find("Circle" + circleNumber);
        for (int i = 0; i < 24; i++)
        {
            oldCirlce.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
        }
        oldCirlce.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = oneColor;
        oldCirlce.transform.GetComponent<MonoBehaviour>().enabled = false;
        if (oldCirlce.GetComponent<iTween>())
            oldCirlce.GetComponent<iTween>().enabled = false;
        button.SetActive(false);
        yield return new WaitForSeconds(2);
        levelComplete.SetActive(true);
        levelCompleteText.text = string.Empty + LevelsHandler.currentLevel;
        yield return new WaitForSeconds(1);
        GameObject[] oldCirlces = GameObject.FindGameObjectsWithTag("circle");
        foreach (GameObject gameObject in oldCirlces)
        {
            Destroy(gameObject.gameObject);
        }
        yield return new WaitForSeconds(1);
        completeEffect.SetActive(false);
        int currentLevel = PlayerPrefs.GetInt("C_Level");
        currentLevel++;
        PlayerPrefs.SetInt("C_Level", currentLevel);
        //GameObject.FindObjectOfType<LevelsHandler>().UpgradeLevel();
        ResetGame();
        levelComplete.SetActive(false);
        startGameScreen.SetActive(true);
        gameFail = false;
    }

    IEnumerator CircleEffect()
    {
        yield return new WaitForSeconds(.4f);
        circleEffect.SetActive(true);
        yield return new WaitForSeconds(.8f);
        circleEffect.SetActive(false);
    }
}
