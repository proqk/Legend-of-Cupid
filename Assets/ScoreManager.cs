using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//플레이어가 적을 죽일 때마다 1씩 증가하다가 max까지 차면 게임성공 출력
//현재 점수
//max점수
//UI
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Inst;
    public Text F, C, B, A, ClearComment, AA, BB, CC, FF;
    public GameObject bossRoom, ChangeBoss;

    private void Awake()
    {
        Inst = this;
    }
    //현재 점수
    int curScore = 0;
    //max점수
    public int maxScore;
    //UI
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        curScore = 0;
        slider.maxValue = maxScore;
        slider.value = curScore;

        F.gameObject.SetActive(false);
        C.gameObject.SetActive(false);
        B.gameObject.SetActive(false);
        A.gameObject.SetActive(false);

        FF.gameObject.SetActive(false);
        CC.gameObject.SetActive(false);
        BB.gameObject.SetActive(false);
        AA.gameObject.SetActive(false);

        ChangeBoss.gameObject.SetActive(false);
    }
    public void SetScore(int value)
    {
        curScore = value;
        slider.value = curScore;
    }

    public int GetCurScore()
    {
        return curScore;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Scene3" && ScoreManager.Inst.GetCurScore() >= 0 && ScoreManager.Inst.GetCurScore() <= 6)
        {
            F.gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Scene3" && ScoreManager.Inst.GetCurScore() >= 7 && ScoreManager.Inst.GetCurScore() <= 15)
        {
            F.gameObject.SetActive(false);
            C.gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Scene4" && ScoreManager.Inst.GetCurScore() >= 0 && ScoreManager.Inst.GetCurScore() <= 5)
        {
            C.gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Scene4" && ScoreManager.Inst.GetCurScore() >= 6 && ScoreManager.Inst.GetCurScore() <= 15)
        {
            C.gameObject.SetActive(false);
            B.gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Scene5" && ScoreManager.Inst.GetCurScore() >= 0 && ScoreManager.Inst.GetCurScore() <= 5)
        {
            B.gameObject.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Scene5" && ScoreManager.Inst.GetCurScore() >= 6 && ScoreManager.Inst.GetCurScore() <= 15)
        {
            B.gameObject.SetActive(false);
            A.gameObject.SetActive(true);
        }

        if (bossRoom == null) //보스룸이 없어지면 게임이 성공했으므로 성적 출력해줘야 함
        {
            ClearComment.gameObject.SetActive(true); //클리어 문장 출력
            ChangeBoss.gameObject.SetActive(true); //보스 인간으로 변신

            if (A.gameObject.activeSelf) AA.gameObject.SetActive(true);
            else if (B.gameObject.activeSelf) BB.gameObject.SetActive(true);
            else if (C.gameObject.activeSelf) CC.gameObject.SetActive(true);
            else if (F.gameObject.activeSelf) FF.gameObject.SetActive(true);
        }

    }

}
