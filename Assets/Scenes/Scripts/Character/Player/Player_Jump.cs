using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이번에는 입력까지 점프에 몰아넣자. 컨트롤쪽에 굳이 둘 필요도 없을것같아. 공용도 아니니까
//일단 애니메이션 먼저 집어넣고 시작
//포스모드 임펄스로 밀어내는 식으로 
//바닥체크 할 레이 필요하고
public class Player_Jump : MonoBehaviour
{
    private Rigidbody rb;
    private Character_Core core;

    [Header("점프 힘 설정")]
    [SerializeField] private float jumpForce = 1.0f;

    [Header("지면 체크 거리")]
    [SerializeField] private float groundCheckDistance = 0.15f;

    [Header("지면 판정->그라운드 레이어")]
    [SerializeField] private LayerMask groundLayer;

    //땅 체크 플래그
    private bool isGround = false;

    //점프 입력 키 지정
    private KeyCode jumpKey = KeyCode.Space;

    //Animator 캐시 점프용
    private static readonly int jumpHash = Animator.StringToHash("isJump");

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        core = GetComponent<Character_Core>();
    }

    private void Update()
    {
        //항상 지면 체크 먼저
        CheckGround();

        //점프 입력 들어오면
        if (Input.GetKeyDown(jumpKey))
        {
            //트라이점프 함수 호출
            TryJump();
        }

        core.anim.SetBool(jumpHash, !isGround);
    }

    //바닥 판정 레이캐스트
    private void CheckGround()
    {
        //transform.position 기준으로 아래 방향으로 레이쏘자
        isGround = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    //트라이 점프 함수-점프로직
    private void TryJump()
    {
        //땅 아니면 무시
        if (!isGround) return;

        //기존 수직 속도 초기화
        Vector3 curVeloclty = rb.velocity;
        curVeloclty.y = 0.0f;
        rb.velocity = curVeloclty;

        //위로 포스모드 임펄스
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    //레이 확인용 드로우기즈모
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isGround ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
