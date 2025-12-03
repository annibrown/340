using System;
using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private int timeRemaining;
    private bool isStopped;
    private bool playedSound = false;
    
    private Action methodToCallWhenTimeIsOver;

    void Update()
    {
        if (timeRemaining == 10 && !playedSound)
        {
            AudioManager.Instance.Play(AudioManager.SoundType.Timer);
            playedSound = true;
        }
    }
    
    public void StartTimer(int durationInSeconds, Action methodToCallWhenTimeIsOver)
    {
        Debug.Log("Starting Timer");
        this.methodToCallWhenTimeIsOver = methodToCallWhenTimeIsOver;
        isStopped = false;
        timeRemaining = durationInSeconds;
        playedSound = false;
        StartCoroutine(TickOneSecond());
    }

    public void StopTimer()
    {
        Debug.Log("Stopping Timer");
        timeRemaining = 0;
        isStopped = true;
        methodToCallWhenTimeIsOver.Invoke();
    }

    public void PauseTimer()
    {
        Debug.Log("Pause Timer");
        Time.timeScale = 0;
    }

    public void ResumeTimer()
    {
        Debug.Log("Resume Timer");
        Time.timeScale = 1;
    }

    public string GetTimeAsString()
    {
        int minutes = timeRemaining / 60;
        int seconds = timeRemaining % 60;
        
        string minutesAsString = String.Format("{0:00}", minutes); 
        string secondsAsString = String.Format("{0:00}", seconds);
        
        return minutesAsString + ":" + secondsAsString;
    }

    public bool IsRunning()
    {
        return !isStopped;
    }

    IEnumerator TickOneSecond()
    {
        yield return new WaitForSeconds(1);

        if (!isStopped)
        {
            timeRemaining--;
            if (timeRemaining > 0)
            {
                StartCoroutine(TickOneSecond());
            }
            else
            {
                StopTimer();
            }
        }
    }
}
