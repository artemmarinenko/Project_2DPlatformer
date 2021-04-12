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


         
        
        if (IsMoving&&!_spriteRenderer.flipX) {

            _rigidBody.velocity = Vector2.right*1.2f;
            if (isColliderFaced()) { _spriteRenderer.flipX = true; }
        }
        else if (IsMoving && _spriteRenderer.flipX) {
            _rigidBody.velocity = Vector2.left * 1.2f;
            if (isColliderFaced()) { _spriteRenderer.flipX = false; }
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
        // _rigidBody.gameObject.GetComponent<Collider2D>().enabled = false;
       // _rigidBody.velocity = Vector2.right * 2;
        //_rigidBody.AddForce(Vector2.right, ForceMode2D.Impulse);
    }

    public void ZombieStepFin()
    {
        IsMoving = false;
        Debug.Log("Debug2");
        //_rigidBody.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    private bool isColliderFaced()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, _rigidBody.transform.forward, 1f, default);
        Color rayColor;

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        
        
        return raycastHit.collider != null; ;
    }

}
