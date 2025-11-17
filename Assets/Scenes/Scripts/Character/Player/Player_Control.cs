using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//현재 추가된것
//+단순이동 WASD+월드기준 이동으로 작성하니까, 카메라 들어오자마자 터져버려..
//++카메라 기준으로 이동 방식 
public class Player_Control : MonoBehaviour
{
    private Character_Move move;
    //++점프중일때 걷는소리 막기위한 참조
    private Player_Jump jump;

    //++
    [Header("이동에 관여하는 카메라-위치 딸거야")]
    [SerializeField] private Transform camTransform;

    [Header("발소리 제어용-소리간격")]
    [SerializeField] private float stepSoundInterval = 1.0f;
    private float stepControlTime = 0.0f;

    //++발소리 제어할때 쓰일 입력값 저장용 
    private Vector3 curInputDir;

    private void Awake()
    {
        move = GetComponent<Character_Move>();
        jump = GetComponent<Player_Jump>();
    }

    private void Update()
    {
        moveInput();
        FootStepSound();
    }

    //이동 입력 처리 함수++카메라 기준(카메라 꼭 붙어있어야함)
    private void moveInput()
    {
        //캔무브 false 상태면 입력값 무시
        if (!move.canMove)
        {
            move.SetDir(Vector3.zero);
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //키 입력 방향
        curInputDir = new Vector3(horizontal, 0.0f, vertical).normalized;

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
        Vector3 moveDir = (camForward * curInputDir.z + camRight * curInputDir.x).normalized;

        //방향값 전달
        move.SetDir(moveDir);
    }

    private void FootStepSound()
    {
        //실제 입력값이 들어가고, 캔 무브 상태일때만 걷는걸로 간주
        bool isWalking = curInputDir.magnitude > 0.1f && move.canMove;

        if (isWalking && jump.isGround)
        {
            //50프레임 속도로 컨트롤 속도 누적
            stepControlTime += Time.fixedDeltaTime;

            //누적되다가 발걸음 간격 소리를 넘어서면 재생
            if (stepControlTime >= stepSoundInterval)
            {
                SoundManager.Instance.PlayEffect("right_FootStep_SFX");
                //다시 원복 시켜주고,
                stepControlTime = 0.0f;
            }
        }
        else
        {
            //아니면 정지=원복
            stepControlTime = 0.0f;
        }
    }
}
