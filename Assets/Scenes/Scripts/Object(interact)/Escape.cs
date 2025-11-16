using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("player"))
        {
            //접촉시 뛰울 패널

            //=접촉패널안의 버튼 이벤트

            //==버튼 눌렀을때, if 머니 수가 할당량 이상이면,

            //===시간 멈추고 게임 클리어 패널 띄우기

            //====클리어 패널안의 버튼 이벤트2개 다시하기-씬 리로드, 게임종료 게임 콰이어트 

            //==else 할당량 아니다?

            //===시간 멈추고, 실패 패널 띄워주고, 

            //====실패패널안의 버튼 누르면 시간 다시 원복, 실패패널 비활성화
        }
    }
}
