using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject WeaponPos;
    
    Animator _animator;
    Animator _weaponAnimator;
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;

    float Speed = 5f;
    float JumpPower = 400f;
    Vector3 _spawnPos = new Vector3(-31f, -0.5f, 0f);

    public bool Flip
    {
        get { return _spriteRenderer.flipX; }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _weaponAnimator = WeaponPos.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(h, 0, 0);
        _animator.SetFloat(Define.SpeedHash, movement.sqrMagnitude);
        transform.Translate(movement.normalized * Speed * Time.deltaTime);
        if (h < 0 && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = false;
            FlipObject(WeaponPos);
            _weaponAnimator.SetBool(Define.FlipHash, false);
        }
        else if (h > 0 && !_spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
            FlipObject(WeaponPos);
            _weaponAnimator.SetBool(Define.FlipHash, true);
        }
        if (Mathf.Abs(_rigidbody.linearVelocityY) < 0.1f)
        {
            _animator.SetBool(Define.IsGroundHash, true);
        }
        else
        {
            _animator.SetBool(Define.IsGroundHash, false);
        }
    }

    void FlipObject(GameObject gameObject)
    {
        Vector3 scale = gameObject.transform.localScale;
        scale.x *= -1f;
        gameObject.transform.localScale = scale;
        Vector3 rotate = gameObject.transform.rotation.eulerAngles;
        rotate.z *= -1f;
        gameObject.transform.rotation = Quaternion.Euler(rotate);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _animator.GetBool(Define.IsGroundHash))
        {
            _rigidbody.AddForce(Vector2.up * JumpPower);
        }
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _weaponAnimator.SetTrigger(Define.AttackHash);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(Define.SpikeTag))
        {
            StartCoroutine(CoSpawnPlayer());
        }
    }
    
    IEnumerator CoSpawnPlayer()
    {
        yield return new WaitForSeconds(1f);
            transform.position = _spawnPos;
    }

    void Die()
    {
        _animator.SetTrigger(Define.DieHash);
    }
}
