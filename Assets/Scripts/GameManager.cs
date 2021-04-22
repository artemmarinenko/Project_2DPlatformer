using System.Collections;
using System.Collections.Generic;
using TimeControll;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public float _rewindMaxTime;

    [SerializeField] Rewind _player;
    [SerializeField] Slider _timeSlider;
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] GameObject _deathPanel;
    //[SerializeField] Slider _TimeSlider;
    // Start is called before the first frame update
    void Awake()
    {
        _deathPanel.SetActive(false);
        //_timeSlider.value = 0.5f;
        GameEvent.onPlayerDamageDone += OnPlayeDamageDoneHandler;
        GameEvent.onRewindEvent += OnRewindHandler;
        
        GameEvent.onRecordEvent += OnRecordHandler;
        
    }

    private void Start()
    {
        SetTimeMaxRewindTimeToAllRewindable(_rewindMaxTime);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnRewindHandler()
    {
            _deathPanel.SetActive(false);
            RewindUi.RewindSliderEffect(_timeSlider, _rewindMaxTime);
            _videoPlayer.gameObject.SetActive(true);
        
        
    }

    private void OnRecordHandler()
    {
        RewindUi.RecordSliderEffect(_timeSlider, _rewindMaxTime);
        _videoPlayer.gameObject.SetActive(false);
    }

    


    private void OnPlayeDamageDoneHandler()
    {
        _deathPanel.SetActive(true);
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
