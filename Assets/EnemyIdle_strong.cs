using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle_strong : MonoBehaviour
{
    Animator animator;
    public float maxHp = 1000f; //전체 hp
    public float currentHp = 1000f; //현재 hp

    public float speed = 10f; //이동속도
    public GameObject target; //플레이어 위치

    public Transform firePosition_Player;
    public Transform firePosition_Enemy; // - 총구위치
    public GameObject bulletFactory; // - 총알공장

    public float shootTime = 2; //이 시간 간격으로 총알 발사
    float curTime = 0; //현재시간

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > shootTime)
        {
            curTime = 0;
            // 2. 총알 공장에서 총알을 3개 생성해서
            GameObject bullet1 = Instantiate(bulletFactory);
            GameObject bullet2 = Instantiate(bulletFactory);
            GameObject bullet3 = Instantiate(bulletFactory);
            // 3. 총구 위치에 하나씩 가져다 놓는다
            bullet1.transform.position = firePosition_Enemy.position;
            bullet1.transform.forward = (target.transform.position - transform.position).normalized;

            bullet2.transform.position = firePosition_Enemy.position;
            Vector3 tmp = bullet2.transform.position;
            tmp.x += 2;
            bullet2.transform.position = tmp;
            bullet2.transform.forward = (target.transform.position - transform.position).normalized;

            bullet3.transform.position = firePosition_Enemy.position;
            Vector3 tmp2 = bullet3.transform.position;
            tmp.x -= 1;
            bullet3.transform.position = tmp2;
            bullet3.transform.forward = (target.transform.position - transform.position).normalized;
        }
    }
}
