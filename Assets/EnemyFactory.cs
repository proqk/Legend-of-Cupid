using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//시간이 흐르다가 일정시간마다 적 공장에서 적을 생성해서 자기자신의 위치에 가져다 놓고, 
//방향도 자기자신의 방향으로 회전하고 싶다
// - 적 공장
// - 일정 시간
// - 현재 시간
public class EnemyFactory : MonoBehaviour
{
    // - 적 공장
    public GameObject enemyFactory;
    // - 일정 시간
    public float createTime;
    // - 현재 시간
    float currentTime;

    public GameObject target; //플레이어
    public Transform firePosition_Enemy; //보스 쫄따구 위치

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime; //델타 타임을 계속 더하다가 1이 되는 순간이 1초
        // 2. 만약 현재 시간이 일정 시간을 초과하면
        if (currentTime > createTime)
        {
            currentTime = 0;
            // 3. 적 공장에서 적을 생성하고
            GameObject enemy = Instantiate(enemyFactory);
            // 3. 총구 위치에 가져다 놓는다
            enemy.transform.position = firePosition_Enemy.position;
            enemy.transform.forward = (target.transform.position - transform.position).normalized;
        }
    }
}
