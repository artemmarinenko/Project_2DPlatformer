using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    
    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private bool IsMoving = false;
    private SpriteRenderer _spriteRenderer;
    


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()

    {
        Debug.DrawRay(_boxCollider.bounds.center, Vector2.right * (_boxCollider.bounds.extents.x + 0.15f), Color.red);

       // isColliderFaced();
         
        
        if (IsMoving&&_spriteRenderer.flipX) {

            _rigidBody.velocity = Vector2.left*1.2f;
           // if (isColliderFaced()) { _spriteRenderer.flipX = true; }
        }
        else if (IsMoving && !_spriteRenderer.flipX) {
            _rigidBody.velocity = Vector2.right * 1.2f;
          //  if (isColliderFaced()) { _spriteRenderer.flipX = false; }
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
        }
    }

    public void ZombieStepStart()
    {
        IsMoving = true;
        Debug.Log("Debug1");
        
    }

    public void ZombieStepFin()
    {
        IsMoving = false;
        Debug.Log("Debug2");
       
    }

    private bool isColliderFaced()
    {
        
        RaycastHit2D raycastHit = Physics2D.Raycast(_boxCollider.bounds.center, _rigidBody.transform.forward, 5f);
        
        Color rayColor;

        //Debug.DrawRay(_boxCollider.bounds.center,transform.TransformDirection(transform.forward)*5f,Color.red);
        
        return raycastHit.collider != null; 
    }

}
