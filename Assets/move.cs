using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float Force = 20.0f;
    float maxSpeed = 40.0f;
    Text myScore;
    float timeCount = 0;
    int getHp = 10;
    GameObject hpGauge;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        myScore = GameObject.Find("Score").GetComponent<Text>();
        this.hpGauge.GetComponent<Image>().fillAmount = 1f;
    } 

    void Update()
    {
        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //상하 이동
        int key2 = 0;
        if (Input.GetKey(KeyCode.UpArrow)) key2 = 1;
        if (Input.GetKey(KeyCode.DownArrow)) key2 = -1;

        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 스피드 제한
        if (speedx < this.maxSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.Force);
            this.rigid2D.AddForce(transform.up * key2 * this.Force);
        }

        // 움직이는 방향에 따라 이미지 반전 
        if (key != 0)
        {
            transform.localScale = new Vector3(key * 3, 3, 3);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다 
        this.animator.speed = speedx / 2.0f;
        
        // 플레이 시간 측정 및 ui 갱신
            timeCount += Time.deltaTime;
            SetText();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("충돌");
        getHp -= 1;

        // 감독 스크립트에 충돌했다고 전달한다 ->  hp 감소
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().DecreaseHp();
        if (getHp == 0) // 씬 전환
        {
            SceneManager.LoadScene("end");
        }
    }

    void SetText()
    {
        myScore.text = "Time score " + timeCount.ToString();
    }
}