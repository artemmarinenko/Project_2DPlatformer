using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TimeControll {
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

        public static void SetTimePoint(Player player,Rigidbody2D playerRigidbody,TimePoint timePoint)
        {
            playerRigidbody.transform.position = timePoint._position;
            playerRigidbody.GetComponent<Rigidbody2D>().velocity = timePoint._velocity;
            player._speed = timePoint._speed;
            player._renderer.flipX = timePoint._flipX;
            player._animator.SetFloat("Speed", timePoint._speed);


        }


    }

    public class Rewind : MonoBehaviour
    {
        [SerializeField]
        private int _timeMeasure;

        private LinkedList<TimePoint> _timePoints = new LinkedList<TimePoint>();

        private Rigidbody2D _rBody;

        private Player _player;


        private  bool isRewinding = false;
        // Start is called before the first frame update
        
        
        void Awake()
        {
            
            _rBody = GetComponent<Rigidbody2D>();
            _player = this.GetComponent<Player>();
           
           // _timePoints.Enqueue(new TimePoint(_rBody.transform.position,_rBody.velocity));

            

        }

        // Update is called once per frame

        private void Update()
        {

            if (Input.GetKey(KeyCode.R))
            {
                isRewinding = true;

            }
            else
            {
                isRewinding = false;
                //_player._animator.SetFloat("Speed", 0);
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
            TimePoint.SetTimePoint(_player,_rBody, _timePoints.Last.Value);
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
            _timePoints.AddLast(new TimePoint(_rBody.transform.position, _rBody.velocity,_player._speed,_player._renderer.flipX));
        }
    }
}


