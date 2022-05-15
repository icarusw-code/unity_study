using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // 이동공식 P = P0 + vt (v: Vector3.right * 5)
        // DeltaTime: 화면을 한번 주사하는데 걸리는 시간
        // 이동, 회전, 확대축소 에는 무조건 Time.deltaTime을 곱해준다.
        // transform.position += Vector3.right * 5 * Time.deltaTime;

        // 사용자의 입력에 따라 플레이어를 이동
        // 1. 사용자의 입력에 따라
        // h: (-1, 0, 1) print(h);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. 방향을 만들고
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        // right : [0,0,0] [1,0,0] [-1,0,0]
        // up : [0, 0, 0] [0,1,0] [0,-1,0]
        // 대각선으로 움직일시 피타고라스에 의하 크기가 더 크다 => 정규화
        dir.Normalize();

        // 3. 그 방향으로 플레이어를 이동하고 싶다.
        transform.position += dir * speed * Time.deltaTime;


    }
}
