using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//적: 플레이어 방향으로 에너지파를 쏜다
// 플레이어 방향으로
// 쏜다(애니메이션)
public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;

    public float speed; //이동속도
    public GameObject target;

    void Start()
    {
        animator = GetComponent<Animator>(); //애니메이션 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }
}
