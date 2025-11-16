using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{

    public static MoneyUI Instance;

    //머니 누적용
    public int moneyCount = 0;
    //머니 갯수 표시용
    public TMP_Text moneyCountText;

    private void Awake()
    {
        //싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateMoneyUI();
    }

    //머니 획득시 UI 머니카운트 누적
    public void AddMoney()
    {
        moneyCount++;
        UpdateMoneyUI();
    }
    //돈 뺏길때 UI 키카운트 감소 -임시
    public void stealedMoney()
    {
        //돈 뺏길때 일단 임시
        moneyCount--;
        UpdateMoneyUI();
    }

    //UI에 표시
    public void UpdateMoneyUI()
    {
        if (moneyCountText != null)
            moneyCountText.text = moneyCount.ToString();
    }
}
