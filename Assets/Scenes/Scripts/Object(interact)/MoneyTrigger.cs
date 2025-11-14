using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTrigger : MonoBehaviour
{
    //스포너 참조용
    private Money_Spawner spawner;

    private void Awake()
    {
        //씬내에 직접 배치 안할거니까 이름으로 직접 찾자
        GameObject obj = GameObject.Find("Money_Spawner");
        spawner = obj.GetComponent<Money_Spawner>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("player"))
        {
            //풀로 반환하고,
            GameManager.Pool.ReturnPool(this);
            //스포너에 현재 스폰수 감소 알려주기
            spawner.DecreaseCount();

            Debug.Log("감소확인");
            //여기에 나중에 머니 UI쪽 갯수 증가 하는거 추가할것 
        }
    }
}
