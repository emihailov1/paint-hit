using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    public Color[] color1;
    public Color[] color2;
    public Color[] color3;

    public static Color[] colorArray;
    void Start()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        int randomColor = Random.Range(0, 2);

        PlayerPrefs.SetInt("ColorSelect", randomColor);
        PlayerPrefs.GetInt("ColorSelect");

        if(PlayerPrefs.GetInt("ColorSelect") == 0)
        {
            colorArray = color1;
        }
        else if (PlayerPrefs.GetInt("ColorSelect") == 1)
        {
            colorArray = color2;
        }
        else
        {
            colorArray = color3;
        }
    }

}
