using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image BG;
    public Sprite[] sprites;
    void Start()
    {
        BG.sprite = sprites[Random.Range(0, sprites.Length)];
    }

}
