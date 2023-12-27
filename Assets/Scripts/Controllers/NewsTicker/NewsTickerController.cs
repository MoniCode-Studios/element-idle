using UnityEngine;
using TMPro;

public class NewsTickerController : MonoBehaviour
{
    private News news;
    void Start()
    {
        news = new News();
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
        currentNews = news.news[random.Next(news.news.Length)];
        newsTxt.text = currentNews;
        newsTxt.rectTransform.anchoredPosition = new Vector2(2000, 0);
    }

    public void onClick() 
    {
        Application.OpenURL(newsTxt.text);
    }
}
