using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear_UI : MonoBehaviour
{
    public static GameClear_UI Instance;

    [Header("게임클리어 패널, 버튼")]
    [SerializeField] private GameObject GameClear_Panel;
    [SerializeField] private Button GameQuit_Button;

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
        GameClear_Panel.SetActive(false);
        GameQuit_Button.onClick.AddListener(QuitGame);
    }

    private void OnDestroy()
    {
        GameQuit_Button.onClick.RemoveListener(QuitGame);
    }

    public void ShowGameClear()
    {
        GameClear_Panel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void QuitGame()
    {
        Time.timeScale = 1.0f;
        Debug.Log("클릭완료");
        Application.Quit();
    }
}
