using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [Header("마우스 회전도")] //나중에 환결설정 넣을때 써먹으려면 약간의 수정 필요
    [SerializeField] private float mouseSensitivity = 10.0f;

    [Header("카메라 위아래 회전 최소값")]
    [SerializeField] private float camY_MinRota = -30.0f;

    [Header("카메라 위아래 회전 최대값")]
    [SerializeField] private float camY_maxRota = 60.0f;

    //카메라 좌우 회전값 저장용
    private float camXRota;
    //카메라 상하 회전값 저장용
    private float camYRota; 

    private void Start()
    {
        //오일러각 주의
        //초기 회전값 세팅 //마우스가 위로 올라갈때 X가 바뀜! Y도 마찬가지인거 인지하고 있을것
        Vector3 angles = transform.eulerAngles;
        camXRota = angles.y;
        camYRota = angles.x;
    }

    private void LateUpdate()
    {
        mouseInput();
        ApplyRotation();
    }

    //마우스 입력->캠 회전값에 넣어줄 함수
    private void mouseInput()
    {
        //마우스 입력 값 가져오기
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //회전값 계산
        camXRota += mouseX * mouseSensitivity;
        camYRota -= mouseY * mouseSensitivity;

        //상하 회전 제한
        camYRota = Mathf.Clamp(camYRota, camY_MinRota, camY_maxRota);
    }

    //계산된 회전값 적용함수
    private void ApplyRotation()
    {
        transform.rotation = Quaternion.Euler(camYRota, camXRota, 0.0f);
    }
}
