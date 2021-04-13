using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;

public class Player  : MonoBehaviour,iRewindable
{

    
    public float _speed = 0;

    [SerializeField]
    private float _jumpHeight = 4 ;


    [SerializeField]
    private Rigidbody2D _rBody;

    public SpriteRenderer _renderer { get; private set; }

    public Animator _animator { get; private set; }

     void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
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

    
}
