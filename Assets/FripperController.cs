using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    bool leftTouch = false;
    bool rightTouch = false;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押したとき左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") { SetAngle(this.flickAngle); }
        //右矢印キーを押したとき右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") { SetAngle(this.flickAngle); }
        //矢印キーを離されたときフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") { SetAngle(this.defaultAngle); }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") { SetAngle(this.defaultAngle); }

        if (Input.touchCount > 0)
        {
            Touch[] touches = Input.touches;
            //画面右半分をタッチしていたら右フリッパーを動かす
            foreach (Touch touch in touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    //flickangle
                    if (touch.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                
                    }
                    if (touch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                }
                else
                {
                    //defaultAngle
                    if (touch.phase == TouchPhase.Ended == touch.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                    { SetAngle(this.defaultAngle); }

                    if (touch.phase == TouchPhase.Ended == touch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                    { SetAngle(this.defaultAngle); }
                }

            }



        }


    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring JointSpr = this.myHingeJoint.spring;
        JointSpr.targetPosition = angle;
        this.myHingeJoint.spring = JointSpr;
    }
}
