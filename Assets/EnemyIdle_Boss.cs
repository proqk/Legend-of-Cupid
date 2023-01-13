using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle_Boss : MonoBehaviour
{
    Animator animator;

    public float speed = 10f; //이동속도
    public GameObject target; //플레이어 위치

    public Transform firePosition_Enemy; // - 총구위치
    public GameObject bulletPackageFactory; // - 총알공장

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void shoot()
    {
        GameObject bulletPackage = Instantiate(bulletPackageFactory); //반환값은 게임오브젝트

        bulletPackage.transform.position = firePosition_Enemy.position;
        bulletPackage.transform.up = (target.transform.position - firePosition_Enemy.position).normalized;

        Transform[] childs = bulletPackage.GetComponentsInChildren<Transform>();

        for (int i=0; i< childs.Length; i++)
        {
            childs[i].parent = null;
        }
        Destroy(bulletPackage);
    }
}
