using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(500f, 2000f)] float speed = 1000f; //볼의 이동속도 500~2000설정 가능
    public Rigidbody2D rb;
    float randomX, randomY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomX = Random.Range(-1f, 1f);
        randomY = Random.Range(-1f, 1f);
        Vector2 dir = new Vector2(randomX, randomY).normalized;

        rb.AddForce(dir * speed); //speed에 비례 힘을 가함
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
