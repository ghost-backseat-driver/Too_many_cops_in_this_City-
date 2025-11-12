using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Core : MonoBehaviour
{
    public Rigidbody rb { get; private set; }
    public Animator anim { get; private set; }
    public SkinnedMeshRenderer skinnedMeshRenderer { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
}
