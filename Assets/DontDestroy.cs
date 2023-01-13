using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
        transform.position = new Vector3(0, -20.6f, 0);

    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
