using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Core : MonoBehaviour
{
    //리지드 대신 컨트롤러 한번 써보자 
    public CharacterController controller { get; private set; }
    public Animator anim { get; private set; }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
}
