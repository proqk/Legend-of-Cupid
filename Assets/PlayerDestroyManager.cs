using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDestroyManager : MonoBehaviour
{
    public Animator anim;
    public GameObject expFactory;
    public GameObject expFactory2;
    CameraShake cs;


    // Start is called before the first frame update
    void Start()
    {
        cs = Camera.main.gameObject.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Bullet_Enemy"))
        {
          
        }
        else if (other.gameObject.name.Contains("Enemy")) //플레이어 총알->적 충돌
        {
            
            HPManager hpm = other.gameObject.GetComponent<HPManager>(); //적의 피 닳게
            //ScoreManager2 scm = other.gameObject.GetComponent<ScoreManager2>(); //스코어 올라가게

            // 1.폭발시각효과를 생성해서
            GameObject explosion = Instantiate(expFactory);
            // 2. 충돌한 위치에 가져다 놓고싶다.
            explosion.transform.position = this.transform.position;
            // 3. 일정시간이 흐르면 알아서 없애고싶다.
            Destroy(explosion, 1);

            cs.shouldShake = true; //카메라 흔들

            hpm.SetHP(hpm.GetHP() + 1); //HP 1감소
            if (hpm.GetHP() == hpm.GetMaxHP()) //HP가 0이면 적을 파괴함
            {
                ScoreManager.Inst.SetScore(ScoreManager.Inst.GetCurScore() + 1); //적이 파괴되면 스코어 1 증가

                if (other.gameObject.name.Contains("EnemyFollow_backup")) //클론 좀비는 부모가 죽는 게 아니다
                {
                    Destroy(other.gameObject);
                }
                else if (other.gameObject.name.Contains("Boss_Enemy"))
                {
                   

                    /*
                    float curTime = 0;
                    float waitTime = 1f;
                    curTime += Time.deltaTime;
                    if (curTime > waitTime)
                    {
                        curTime = 0;
                        Destroy(other.transform.parent.gameObject); //1초뒤에 클리어 성적 출력
                    }*/

                    //보스 터지면서 이펙트 펑
                    GameObject explosion2 = Instantiate(expFactory2);
                    // 2. 충돌한 위치에 가져다 놓고싶다.
                    explosion.transform.position = this.transform.position;
                    // 3. 일정시간이 흐르면 알아서 없애고싶다.
                    Destroy(explosion, 1);

                    Destroy(other.transform.parent.transform.parent.gameObject); //보스가 죽은 거면 보스룸 전체 파괴
                    
                }
                else Destroy(other.transform.parent.gameObject); //적 파괴

            }
            Destroy(this.gameObject); //총알 없앰
        }
 
    }
}