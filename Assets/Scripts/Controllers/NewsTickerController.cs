using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class NewsTickerController : MonoBehaviour
{
    System.Random random = new System.Random();

    public TMP_Text newsTxt;
    public string currentNews;

    private string[] newsTickers;
    void Start()
    {
        newsTickers = new [] 
        {
            "You made one matter! Whatever that means.",
            "Why is there antimatter here? This game is about matter."
        };
        CurrentNews();
    }
    void Update()
    {
        // if ((newsTxt.rectTransform.position.x + newsTxt.rectTransform.sizeDelta.x) == 0)
        // {
        //     CurrentNews();
        // }
        // else
        // {
        //     // newsTxt.rectTransform.position = new Vector3((float)(newsTxt.rectTransform.position.x - 2), 0, 0);
        // }
    }

    void CurrentNews()
    {
        currentNews = newsTickers[random.Next(newsTickers.Length)];
        newsTxt.text = currentNews;
        newsTxt.rectTransform.position = new Vector3 (2000, 0, 0);
    }
}
