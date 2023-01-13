using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 체력은 초기에 max치로 차 있다가 Player가 한 대 맞으면 1씩 감소하고 현재 HP가 0이 되면 게임 오버 되고 싶다
// - 현재체력
// - 최대체력
// - UI
public class HPManager : MonoBehaviour
{
    // - 현재체력
    public int curHP = 0;
    // - 최대체력
    public int maxHP = 10;
    // - UI
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        // 1. 태어날 때
        // 2. 현재 체력이 0이 되게 하고 싶다
        curHP = 0;
        // 3. UI로 표현하고 싶다
        slider.maxValue = maxHP;
        slider.value = curHP;
    }

    public void SetHP(int value) //들어온 value값을 curHP에 업데이트
    {
        curHP = value;
        slider.value = curHP;
    }

    public int GetHP()
    {
        return curHP;
    }

    public int GetMaxHP()
    {
        return maxHP;
    }


    // Update is called once per frame
    void Update()
    {
    }
}
