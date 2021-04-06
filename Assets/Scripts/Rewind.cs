using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimeControll {
    public class TimePoint
    {
        private Vector2 _position;

        private Vector2 _velocity;

        

        public TimePoint(Vector2 position, Vector2 velocity)
        {
            _position = position;
            _velocity = velocity;
            
        }

        public static void SetTimePoint(Rigidbody2D playerRigidbody,TimePoint timePoint)
        {
            playerRigidbody.transform.position = timePoint._position;
            playerRigidbody.GetComponent<Rigidbody2D>().velocity = timePoint._velocity;
            
        }


    }

    public class Rewind : MonoBehaviour
    {
        [SerializeField]
        private int _timeMeasure;

        private LinkedList<TimePoint> _timePoints = new LinkedList<TimePoint>();

        private Rigidbody2D _rBody;

       


        private bool isRewinding = false;
        // Start is called before the first frame update
        
        
        void Awake()
        {
            
            _rBody = GetComponent<Rigidbody2D>();
           
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
            TimePoint.SetTimePoint(_rBody, _timePoints.Last.Value);
            _timePoints.RemoveLast(); 
                }

            else {
                isRewinding = false;
                }
        }

        public void RecordTimePoints()
        {
            //Debug.Log(_timePoints.Count);
            if (_timePoints.Count >= _timeMeasure) {
                _timePoints.RemoveFirst();

            }
            _timePoints.AddLast(new TimePoint(_rBody.transform.position, _rBody.velocity));
        }
    }
}


