using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    private Character_Move move;

    [Header("메인 가상 카메라 연결")]
    [SerializeField] private Transform Vcam_Main;

    private void Awake()
    {
        move = GetComponent<Character_Move>();
    }

    private void Update()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) dir += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) dir += Vector3.back;
        if (Input.GetKey(KeyCode.A)) dir += Vector3.left;
        if (Input.GetKey(KeyCode.D)) dir += Vector3.right;

        //카메라 기준으로 이동방향 변환
        if (dir != Vector3.zero)
        {
            //카메라 z축 방향 선언해주고
            Vector3 camForward = Vcam_Main.forward;
            //카메라 y축방향 없애주고
            camForward.y = 0.0f;
            //카메라 x축 방향 선언
            Vector3 camRight = Vcam_Main.right;
            //여기도 y축 잠구고
            camRight.y = 0.0f;

            dir = (camForward * dir.z + camRight * dir.x).normalized;
        }

        //move 쪽에 입력방향 전달
        move.SetDir(dir);
    }
}
