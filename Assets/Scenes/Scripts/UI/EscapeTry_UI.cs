using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeTry_UI : MonoBehaviour
{
    public static EscapeTry_UI Instance;

    [Header("탈출시도 패널")]
    [SerializeField] private GameObject escapeTry_Panel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        escapeTry_Panel.SetActive(false);
    }

    public void ShowTryFailed()
    {
        escapeTry_Panel.SetActive(true);
        //트라이 실패 효과음
        SoundManager.Instance.PlayEffect("TryFailed_SFX");
    }
    public void HideTryFailled()
    {
        escapeTry_Panel.SetActive(false);
    }
}
