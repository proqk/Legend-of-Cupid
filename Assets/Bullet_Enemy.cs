using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//위 방향으로 이동하고 싶다
// - 속력
public class Bullet_Enemy : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = transform.up;
        transform.position += dir * speed * Time.deltaTime;
    }
}
