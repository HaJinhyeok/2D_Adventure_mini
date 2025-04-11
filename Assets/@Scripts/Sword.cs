using UnityEngine;

public class Sword : MonoBehaviour
{
    Transform _parent;

    void Start()
    {
        _parent = GetComponentInParent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Define.EnemyTag))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.Score++;
        }
    }
}
