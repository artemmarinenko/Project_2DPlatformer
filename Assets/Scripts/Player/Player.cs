using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;
using System;

public class Player  : MonoBehaviour,IRewindable
{

    
    public float _speed = 0;

    
    
    [SerializeField]private float _jumpHeight = 4 ;

   

    [SerializeField]private CollideController _CollideController;

    private Rigidbody2D _rigidBody;

    private BoxCollider2D _boxCollider;

    private bool _isAlive = true;

    private SpriteRenderer _renderer;

    private Animator _animator;

    private Rewind _rewindComponent;

     void Awake()
    {
        GameEvent.onPlayerDamageDone += PlayerOnDeathHandler;
        
       _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rewindComponent = GetComponent<Rewind>();

     
    }

    void Start()
    {
        
    }
    private void Update()
    {
        if (_isAlive) {

            Tuple<CollideTypes,Collider2D> typeOfUnderneathCollide = _CollideController.ColliderUnderPlayerType(this, LayerMask.GetMask(new string[] { "Enemy", "Tilemap" }));
            //Debug.Log(typeOfUnderneathCollide);
            if (Input.GetKeyDown(KeyCode.Space) && typeOfUnderneathCollide.Item1 != CollideTypes.InAir)
                _rigidBody.velocity = Vector2.up * _jumpHeight;


            if (typeOfUnderneathCollide.Item1 == CollideTypes.Enemy) {
                _rigidBody.velocity = Vector2.up * _jumpHeight * 2;
                GameEvent.RaiseOnZombieDamageDone(typeOfUnderneathCollide.Item2);
            }

            if (typeOfUnderneathCollide.Item1 == CollideTypes.Spike)
                GameEvent.RaiseOnPlayerDamageDone();
                
        }

        
    }

    void FixedUpdate()
    {
        //CollideTypes typeOfUnderneathCollide = _ColliderController.ColliderUnderPlayerType(this);
        //Debug.Log(typeOfUnderneathCollide);
        if (_isAlive) {

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

        

        
    }

    private void PlayerOnDeathHandler()
    {
        //isAlive = false;
        //_animator.SetFloat("Speed", 0);
        _animator.SetBool("DamageDone", true);
        _rigidBody.velocity = Vector2.up * _jumpHeight;
        
        //_rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }



    #region iRewindable implementation
    public bool GetAliveStatus()
    {
        return _isAlive;
    }
    public bool GetDamageStatus()
    {
        return _animator.GetBool("DamageDone");
    }
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

   public void SetDamageStatus(bool damageStatus)
    {
        _animator.SetBool("DamageDone", damageStatus);
    }

    

    public void SetAliveStatus(bool isAlive)
    {
        _isAlive = isAlive ;
    }

    #endregion
}
