using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport_2 : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter(Collider target)
    {
        SceneManager.LoadScene("Scene5");

    }
}
