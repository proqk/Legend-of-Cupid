using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자의 입력에 따라 이동한뒤 처음위치로간다.
//-처음위치
//-속도
public class JoyStickMove : MonoBehaviour
{
    public AudioSource FootprintSound;

    //-애니메이터
    public Animator anim;
    //-상태
    public enum State
    {
        Idle, //-대기
        Run, //-이동
        Attack, //-공격

    }
    State state;


    public float scale = 0;
    //-속도
    public float speed = 10;
    public Vector3 dir;
    // property : 함수를 변수처럼 사용하는 방법
    public Vector3 GetDir
    {
        get
        {
            if (isMove)
                return dir;

            return Vector3.zero;
        }
        set
        {
            dir = value;
        }
    }
    //-처음위치
    public Transform firstpos;
    // 이동중/끝을 알기 위해 bool 변수를 하나 만들어서 처리하고싶다.
    public bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        FootprintSound = GetComponent<AudioSource>();
        FootprintSound.Stop();
    }

    Vector3 firstTouchPosition;
    // Update is called once per frame
    void Update()
    {
        //1.사용자의 입력에 따라
        //-방향
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        if (Input.GetMouseButtonDown(0))
        {
            // 이동 시작
            isMove = true;
            firstTouchPosition = Input.mousePosition;
            FootprintSound.Play();
            // 공격 스탑
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 이동 끝
            isMove = false;
            FootprintSound.Stop();
            // 공격 시작
            state = State.Attack;
            anim.SetTrigger("Attack");
        }


        dir = Input.mousePosition - firstTouchPosition;
        dir.Normalize();

        if (isMove)
        {
            // 이동중
            state = State.Run;
            anim.SetTrigger("Run");
            //2.이동하고싶다.
            Vector3 finalPosition = firstpos.transform.position + dir * scale;
            transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * speed);
        }
        else
        {
            //3.처음위치로
            state = State.Idle;
            anim.SetTrigger("Idle");
            transform.position = Vector3.Lerp(transform.position, firstpos.transform.position, Time.deltaTime * speed);
        }
    }
}
