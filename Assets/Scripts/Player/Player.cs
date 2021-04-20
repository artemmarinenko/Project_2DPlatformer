using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;

public class Player  : MonoBehaviour,IRewindable
{

    
    public float _speed = 0;

    [SerializeField]
    private float _jumpHeight = 4 ;


    [SerializeField]
    private Rigidbody2D _rBody;

    private SpriteRenderer _renderer;

    private Animator _animator;

     void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rBody.velocity = Vector2.up * _jumpHeight;
        }
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D))
        {
            _renderer.flipX = false;
            _animator.SetFloat("Speed", _speed);
            _rBody.position += Vector2.right * _speed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetFloat("Speed", _speed);
            _renderer.flipX = true;
            _rBody.position += Vector2.left * _speed * Time.fixedDeltaTime;
        }

        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }

    
    #region iRewindable implementation
    public Rigidbody2D GetRigidbody()
    {
        return _rBody;
    }

    public bool GetFlip()
    {
        return _renderer.flipX;
    }
    public Animator GetAnimator()
    {
        return _animator;
    }

    public Vector2 GetVelocity()
    {
        return _rBody.velocity;
    }

    public Vector2 GetPosition()
    {
        return _rBody.position;
    }

    public float GetSpeed()
    {
        return GetAnimator().GetFloat("Speed");
    }

    public void SetSpeed(float speed)
    {
        GetAnimator().SetFloat("Speed",speed);
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rBody.velocity = velocity;
    }

    public void SetPosition(Vector2 position)
    {
        _rBody.position = position;
    }

    public void SetFlip(bool flip)
    {
        _renderer.flipX = flip;
    }

    #endregion
}
