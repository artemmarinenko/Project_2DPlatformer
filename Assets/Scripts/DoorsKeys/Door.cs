using System;
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



    public class Door: MonoBehaviour, IResettableDoor
    {
        [SerializeField] private Colors _doorColor;
         private Animator _animator;

        private Vector2 _startingPoint;
        private DoorsKeySystem.Colors _startingColor;

        // Start is called before the first frame update
        void Awake()
        {
            _animator = GetComponent<Animator>();
            SetStartState(transform.position, _doorColor);
            
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
        #region IresettableKeyDoor
        public void Reset(Door doorPrefab)
        {
            Destroy(this.gameObject);
            Door newKey = Instantiate(doorPrefab, GetStartState().Item1, Quaternion.identity);
            
        }

        public void SetStartState(Vector2 postion, Colors color)
        {
            _startingPoint = postion;
            _startingColor = color;
        }

        public Tuple<Vector2, Colors> GetStartState()
        {
            return Tuple.Create(_startingPoint, _startingColor);
        }

        #endregion
    }
}



