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
        //bgm멈추고
        SoundManager.Instance.StopBGM();
        //게임 클리어 효과음
        SoundManager.Instance.PlayEffect("Escape_SFX");
        GameClear_Panel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void QuitGame()
    {
        Time.timeScale = 1.0f;
        //버튼 효과음
        SoundManager.Instance.PlayEffect("buttonPress_SFX");

        Application.Quit();
    }
}
