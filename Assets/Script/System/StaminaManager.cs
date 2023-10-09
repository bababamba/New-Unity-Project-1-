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
            //�ӽ� �ڵ� ���׹̳� ������
            StaminaUp(10);
        }
    }
    //���׹̳� ���� �ÿ� ���
    public void StaminaUp(int value)
    {
        CurStamina += value;
        if (CurStamina > MaxStamina)
        {
            CurStamina = MaxStamina;
            CurStaminaTime = MaxStaminaTime;
        }
    }
    //���׹̳� ���ҽ�, �����Ͽ��� ���� 0 �̸����� üũ
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
    //���׹̳� ���� �� �� �Լ��� �Բ� ���
    public void StaminaDown(int value)
    {
        CurStamina -= value;
    }
    //���� ���׹̳� ��
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

    //���� ���׹̳� ���� �ð�
    public float GetStaminaTime()
    {
        return CurStaminaTime;
    }
    //���� ���׹̳� �����ð� ����
    public void SetStaminaTime(float time)
    {
        CurStaminaTime = time;
    }

}
