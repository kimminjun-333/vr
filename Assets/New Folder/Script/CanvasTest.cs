using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class CanvasTest : MonoBehaviour
{
    public static CanvasTest instance;

    public int score = 0;
    public int bulletCount = 0;
    public GameObject text;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text timeText;
    public float time = 100f;
    public Button gameStartButton;

    private void Awake()
    {
        instance = this;
        gameStartButton.gameObject.SetActive(true);
        gameStartButton.onClick.AddListener(GameStartButtonClick);
        text.gameObject.SetActive(false);
    }

    public void GameStartButtonClick()
    {
        TargetSpwan.instance.GameStart();
        TextStart();
        gameStartButton.gameObject.SetActive(false);
    }

    public void TextStart()
    { 
        text.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        scoreText.text = "<color=red>ÃÑ Á¡¼ö : " + this.score.ToString() + " Á¡</color>\n" + "<color=blue>ÃÑ¾Ë·Î ÆÄ±«ÇÑ °¹¼ö : " + bulletCount.ToString() + " °³</color>";
        Timer();
    }

    public void Timer()
    {
        timeText.text = string.Format("{0:N1}", time) + "ÃÊ ³²À½";
        if (time <= 0)
        {
            TargetSpwan.instance.GameEnd();
            GameEndText();
        }
    }

    private void GameEndText()
    {
        timeText.gameObject.SetActive(false);
        scoreText.text = "<color=red>ÃÑ Á¡¼ö : " + this.score.ToString() + " Á¡</color>";
    }

    public void ScoreUP(int score)
    {
        this.score += score;
        scoreText.text = "<color=red>ÃÑ Á¡¼ö : " + this.score.ToString() + " Á¡</color>\n" + "<color=blue>ÃÑ¾Ë·Î ÆÄ±«ÇÑ °¹¼ö : " + bulletCount.ToString() + " °³</color>";
    }

    public void BulletUpScore(int score)
    {
        bulletCount++;
        ScoreUP(score);
        if (CanvasTest.instance.bulletCount % 10 == 0 && CanvasTest.instance.score != 0)
        {
            OBJSpwan.instance.Spwan();
        }
    }
}
