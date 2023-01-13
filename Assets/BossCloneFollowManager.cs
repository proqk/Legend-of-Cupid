using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCloneFollowManager : MonoBehaviour
{
    public float speed; //이동속도
    GameObject target;

    Rigidbody rb;

    float curTime;
    public float calcSpeed = 100;
    public float pathCalcTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        //rb = gameObject.GetComponent<Rigidbody>();
        //rb.velocity = (target.transform.position - transform.position).normalized * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.up = rb.velocity * -1;
        if (target == null)
        {
            return;
        }

        /*
        curTime += Time.deltaTime;
        if (curTime > pathCalcTime)
        {
            curTime = 0;
            rb.AddForce((target.transform.position - transform.position).normalized * calcSpeed, ForceMode.Impulse);
        }
        */

        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
        transform.up = dir * -1;
    }
}
