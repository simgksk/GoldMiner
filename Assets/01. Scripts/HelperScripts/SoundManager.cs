using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource hookGrab_Gold_FX, hookGrab_Stone_FX, playerLaugh_FX, pullSound_FX, ropeStretch_FX, timeRunningOut_FX, gameEnd_FX;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void HoorGrab_Gold()
    {
        hookGrab_Gold_FX.Play();
    }
    public void HoorGrab_Stone()
    {
        hookGrab_Stone_FX.Play();
    }
    public void PlayerLaugh()
    {
        playerLaugh_FX.Play();
    }
    public void RopeStretch(bool playFX)
    {
        if(playFX)
        {
            if(!ropeStretch_FX.isPlaying)
            {
                ropeStretch_FX.Play();
            }
        }
        else if(ropeStretch_FX.isPlaying)
        {
            ropeStretch_FX.Stop();
        }
    }
    public void PullSound(bool playFX)
    {
        if(playFX)
        {
            if(!pullSound_FX.isPlaying)
            {
                pullSound_FX.Play();
            }
        }
        else if(pullSound_FX.isPlaying)
        {
            pullSound_FX.Stop();
        }
    }
    public void TimeRunningOut(bool playFX)
    {
        if(playFX)
        {
            if(!timeRunningOut_FX.isPlaying)
            {
                timeRunningOut_FX.Play();
            }
        }
        else if(timeRunningOut_FX.isPlaying)
        {
            timeRunningOut_FX.Stop();
        }
    }
    public void GameEnd()
    {
        gameEnd_FX.Play();
    }
}
