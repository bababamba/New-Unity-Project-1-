using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public static StaminaManager stamina;

    int CurStamina = 50;
    static int MaxStamina = 100;
    
    float CurStaminaTime = 30f;
    static float MaxStaminaTime = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurStamina <=MaxStamina)
            CurStaminaTime -= Time.deltaTime;
        if (CurStaminaTime <= 0)
        {
            CurStaminaTime = MaxStaminaTime;
            //임시 자동 스테미나 충전량
            StaminaUp(10);
        }
    }
    //스테미나 증가 시에 사용
    public void StaminaUp(int value)
    {
        CurStamina += value;
        if (CurStamina > MaxStamina)
        {
            CurStamina = MaxStamina;
            CurStaminaTime = MaxStaminaTime;
        }
    }
    //스테미나 감소시, 감소하였을 때에 0 미만인지 체크
    public bool StaminaCheck(int value)
    {
        if (CurStamina - value > 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //스테미나 감소 시 위 함수와 함께 사용
    public void StaminaDown(int value)
    {
        CurStamina -= value;
    }
    //현재 스테미나 값
    public int GetStamina()
    {
        return CurStamina;
    }
    public void SetStamina(int value)
    {
        CurStamina = value;
        if (CurStamina > MaxStamina)
            CurStamina = MaxStamina;
    }

    //현재 스테미나 충전 시간
    public float GetStaminaTime()
    {
        return CurStaminaTime;
    }
    //현재 스테미나 충전시간 설정
    public void SetStaminaTime(float time)
    {
        CurStaminaTime = time;
    }

}
