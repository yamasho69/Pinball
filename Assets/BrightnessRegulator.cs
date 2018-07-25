using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    // Materialを入れる
    Material myMaterial;

    //Emissionの最小値
    private float minEmission = 0.3f;
    //Emissionの強度
    private float magEmission = 2.0f;
    //角度
    private int degree = 0;
    //発行速度
    private int speed = 10;

    //ターゲットのデフォルト色
    Color defaulotcolor = Color.white;

    // Use this for initialization
    void Start()
    {
        //タグによって光らせる色を変える
        if (tag == "SmallStarTag") { this.defaulotcolor = Color.white; }
        else if (tag == "LargeStarTag") { this.defaulotcolor = Color.yellow; }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        { this.defaulotcolor = Color.cyan; }

        //オブジェクトにアタッチしているmaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaulotcolor * minEmission);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.degree >= 0)
        {//光らせる強度を計算する
            Color emissionColor = this.defaulotcolor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            //エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);
            //現在の角度を小さくする
            this.degree -= this.speed;

        }

    }
    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;

        // 衝突したときにスコアを更新する
        

        if (tag == "SmallStarTag") {GameObject.Find("Canvas").GetComponent<ScoreController>().AddScore(1); }
        if (tag == "LargeStarTag") {GameObject.Find("Canvas").GetComponent<ScoreController>().AddScore(10); }
        if (tag == "SmallCloudTag") {GameObject.Find("Canvas").GetComponent<ScoreController>().AddScore(20); }
        if (tag == "LargeCloudTag") {GameObject.Find("Canvas").GetComponent<ScoreController>().AddScore(100); }


    }
}
