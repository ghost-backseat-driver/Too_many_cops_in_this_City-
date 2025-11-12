using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour
{
    private Character_Core core;

    [Header("이동 속도")]
    [SerializeField] private float moveSpeed = 1.0f;

    //입력 방향 저장용
    private Vector3 inputDir;

    //마지막 이동방향 저장용
    private Vector3 lastDir;

    //이동 가능 여부 플래그->이동불가 플래그 나중에 피격관련해서 써먹어야돼
    public bool canMove = true;

    //Animator 캐시
    private static readonly int speedHash = Animator.StringToHash("Speed");

    private void Awake()
    {
        core = GetComponent<Character_Core>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //외부에서 방향 전달해줄 용도
    public void SetDir(Vector3 dir)
    {
        inputDir = dir;
    }

    private void Move()
    {

        //이동처리
        Vector3 moveVelocity = Vector3.zero;

        //입력이 제로가 아닐때 마지막 이동방향 갱신
        if (inputDir != Vector3.zero)
        {
            lastDir = inputDir.normalized;
            moveVelocity = lastDir * moveSpeed;
        }

        core.rb.velocity = new Vector3(moveVelocity.x, core.rb.velocity.y, moveVelocity.z);

        if (lastDir != Vector3.zero)
        {
            //이동 방향으로 캐릭터 회전
            Quaternion rotation = Quaternion.LookRotation(lastDir);
            core.rb.MoveRotation(Quaternion.Slerp(core.rb.rotation, rotation, 5.0f * Time.fixedDeltaTime));
        }

        //애니메이션 속도값 갱신
        core.anim.SetFloat(speedHash, inputDir.magnitude*moveSpeed);
    }
}
