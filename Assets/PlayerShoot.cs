using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자가 마우스 왼쪽 버튼을 누르면 총알공장에서 총알을 하나 생성해서 총구 위치에 가져다 놓고 싶다
// - 총구위치(속성)
// - 총알공장(속성)

public class PlayerShoot : MonoBehaviour
{
    // - 총구위치
    public Transform firePosition;
    // - 총알공장
    public GameObject bulletFactory;
    GameObject target=null;


    float curTime = 1f;
    float maxTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 만약 사용자가 마우스 왼쪽 버튼을 누르면(=만약 마우스 왼쪽 버튼 이벤트가 발생했다면)
        //GetButton만 하면 연속으로 나감
        curTime += Time.deltaTime;

            if (curTime > maxTime)
            {
                if (target != null)
                {
                //print("감지함");
                // 2. 총알 공장에서 총알을 하나 생성해서
                GameObject bullet = Instantiate(bulletFactory); //반환값은 게임오브젝트
                                                                    // 3. 총구 위치에 가져다 놓는다
                    bullet.transform.position = firePosition.position;

                    bullet.transform.up = (target.transform.position - firePosition.position).normalized;
                //공격방향보기
                //transform.up = target.transform.position - transform.position;
                }

                curTime = 0;
                

            
        }
    }

    public void set(GameObject closerObject)
    {
        if (closerObject != null)
        { 
            target = closerObject;
        }
        else print("null");
    }
}
