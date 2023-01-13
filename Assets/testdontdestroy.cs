using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testdontdestroy : MonoBehaviour
{
    private GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("Player");

        print(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}