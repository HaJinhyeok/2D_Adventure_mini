using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    public Text ScoreText;
    public Image HpImage;
    public GameObject ClearPanel;
    public GameObject FailPanel;
    public Button[] ExitButtons;

    public static Action OnScoreAction;
    public static Action OnHpAction;
    public static Action OnClearAction;
    public static Action OnFailAction;

    void Start()
    {
        ScoreText.text = $"Score : {GameManager.Instance.Score}";
        HpImage.fillAmount = GameManager.Instance.HP / (float)Define.PlayerMaxHp;
        OnScoreAction += OnScoreChanged;
        OnHpAction += OnHpChanged;
        OnClearAction += OnGameClear;
        OnFailAction += OnGameFail;
        for (int i = 0; i < ExitButtons.Length; i++)
        {
            ExitButtons[i].onClick.AddListener(OnExitButtonClick);
        }
        ClearPanel.SetActive(false);
        FailPanel.SetActive(false);
    }

    void OnScoreChanged()
    {
        ScoreText.text = $"Score : {GameManager.Instance.Score}";
    }

    void OnHpChanged()
    {
        HpImage.fillAmount = GameManager.Instance.HP / (float)Define.PlayerMaxHp;
    }

    void OnGameClear()
    {
        Time.timeScale = 0f;
        ClearPanel.SetActive(true);
    }

    void OnGameFail()
    {
        Time.timeScale = 0f;
        FailPanel.SetActive(true);
    }

    void OnExitButtonClick()
    {
        SceneManager.LoadScene(Define.MainScene);
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        OnScoreAction -= OnScoreChanged;
        OnHpAction -= OnHpChanged;
        OnClearAction -= OnGameClear;
        OnFailAction -= OnGameFail;
    }
}
