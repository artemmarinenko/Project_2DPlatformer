using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameEvent.OnPlayerDamageDone += GameManagerHandler;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
