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
    


    // Start is called before the first frame update
    void Start()
    {
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
        if (isColliderFaced()) { _spriteRenderer.flipX = !_spriteRenderer.flipX; }
        
  
        if (IsMoving && _spriteRenderer.flipX) {

            _rigidBody.velocity = Vector2.left * 1.2f;
            //Debug.DrawRay(_boxCollider.bounds.center, Vector2.left * (_boxCollider.bounds.extents.x + 0.15f), Color.red);
            
        }
        else if (IsMoving && !_spriteRenderer.flipX) {


            _rigidBody.velocity = Vector2.right * 1.2f;
            //Debug.DrawRay(_boxCollider.bounds.center, Vector2.right * (_boxCollider.bounds.extents.x + 0.15f), Color.red);
            
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

    private bool isColliderFaced()

    {
        RaycastHit2D raycastHit = new RaycastHit2D();

        if (_spriteRenderer.flipX == false)
        {
             raycastHit = Physics2D.Raycast(_boxCollider.bounds.center, Vector2.right, _boxCollider.bounds.extents.x + 0.15f, LayerMask.GetMask(new string[] { "Tilemap" }));
        }
        else
        {
             raycastHit = Physics2D.Raycast(_boxCollider.bounds.center, Vector2.left, _boxCollider.bounds.extents.x + 0.15f, LayerMask.GetMask(new string[]{ "Tilemap"}));
        }

        //Debug.DrawRay(_boxCollider.bounds.center,transform.TransformDirection(transform.forward)*5f,Color.red);

        //Debug.Log (raycastHit.collider != null);
        return raycastHit.collider != null; 
    }

    #region iRewindable Implementation
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

    #endregion
}
