using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
}
