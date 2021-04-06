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

        private Queue<TimePoint> _timePoints = new Queue<TimePoint>();

        private Rigidbody2D _rBody;

        private bool isRewinding = false;
        // Start is called before the first frame update
        void Awake()
        {
            _rBody = this.GetComponent<Rigidbody2D>();
            _timePoints.Enqueue(new TimePoint(_rBody.transform.position,_rBody.velocity));

            

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
            TimePoint.SetTimePoint(_rBody, _timePoints.Dequeue());
        }

        public void RecordTimePoints()
        {
            Debug.Log(_timePoints.Count);
            if (_timePoints.Count >= _timeMeasure) {
                _timePoints.Dequeue();

            }
            _timePoints.Enqueue(new TimePoint(_rBody.transform.position, _rBody.velocity));
        }
    }
}


