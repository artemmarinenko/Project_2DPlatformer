using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TimeControll {
    public interface IRewindable
    {
        Animator GetAnimator();

        BoxCollider2D GetCollider();

        bool GetFlip();

        Rigidbody2D GetRigidbody();

        Vector2 GetVelocity();

        Vector2 GetPosition();

        bool GetDamageStatus();

        float GetSpeed();

        bool GetAliveStatus();

        void SetSpeed(float speed);

        void SetVelocity(Vector2 velocity);

        void SetPosition(Vector2 position);

        void SetFlip(bool flip);

        void SetDamageStatus(bool damageStatus);

        void SetAliveStatus(bool isAlive);

    }
    public class TimePoint
    {
        private Vector2 _position;

        private Vector2 _velocity;

        private float _speed;

        private bool _flipX;

        private bool _damageStatus;

        private bool _isAlive;
        
        

        public TimePoint(Vector2 position, Vector2 velocity,float speed, bool flipX, bool damageStatus,bool isAlive)
        {
            _position = position;
            _velocity = velocity;
            _speed = speed;
            _flipX = flipX;
            _damageStatus = damageStatus;
            _isAlive = isAlive;
            
        }

        public static  void SetTimePoint(IRewindable player,TimePoint timePoint)
        {
            player.SetPosition(timePoint._position);
            player.SetVelocity(timePoint._velocity);
            player.SetFlip(timePoint._flipX);
            player.SetSpeed(timePoint._speed);
            player.SetDamageStatus(timePoint._damageStatus);
            player.SetAliveStatus(timePoint._isAlive);


        }


    }

    public class Rewind : MonoBehaviour
    {
        public float _rewindMaxTime { get; set; }

        

        private LinkedList<TimePoint> _timePoints = new LinkedList<TimePoint>();

        private Rigidbody2D _rBody;

        private IRewindable _irewindableObject;

        
        

        private  bool isRewinding = false;
     
        void Awake()
        {
            
            _irewindableObject = GetComponent<IRewindable>();

        }

        

        private void Update()
        {



            if (Input.GetKey(KeyCode.R)&& _timePoints.Count != 0)
            {
                Time.timeScale = 1f;
                
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
                GameEvent.RaiseOnRewind();
            }
            else {
                RecordTimePoints();
                GameEvent.RaiseOnRecord();
            }
            
        }
        public void TimeRewind()
        {

            if (_timePoints.Count != 0) { 

            TimePoint.SetTimePoint(_irewindableObject, _timePoints.Last.Value);

            _timePoints.RemoveLast(); 

                }

            else {
                isRewinding = false;
                }
        }

        public void RecordTimePoints()
        {
            
            if (_timePoints.Count >= _rewindMaxTime) {
                _timePoints.RemoveFirst();
                
            }
            _timePoints.AddLast(new TimePoint(
                _irewindableObject.GetPosition(),
                _irewindableObject.GetVelocity(),
                _irewindableObject.GetSpeed(),
                _irewindableObject.GetFlip(),
                _irewindableObject.GetDamageStatus(),
                _irewindableObject.GetAliveStatus()
                ));
        }

        

    }
    public static class RewindUi
    {
        public static void RewindSliderEffect(Slider slider, float timeMeasure)
        {
                slider.value -= (0.5f / timeMeasure);
        }

        public static void RecordSliderEffect(Slider slider, float timeMeasure)
        {
            if (slider.value < 1)
                slider.value += (0.5f / timeMeasure);

        }
    }
    
}


