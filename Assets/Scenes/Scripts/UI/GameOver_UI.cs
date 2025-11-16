using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour
{
    public static GameOver_UI Instance;

    [Header("게임오버 패널, 버튼")]
    [SerializeField] private GameObject gameOver_Panel;
    [SerializeField] private Button restart_Button;

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
        gameOver_Panel.SetActive(false);
        restart_Button.onClick.AddListener(RestartGame);
    }

    private void OnDestroy()
    {
        restart_Button.onClick.RemoveListener(RestartGame);
    }

    public void ShowGameOver()
    {
        gameOver_Panel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void RestartGame()
    {
        Time.timeScale = 1.0f;
        Debug.Log("클릭완료");
        SceneManager.LoadScene("SampleScene");
    }
}
