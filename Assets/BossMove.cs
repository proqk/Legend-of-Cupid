using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public GameObject target; //플레이어
    public float speed; //돌진 속도
    public float shootTime; //n초마다 돌진
    public float waitTime; //n초 대기
    float curTime = 0; //현재시간-이동
    float curTime2 = 0; //현재시간-대기
    public EnemyIdle_Boss eb;

    public Animator anim; //애니메이터
    public GameObject BossExpFactory; //보스가 지나는 바닥 이펙트

    enum State
    {
        Wait, //3초 대기(Idle)
        Move, //플레이어한테 이동(Move)
        MoveWait, //이동해서 총 쏘기 전에 잠깐 대기(Attack)
        Shoot, //총 쏘기
        Dead //파괴(Dead)
    }
    State state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = State.Wait;
    }

    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        switch(state)
        {
            case State.Wait:
                GameObject explosion_idle = Instantiate(BossExpFactory);
                explosion_idle.transform.position = this.transform.position;
                Destroy(explosion_idle, 1);
                if (curTime > 3)
                {
                    curTime = 0;
                    state = State.Move;
                    targetPosition = target.transform.position;
                    anim.SetTrigger("Attack");
                }
                break;
            case State.Move:
                anim.Play("Attack", 0, 0);
                Vector3 dir = (target.transform.position - transform.position).normalized;
                transform.up = dir * -1;
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

                GameObject explosion = Instantiate(BossExpFactory);
                explosion.transform.position = this.transform.position;
                Destroy(explosion, 2);

                //플레이어 보게                
                //anim.SetTrigger("Move");
                if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
                {
                    transform.position = targetPosition;
                    curTime = 0;
                    state = State.MoveWait;
                }
                break;
            case State.MoveWait:
                if (curTime > 1f)
                {
                    curTime = 0;
                    state = State.Shoot;
                    anim.SetTrigger("Move");
                }
                break;
            case State.Shoot:
                if (eb != null)
                {
                    eb.shoot();
                }
                curTime = 0;
                state = State.Wait;
                break;
            case State.Dead:

                break;
        }
    }
}