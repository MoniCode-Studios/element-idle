using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewsTickerController : MonoBehaviour
{
    public string[] news = new[]
        {
            "You made one matter! Whatever that means.",
            "Why is there antimatter here? This game is about matter.",
            "[ Undefined News Ticker ]",
            "News!",
            "Wait! Isn't this just copied from anti-          *gun click*          I love this 100% original game!",

        };

    void Start()
    {
        CurrentNews();
    }

    public TMP_Text newsTxt;
    void Update()
    {
        if ((newsTxt.rectTransform.anchoredPosition.x + newsTxt.rectTransform.sizeDelta.x) <= -10)
        {
            CurrentNews();
        }
        else
        {
            newsTxt.rectTransform.anchoredPosition = new Vector3((float)(newsTxt.rectTransform.anchoredPosition.x - 1), 0, 0);
        }
    }

    private string currentNews;
    private System.Random random = new System.Random();
    void CurrentNews()
    {
        currentNews = news[random.Next(news.Length)];
        newsTxt.text = currentNews;
        newsTxt.rectTransform.anchoredPosition = new Vector2(2000, 0);
    }

    public void onClick()
    {
        Application.OpenURL(newsTxt.text);
    }
}
