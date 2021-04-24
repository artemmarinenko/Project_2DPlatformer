using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorsKeySystem {

    public enum Colors
    {
        Yellow,
        Green,
        Blue,
        Red
    }



    public class Door: MonoBehaviour
    {
        [SerializeField] private Colors _doorColor;
         private Animator _animator;
        // Start is called before the first frame update
        void Awake()
        {
            _animator = GetComponent<Animator>();
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                Player player = collision.gameObject.GetComponent<Player>();
                player.GetKeyOnPlayer().GetKeyColor();
                if (player.GetKeyStatus() && (player.GetKeyOnPlayer().GetKeyColor() ==_doorColor))
                {
                    _animator.SetBool("isOpen", true);
                    GameEvent.RaiseOnDoorOpened(_doorColor);
                }
            }
        }

    }
}



