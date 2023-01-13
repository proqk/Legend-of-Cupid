using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    //float ry;
    //float my;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ry += my * Time.deltaTime* 300;
        ////transform.Rotate(Vector3.left * Time.deltaTime);
        //transform.eulerAngles = new Vector3(0, ry, 0);

        transform.Rotate(-1, 0, 1);
    }
}
