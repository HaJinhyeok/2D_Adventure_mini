using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float _speed = 2f;
    int _groundLayer;
    Vector3 _direction = Vector3.right;
    SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _groundLayer = 1 << 6;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
            //Debug.DrawRay(transform.position + _direction + Vector3.up, Vector3.down);
        //RaycastHit2D hit;
        if (!Physics2D.Raycast(transform.position + _direction, Vector3.down, 2f, _groundLayer) || Physics2D.Raycast(transform.position, _direction, 1f, _groundLayer))
        {
            _direction *= -1f;
            if (_direction.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_direction.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
        }
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Define.PlayerTag))
        {
            GameManager.Instance.HP--;
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag(Define.PlayerTag))
    //    {
    //        GameManager.Instance.HP--;
    //        Destroy(gameObject);
    //    }
    //}
}
