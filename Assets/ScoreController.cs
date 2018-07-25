using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    // 角度
    private int degree = 0;

    //発光速度
    private int speed = 10;

    //スコア変数の宣言
    public int score = 0;

    public Text ScoreCount;

    GameObject scoreText;

    public void AddScore(int addscore)
    {this.score += addscore; }




    void Start()
    {
        this.scoreText = GameObject.Find("ScoreCount");
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");
    }
}