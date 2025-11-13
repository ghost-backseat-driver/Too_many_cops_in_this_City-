using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Character_Move : MonoBehaviour
{
    private Character_Core core;

    [Header("이동 속도")]
    [SerializeField] private float moveSpeed = 1.0f;

    //입력 방향 저장용
    private Vector3 inputDir;

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

    //이동로직-공용-
    private void Move()
    {
        //canMove = true; //다시 풀어줄 용도 필요한거 인지
        Vector3 velocity = inputDir * moveSpeed;

        core.rb.velocity = new Vector3(velocity.x, core.rb.velocity.y, velocity.z);

        //이동속도에 따른 애니메이션 갱신
        core.anim.SetFloat(speedHash, inputDir.magnitude * moveSpeed);

        //==이동방향에 맞게 플레이어가 회전==하는 로직//2D에서의 플립을 생각해
        if (inputDir.magnitude > 0.01f)
        {
            Quaternion CharacterRotation = Quaternion.LookRotation(inputDir);
            core.rb.MoveRotation(Quaternion.Slerp(core.rb.rotation, CharacterRotation, 5.0f * Time.fixedDeltaTime));
        }
    }

    public void Stop()
    {
        //canMove = false; 일단 넣어놓고 후에 수정
        core.rb.velocity = Vector3.zero;
        SetDir(Vector3.zero);
    }
}
