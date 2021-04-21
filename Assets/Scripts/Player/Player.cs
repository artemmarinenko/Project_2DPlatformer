using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;

public class Player  : MonoBehaviour,IRewindable
{

    
    public float _speed = 0;

    [SerializeField]private float _jumpHeight = 4 ;

    [SerializeField]private Rigidbody2D _rigidBody;

    [SerializeField]private CollideController _CollideController;

    [SerializeField] private BoxCollider2D _boxCollider;

    

    private SpriteRenderer _renderer;

    private Animator _animator;

     void Awake()
    {
        
       _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();

        

    }

    void Start()
    {
        
    }
    private void Update()
    {
        CollideTypes typeOfUnderneathCollide = _CollideController.ColliderUnderPlayerType(this);
        //Debug.Log(typeOfUnderneathCollide);
        if (Input.GetKeyDown(KeyCode.Space) && typeOfUnderneathCollide != CollideTypes.InAir)
            _rigidBody.velocity = Vector2.up * _jumpHeight;
        

        if (typeOfUnderneathCollide == CollideTypes.Enemy)
            _rigidBody.velocity = Vector2.up * _jumpHeight*2;
    }

    void FixedUpdate()
    {
        //CollideTypes typeOfUnderneathCollide = _ColliderController.ColliderUnderPlayerType(this);
        //Debug.Log(typeOfUnderneathCollide);


        if (Input.GetKey(KeyCode.D))
        {
            _renderer.flipX = false;
            _animator.SetFloat("Speed", _speed);
            _rigidBody.position += Vector2.right * _speed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetFloat("Speed", _speed);
            _renderer.flipX = true;
            _rigidBody.position += Vector2.left * _speed * Time.fixedDeltaTime;
        }

        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }

    

    
    #region iRewindable implementation
    public BoxCollider2D GetCollider()
    {
        return _boxCollider;
    }
    public Rigidbody2D GetRigidbody()
    {
        return _rigidBody;
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
        return _rigidBody.velocity;
    }

    public Vector2 GetPosition()
    {
        return _rigidBody.position;
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
        _rigidBody.velocity = velocity;
    }

    public void SetPosition(Vector2 position)
    {
        _rigidBody.position = position;
    }

    public void SetFlip(bool flip)
    {
        _renderer.flipX = flip;
    }

    #endregion
}
