using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{

    public float speed = 10f; //이동속도
    public GameObject target;
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

            Vector3 dir = (target.transform.position - transform.position).normalized;
            transform.up = dir * -1;

            // 2. 총알 공장에서 총알을 하나 생성해서
            GameObject bullet = Instantiate(bulletFactory); //반환값은 게임오브젝트
            // 3. 총구 위치에 가져다 놓는다
            bullet.transform.position = firePosition_Enemy.position;
            bullet.transform.up = (target.transform.position - transform.position).normalized;
        }
    }
}
