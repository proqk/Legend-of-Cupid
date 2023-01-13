using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //사용자의 입력에 따라 Player를 이동하고 싶다
        //코딩: 하고자 하는 것을 논리적으로 세분화하고 순서를 채우는 과정
        //1. 사용자의 입력에 따라
        // - 방향
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize(); //dir.magnitude = 1 하는 것임
        //2. 이동하고 싶다
        //p = p0 + vt
        transform.position += dir * speed * Time.deltaTime; //원본을 바꿈

    }
}
