using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleStart : MonoBehaviour
{
    [Header("시작 버튼 눌리면 비활성화 될 캔버스/카메라")]
    [SerializeField] private GameObject titleCanvas;
    [SerializeField] private GameObject titleCam;

    [Header("시작 버튼 눌리면 활성화될 캔버스")]
    [SerializeField] private GameObject canvasGroup;

    [Header("시작 버튼")]
    [SerializeField] private Button startButton;

    //움직임 멈출 플레이어 오브젝트 참조용
    [SerializeField] private Character_Move playerObject;

    private void Start()
    {
        startButton.onClick.AddListener(GameStart);
        //여기에 플레이어 움직임 멈추고
        playerObject.canMove = false;
    }
    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(GameStart);
    }

    private void GameStart()
    {
        //여기에서 플레이어 움직임 풀어주고,
        playerObject.canMove = true;
        //비활성화 할거
        titleCanvas.SetActive(false);
        titleCam.SetActive(false);

        //활성화 할거
        canvasGroup.SetActive(true);
    }
}
