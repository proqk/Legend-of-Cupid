using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyManager_Enemy : MonoBehaviour
{
    public Animator anim;
    public GameObject expFactory;

    public enum State
    {
        Attack,
        GetHit,
        Die
    }
    public State state;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Bullet_Player")) 
        {
            //적->적 총알 충돌: 통과

        }
        //적->플레이어 충돌: 플레이어hp-1
        else if (other.gameObject.name.Contains("Player"))
        {
            HPManager hpm = other.gameObject.GetComponent<HPManager>(); //플레이어의 hp가져옴
            if (hpm != null)
            {
                hpm.SetHP(hpm.GetHP() + 1); //HP 1증가
                state = State.GetHit;
                anim.SetTrigger("GetHit");
                if (hpm.GetHP() == hpm.GetMaxHP()) //HP가 maxHP면 매혹당해서 사라짐
                {
                    state = State.Die;
                    anim.SetTrigger("Die");
                    anim.Play("Die", 0, 0);
                    
                    // 1.폭발시각효과를 생성해서
                    GameObject explosion = Instantiate(expFactory);
                    // 2. 충돌한 위치에 가져다 놓고싶다.
                    explosion.transform.position = this.transform.position;
                    // 3. 일정시간이 흐르면 알아서 없애고싶다.
                    Destroy(explosion, 2);

                    float curTime = 0;
                    float waitTime = 2;
                    curTime += Time.deltaTime;
                    if (curTime > waitTime)
                    {
                        curTime = 0;
                        Destroy(other.gameObject); //플레이어 파괴
                                                   //게임오버=GameOverUI를 활성화
                                                   //GameManager.Instance.gameOverUI.SetActive(true);
                    }
                }
            }
        }
    }
}
