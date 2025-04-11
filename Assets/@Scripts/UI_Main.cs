using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    public Button StartButton;
    public Button ExitButton;

    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClick);
        ExitButton.onClick.AddListener(OnExitButtonClick);
    }

    void OnStartButtonClick()
    {
        SceneManager.LoadScene(Define.GameScene);
        GameManager.Instance.InitilizeInfo();
    }

    void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else 
        Application.Quit();
#endif
    }
}
