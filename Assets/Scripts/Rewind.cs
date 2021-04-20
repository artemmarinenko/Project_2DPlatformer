using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TimeControll {
    public interface IRewindable
    {
        Animator GetAnimator();

        bool GetFlip();

        Rigidbody2D GetRigidbody();

        Vector2 GetVelocity();

        Vector2 GetPosition();

        float GetSpeed();

        void SetSpeed(float speed);

        void SetVelocity(Vector2 velocity);

        void SetPosition(Vector2 position);

        void SetFlip(bool flip);

    }
    public class TimePoint
    {
        private Vector2 _position;

        private Vector2 _velocity;

        private float _speed;

        private bool _flipX;
        
        

        public TimePoint(Vector2 position, Vector2 velocity,float speed, bool flipX )
        {
            _position = position;
            _velocity = velocity;
            _speed = speed;
            _flipX = flipX;

            
        }

        public static  void SetTimePoint(IRewindable player,TimePoint timePoint)
        {
            player.SetPosition(timePoint._position);
            player.SetVelocity(timePoint._velocity);
            player.SetFlip(timePoint._flipX);
            player.SetSpeed(timePoint._speed);


        }


    }

    public class Rewind : MonoBehaviour
    {
        [SerializeField]
        private int _timeMeasure;

        private LinkedList<TimePoint> _timePoints = new LinkedList<TimePoint>();

        private Rigidbody2D _rBody;

        private IRewindable _player;


        private  bool isRewinding = false;
     
        void Awake()
        {

            _player = GetComponent<IRewindable>();

        }

        

        private void Update()
        {

            if (Input.GetKey(KeyCode.R))
            {
                isRewinding = true;

            }
            else
            {
                isRewinding = false;
                
            }



        }
        void FixedUpdate()
        {
            if (isRewinding) {
                TimeRewind();
                
            }
            else {
                RecordTimePoints();
                
            }
            
        }
        public void TimeRewind()
        {

            if (_timePoints.Count != 0) { 

            TimePoint.SetTimePoint(_player, _timePoints.Last.Value);

            _timePoints.RemoveLast(); 

                }

            else {
                isRewinding = false;
                }
        }

        public void RecordTimePoints()
        {
            
            if (_timePoints.Count >= _timeMeasure) {
                _timePoints.RemoveFirst();
                
            }
            _timePoints.AddLast(new TimePoint(
                _player.GetPosition(),
                _player.GetVelocity(),
                _player.GetSpeed(),
                _player.GetFlip()));
        }
    }
}


