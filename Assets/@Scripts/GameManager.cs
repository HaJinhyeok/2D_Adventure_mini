using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gameObject = GameObject.Find("@Managers");
                if (gameObject == null)
                {
                    gameObject = new GameObject("@Managers");
                    DontDestroyOnLoad(gameObject);
                }
                _instance = GameObject.FindAnyObjectByType<GameManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    GameManager component = obj.AddComponent<GameManager>();
                    obj.transform.parent = gameObject.transform;
                    _instance = component;
                }
            }
            return _instance;
        }
    }
    #endregion

    // player score
    int _score = 0;
    public int Score
    {
        get { return _score; }
        set { _score = value; UI_Game.OnScoreAction?.Invoke(); }
    }

    // player hp
    int _hp = 3;
    public int HP
    {
        get { return _hp; }
        set
        {
            _hp = value;
            UI_Game.OnHpAction?.Invoke();
            if (_hp <= 0)
            {
                UI_Game.OnFailAction?.Invoke();
            }
        }
    }

    public void InitilizeInfo()
    {
        _hp = Define.PlayerMaxHp;
        _score = 0;
    }

}
