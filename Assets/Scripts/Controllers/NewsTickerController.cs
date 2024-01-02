using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class NewsTickerController : MonoBehaviour
{
    Dictionary<string, string> news = new Dictionary<string, string>(){
        {"The devloper of this game, [undefined], wants you to try <color=#4848ea>Antimatter Dimensions</color>! (click me)", "https://ivark.github.io/"},
        {"The devloper of this game, [undefined], wants you to try <color=#4848ea>Universal Paperclips</color>! (click me)", "https://www.decisionproblem.com/paperclips/"},
        {"The devloper of this game, [undefined], wants you to try <color=#4848ea>Synergism</color>! (click me)", "https://synergism.cc/"},
        {"The FitnessGram Pacer test is a multistage aerobic capacity test that progressively gets more difficult as it continues. The 20 meter Pacer test will begin in 30 seconds. Line up at the start. The running speed starts slowly, but gets faster each minute after you hear this signal *boop*. A single lap should be completed each time you hear this sound *ding*. Remember to run in a straight line, and run as long as possible. The second time you fail to complete a lap before the sound, your test is over. The test will begin on the word start. On your mark, get ready, start.", ""},
        {"Why is there antimatter here? This game is about matter.", ""},
        {"[ Undefined News ]", ""},
        {"News!", ""},
        {"\"You'll continue to live among them, chasing the hope someone will see you as the human you never were.\" - A quote from <i>You Will Never Be Human</i> written by a devloper's friend", ""},
        {"\"If you saw [someone] in front of you crying you probably wouldn't tell [them] to stop. That answer shouldn't change if th[at someone] is you.\" - A devloper's friend", ""},
        {"Everyone's human, and human lives are always worth something.", ""},
        {"I feel the beat in three dimensions.", ""},
        {"\"I think you broke my pulmonary artery\"", ""},
        {"My taste in men, is women", ""},
        {"To who ever wrote the last news ticker, blud think he socrates", ""},
        {"Placeholder", ""}
    };

    void Start()
    {
        CurrentNews();
    }

    public TMP_Text newsTxt;
    void Update()
    {
        if ((newsTxt.rectTransform.anchoredPosition.x + newsTxt.rectTransform.sizeDelta.x) <= -20)
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
        currentNews = news.ElementAt(random.Next(news.Count)).Key;
        newsTxt.text = currentNews;
        newsTxt.rectTransform.anchoredPosition = new Vector2(2000, 0);
    }

    public void onClick()
    {
        if (news[newsTxt.text].Length > 7)
        {
            Application.OpenURL(news[newsTxt.text]);
        }
    }
}
