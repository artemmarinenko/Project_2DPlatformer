using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        
        


        _startButton.onClick.AddListener(() =>
        {
           
            StartCoroutine(WaitAnimationThenStart(0.8f)) ;
        });
    }

    IEnumerator WaitAnimationThenStart(float time)
    {
        _animator.SetBool("isStarted", true);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
}
