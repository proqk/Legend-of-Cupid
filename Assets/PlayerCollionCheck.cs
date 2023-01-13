using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollionCheck : MonoBehaviour
{
    public Transform area;
    public PlayerShoot pshoot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int layer = 1 << LayerMask.NameToLayer("Enemy");
        Collider[] cols = Physics.OverlapSphere(transform.position, area.localScale.x / 2, layer);
        float dist = float.MaxValue; //나와 충돌 범위 내의 최단 거리 오브젝트의 거리 변수
        int selectIndex = -1;
        for (int i = 0; i < cols.Length; i++) //충돌 범위 안에 들어온 모든 오브젝트의 수
        {
            if (transform == cols[i].transform) //자기 자신은 뺀다
            {
                continue;
            }
            float temp = Vector3.Distance(transform.position, cols[i].transform.position); //나와 상대방의 거리
            if (temp < dist) //현재 최소 거리보다 더 짧은 거리라면, 최소 거리를 갱신한다
            {
                dist = temp;
                selectIndex = i; //가장 짧은 거리인 오브젝트의 넘버를 저장한다
            }
        }

        if (selectIndex != -1) //최단 거리 오브젝트가 갱신이 되었다면?
        {
            //print(cols[selectIndex].gameObject.name);
            //print(cols[selectIndex].gameObject.name);
            //충돌 범위 안에 플레이어가 들어오면 클론이 플레이어한테 총을 쏜다
            pshoot.set(cols[selectIndex].gameObject);
        }
    }
}
