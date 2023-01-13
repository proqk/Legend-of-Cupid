using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Player를 따라 이동하고 싶다.
//-Player
//-속도
public class PlayerMove : MonoBehaviour
{
    public float speed = 100;
    public Transform playerObject;
    CharacterController cc;
    public JoyStickMove joystick;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
     
        cc.Move(joystick.GetDir * speed * Time.deltaTime);
        playerObject.transform.up = joystick.GetDir;


    }
}
