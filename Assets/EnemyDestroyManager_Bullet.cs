using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyDestroyManager_Bullet : MonoBehaviour
{
    
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) //OnTriggerEnter
    {
        if (other.gameObject.name.Contains("Bullet_Player"))
        {
        }
        if (other.gameObject.name.Contains("Enemy"))
        {
        }
        else if (other.gameObject.name.Contains("Player"))
        {
            //적 총알->플레이어 충돌: 플레이어 hp-1  
            HPManager_player hpm = other.gameObject.GetComponent<HPManager_player>(); //플레이어 hp가져옴
            //HPManager_player hpm = GameObject.Find("Player").GetComponent<HPManager_player>();
            if (hpm != null)
            {
                //print("들어옴");
                hpm.SetHP(hpm.GetHP() - 1); //HP 1감소
                if (hpm.GetHP() == 0) //HP가 maxHP면 매혹당해서 사라짐
                {
                    Destroy(other.gameObject); //플레이어   파괴
                                               //게임오버=GameOverUI를 활성화

                    GameManager.Instance.GameOverUI.SetActive(true);
                }
            }
            //else print(other.gameObject.name);
            Destroy(this.gameObject); //적 총알->플레이어 충돌하면 총알이 없어짐
        }
    }
}
