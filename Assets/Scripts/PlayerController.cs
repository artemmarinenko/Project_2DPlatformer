using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 2;

    [SerializeField]
    private float _jumpHeight = 4 ;


    [SerializeField]
    private Rigidbody2D _rBody;

    private SpriteRenderer _renderer;

    private Animator _animator;

     void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
        _rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            _rBody.velocity = Vector2.up * _jumpHeight;
        }
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D)) {
             _renderer.flipX = false;
            _animator.SetFloat("Speed", _speed);
            _rBody.position += Vector2.right * _speed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.A)) {
            _animator.SetFloat("Speed", _speed);
            _renderer.flipX = true;
            _rBody.position += Vector2.left * _speed * Time.fixedDeltaTime;
        }
        
        else
        {
            _animator.SetFloat("Speed", 0);
        }
        
    }
}
