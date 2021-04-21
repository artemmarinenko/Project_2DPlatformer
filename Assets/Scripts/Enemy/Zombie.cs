using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeControll;

public class Zombie : MonoBehaviour, IRewindable
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private bool IsMoving = true;
    private SpriteRenderer _spriteRenderer;
    [SerializeField]private CollideController _collideController;
    


    // Start is called before the first frame update
    void Start()
    { // First custom game event
        //GameEvent.OnPlayerDamageDone += StopMovingZombie;

        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()

    {
        if (_collideController.ColliderFaced(this, LayerMask.GetMask(new string[] { "Default" })) == CollideTypes.Player) {
            //StopMovingZombie();
            GameEvent.RaiseOnPlayerDamageDone();
        }
            

        if (_collideController.ColliderFaced(this, LayerMask.GetMask(new string[] { "Tilemap" })) == CollideTypes.Ground) 
            { _spriteRenderer.flipX = !_spriteRenderer.flipX; }
        
  
        if (IsMoving && _spriteRenderer.flipX) {

            _rigidBody.velocity = Vector2.left * 1.2f;
           // Debug.DrawRay(_boxCollider.bounds.center, Vector2.left * (_boxCollider.bounds.extents.x + 0.15f), Color.red);
            
        }
        else if (IsMoving && !_spriteRenderer.flipX) {


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
        //Debug.Log("Debug1");
        
    }

    public void ZombieStepFin()
    {
        IsMoving = false;
        //Debug.Log("Debug2");
       
    }

    private void StopMovingZombie()
    {
        //_animator.SetFloat("Speed", -1);
        //IsMoving = false;
        //_rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        
        
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
        return _rigidBody.position;
    }

    public float GetSpeed()
    {
        return _animator.GetFloat("Speed");
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed",speed);
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

    #endregion
}
