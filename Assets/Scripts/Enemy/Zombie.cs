using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;
using System;

public class Zombie : MonoBehaviour, IRewindable, IResettable
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;

    private bool IsMoving = true;
    private bool _isAlive = true;
    private bool _keyStatus = false;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _startingPoint;
    private bool _startingFlip;
    [SerializeField] private CollideController _collideController;
    



  
    void Start()
    { 
       
        GameEvent.onZombieDamageDone += ZombieDead;

        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        //SetSpeed(_speed);
        SetStartPoint(GetPosition(), GetFlip());

    }

   
    void Update()
    {

    }

    private void FixedUpdate()

    {
        if (_isAlive)
            _rigidBody.gameObject.layer = LayerMask.NameToLayer("Enemy");


        if (_collideController.ColliderFaced(this, LayerMask.GetMask(new string[] { "Default" })) == CollideTypes.Player)
        {
            GameEvent.RaiseOnPlayerDamageDone();
        }


        if (_collideController.ColliderFaced(this, LayerMask.GetMask(new string[] { "Tilemap" })) == CollideTypes.Ground)
        { _spriteRenderer.flipX = !_spriteRenderer.flipX; }


        if (IsMoving && _spriteRenderer.flipX)
        {

            _rigidBody.velocity = Vector2.left * 1.2f;
            // Debug.DrawRay(_boxCollider.bounds.center, Vector2.left * (_boxCollider.bounds.extents.x + 0.15f), Color.red);

        }
        else if (IsMoving && !_spriteRenderer.flipX)
        {


            _rigidBody.velocity = Vector2.right * 1.2f;
            // Debug.DrawRay(_boxCollider.bounds.center, Vector2.right * (_boxCollider.bounds.extents.x + 0.15f), Color.red);

        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }
    }

    public void ZombieStepStart()
    {
        IsMoving = true;
        

    }

    public void ZombieStepFin()
    {
        IsMoving = false;
        

    }

    private void ZombieDead(Collider2D zombie)
    {
        IRewindable irewindableZombie = zombie.GetComponent<IRewindable>();
       
        irewindableZombie.SetVelocity(Vector2.up * 5);
        irewindableZombie.SetDamageStatus(true);
        irewindableZombie.GetRigidbody().gameObject.layer = LayerMask.NameToLayer("EnemyAfterDeath");
        irewindableZombie.SetAliveStatus(false);


        


    }

    #region iRewindable Implementation

    public bool GetDamageStatus()
    {
        return _animator.GetBool("DamageDone");
    }
    public BoxCollider2D GetCollider()
    {
        return _boxCollider;
    }

    public Animator GetAnimator()
    {
        return _animator;
    }

    public bool GetFlip()
    {
        return _spriteRenderer.flipX;
    }

    public Rigidbody2D GetRigidbody()
    {
        return _rigidBody;
    }

    public Vector2 GetVelocity()
    {
        return _rigidBody.velocity;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public float GetSpeed()
    {
        return _animator.GetFloat("Speed");
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
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
        _spriteRenderer.flipX = flip;
    }



    public void SetDamageStatus(bool damageStatus)
    {
        _animator.SetBool("DamageDone", damageStatus);
    }

    public bool GetAliveStatus()
    {
        return _isAlive;
    }

    public void SetAliveStatus(bool isAlive)
    {
        _isAlive = isAlive;
    }


    
    public bool GetKeyStatus()
    {
        return _keyStatus;
    }

    public void SetKeyStatus(bool keySatus)
    {
        _keyStatus = keySatus;
    }



    #endregion

    #region IResettable implementation
    public void Reset()
    {
        SetPosition(GetStartPoint().Item1);
        SetFlip(GetStartPoint().Item2);
        SetDamageStatus(false);
        SetAliveStatus(true);
        
    }

    public void SetStartPoint(Vector2 postion,bool flip)
    {
        _startingPoint = postion;
        _startingFlip = flip;
    }

    public Tuple<Vector2,bool> GetStartPoint()
    {
        return Tuple.Create(_startingPoint, _startingFlip);
    }
    #endregion
}
