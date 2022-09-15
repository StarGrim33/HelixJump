using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
   public Control Controls;
    private AudioSource _audio;

   public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State currentState { get; private set; }

    public void OnPlayerDied()
    {
        if (currentState != State.Playing) return;
        currentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game over");
        _audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().Play();
        StartCoroutine(ReloadLevel(1.5f));
        
    }

    public void OnPlayerReachedFinish()
    {
        if (currentState != State.Playing) return;
        currentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("You win");
        StartCoroutine(ReloadLevel(1.5f));
    }

    private IEnumerator ReloadLevel(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt("LevelIndexKey", 0);
        private set
        {
            PlayerPrefs.SetInt("LevelIndexKey", value);
            PlayerPrefs.Save();
        }
    }
    private const string LevelIndexKey = "LevelIndex";
}
