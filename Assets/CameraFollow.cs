using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }


    void LateUpdate()
    {
        Vector3 temp = transform.position; // 카메라 포지션값 저장
        temp.y = playerTransform.position.y; //카메라의x값이 Player의 x값과 동일하게 만든다
        temp.y += offset; //
        transform.position = temp; // 카메라 포지션 값을 현재 포지션으로 변경
    }
}
