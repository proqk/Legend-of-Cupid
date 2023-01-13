using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//바라보는 쪽으로 이동하고 싶다
//-속력

public class Arrow : MonoBehaviour
{
    //-속력
    public float speed = 10;
    ////-타겟
    //public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //바라보는 쪽으로 이동하고 싶다.
        //1.바라보는 쪽으로
        Vector3 dir = transform.up;
        //2.이동하고 싶다
        transform.position += dir * speed * Time.deltaTime;
    }
}
