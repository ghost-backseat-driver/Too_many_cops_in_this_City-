using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Control : MonoBehaviour
{
    //플레이어 위치 저장용
    private Transform player;

    private Character_Move move;

    //스포너 참조용
    private Enemy_Spawner spawner;

    private void Awake()
    {
        move = GetComponent<Character_Move>();
        //씬내에 직접 배치 안할거니까 이름으로 직접 찾자
        GameObject obj = GameObject.Find("Cop_Spawner");
        spawner = obj.GetComponent<Enemy_Spawner>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("player").transform;
    }

    private void FixedUpdate()
    {
        //플레이어 방향으로 방향설정
        Vector3 dir = (player.position - transform.position).normalized;
        move.SetDir(dir);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("player"))
        {
            //풀로 반환하고,
            GameManager.Pool.ReturnPool(this);
            //스포너에 현재 스폰수 감소 알려주기
            spawner.DecreaseCount();
            //UI에 추가
            MoneyUI.Instance.stealedMoney();
            //충돌 사운드 추가할것

            //충돌 FX 추가 할 것

            //머니카운트 토탈 카운트 나눠서, 토탈카운트 0미만때 충돌시 게임오버 조건 넣을것
            if (MoneyUI.Instance.moneyCount < 0)
            {
                Debug.Log("게임오버");
                GameOver_UI.Instance.ShowGameOver();
            }
        }
    }
}
