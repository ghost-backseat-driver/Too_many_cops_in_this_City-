using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//현재 추가된것
//+단순이동 WASD+월드기준 이동으로 작성하니까, 카메라 들어오자마자 터져버려..
//++카메라 기준으로 이동 방식 
public class Player_Control : MonoBehaviour
{
    private Character_Move move;

    //++
    [Header("이동에 관여하는 카메라-위치 딸거야")]
    [SerializeField] private Transform camTransform;

    private void Awake()
    {
        move = GetComponent<Character_Move>();
    }

    private void Update()
    {
        moveInput();
    }

    //이동 입력 처리 함수++카메라 기준(카메라 꼭 붙어있어야함)
    private void moveInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //키 입력 방향
        Vector3 inputDir = new Vector3(horizontal, 0.0f, vertical).normalized;

        //++
        //카메라가 바라보는 방향 기준으로 변환
        Vector3 camForward = camTransform.forward;
        Vector3 camRight = camTransform.right;

        //카메라 위아래 기울기는 무시, XZ축만 반영
        camForward.y = 0.0f;
        camRight.y = 0.0f;
        camForward.Normalize();
        camRight.Normalize();

        //최종이동방향 계산 캠포워드는 Z축관련, 캠라이트는 X축관련
        Vector3 moveDir = (camForward * inputDir.z + camRight *inputDir.x).normalized;

        //방향값 전달
        move.SetDir(moveDir);
    }
}
