using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Control : MonoBehaviour
{
    //플레이어 위치 저장용
    private Transform player;

    private Character_Move move;

    private void Awake()
    {
        move = GetComponent<Character_Move>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("player").transform;
    }

    private void FixedUpdate()
    {
        //플레이어 방향으로 방향설정
        Vector3 dir = (player.position - transform.position).normalized;
        move.SetDir(dir);
    }
}
