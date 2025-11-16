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
    }
    public void HideTryFailled()
    {
        escapeTry_Panel.SetActive(false);
    }
}
