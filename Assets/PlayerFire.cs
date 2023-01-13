using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자가 몬스터를 감지하면 화살공장에서 화살을 하나 생성해서 화살쏠 위치에 가져다 놓고 싶다
//-화살쏠 위치
//-화살공장

public class PlayerFire : MonoBehaviour
{
    //-화살통의 위치
    public Transform firePosition;
    //-화살공장위치
    public GameObject arrowFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 만약 마우스 왼쪽 버튼이 눌러졌다면
        if (Input.GetButtonDown("Jump"))
        {
            //2.화살공장에서 총알을 하나 생성해서
            GameObject arrow = Instantiate(arrowFactory);
            //3.화살통위치에 가져다놓고싶다.
            arrow.transform.position = firePosition.position;
        }
    }
}
