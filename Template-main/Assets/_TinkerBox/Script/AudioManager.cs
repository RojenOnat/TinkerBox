using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SuccesSource;
    public AudioSource FalseSource;
    public AudioSource SitSource;
    public AudioSource TableCompleteSource;

    public AudioClip SuccesSound;
    public AudioClip FalseChoiceSound;
    public AudioClip SitSound;
    public AudioClip TableCompletedSound;


    public void PlaySitSound() => SitSource.Play();
    public void PlayFalseSound() => FalseSource.Play();
    public void PlaySuccesSound() => SuccesSource.Play();
    public void PlayTableCompleteSound() => TableCompleteSource.Play();


}
