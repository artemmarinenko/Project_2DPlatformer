using System.Collections;
using System.Collections.Generic;
using TimeControll;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float _rewindMaxTime;

    [SerializeField] Rewind _player;
    [SerializeField] Slider _timeSlider;
    //[SerializeField] Slider _TimeSlider;
    // Start is called before the first frame update
    void Awake()
    {
        //_timeSlider.value = 0.5f;
        GameEvent.OnPlayerDamageDone += GameManagerHandler;
        GameEvent.onRewindEvent += onRewindHandler;
        GameEvent.onRecordEvent += onRecordHandler;
        
    }

    private void Start()
    {
        SetTimeMaxRewindTimeToAllRewindable(_rewindMaxTime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void onRewindHandler()
    {
            RewindUi.RewindSliderEffect(_timeSlider, _rewindMaxTime);
        
    }

    private void onRecordHandler()
    {
        RewindUi.RecordSliderEffect(_timeSlider, _rewindMaxTime);
    }


    private void GameManagerHandler()
    {
        StartCoroutine(WaitThanStopTheGame());
        
    }

    IEnumerator WaitThanStopTheGame()
    {
        yield return new WaitForSeconds(0.1f);

        Time.timeScale = 0;

    }

    private void SetTimeMaxRewindTimeToAllRewindable(float rewindMaxTime)
    {
        
        

        _player._rewindMaxTime = rewindMaxTime;


        var zombies = FindObjectsOfType<Zombie>();

        foreach (Zombie z in zombies) {
            z.GetComponent<Rewind>()._rewindMaxTime = rewindMaxTime;
        }
    }
}
