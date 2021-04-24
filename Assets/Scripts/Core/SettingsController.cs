using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
interface IRessetable
{  
     void Reset();
}
public class SettingsController : MonoBehaviour
{
    private bool isMusicOn = false;
    private bool isSoundOn = false;
    private bool isFacebookOn = false;
    [SerializeField] private Button _music;
    [SerializeField] private Button _sound;
    [SerializeField] private Button _facebook;
    [SerializeField] private Button _closeSettings;
    [SerializeField] private Button _openSettings;

    [SerializeField] private Slider _slider;

    [SerializeField] GameObject _settings;
    // Start is called before the first frame update
    void Awake()
    {
        AddButtonsListeners();

        _slider.onValueChanged.AddListener((float rate) => Debug.Log("Volume rate " + rate));
        
    }
    
    

    private void AddButtonsListeners() {

        _openSettings.onClick.AddListener(() =>
        {
            //GameObject.FindGameObjectsWithTag("Settings")[0].SetActive(true);
            _settings.SetActive(true);
        });

        _closeSettings.onClick.AddListener(() =>
        {
            //GameObject.FindGameObjectsWithTag("Settings")[0].SetActive(false);
            _settings.SetActive(false);
        });

        _music.onClick.AddListener(() => {
            string status = isMusicOn ? "On" : "off";
            _music.GetComponentInChildren<Text>().text= status;
            isMusicOn = !isMusicOn;
            Debug.Log("Music " + status);
        });

        _sound.onClick.AddListener(() => {
            string status = isSoundOn ? "On" : "off";
            _sound.GetComponentInChildren<Text>().text = status;
            isSoundOn = !isSoundOn;
            Debug.Log("Sound " + status);
        });


        _facebook.onClick.AddListener(() => {
            string status = isFacebookOn ? "On" : " off";
            _facebook.GetComponentInChildren<Text>().text = status;
            isFacebookOn = !isFacebookOn;
            Debug.Log("Facebook " + status);
        });
    }
}
