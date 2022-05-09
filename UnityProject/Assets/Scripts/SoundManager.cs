using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager i = null;

    //PUBLIC VARS
    public AudioSource sourceBird;
    public AudioSource sourceCicada;

    //PROTECTED VARS
    private bool _playBird = false;
    private bool _playCicada  = false;

    //Singleton
    private void Awake() {
        if(i == null){
            i = this;
        }
        else if(i != this){
            Destroy(gameObject);
        }
    }

    private void Update() {
        if(_playBird && !sourceBird.isPlaying){
            //if _playBird is true and birdSounds is not playing yet, play the sound
            sourceBird.Play();
        }
        if(!_playBird && sourceBird.isPlaying){
            //if _playBird is false and birdSounds is playing, stop the sound
            sourceBird.Stop();
        }
        if(_playCicada && !sourceCicada.isPlaying) {
            //if _playCicada is true and sourceCicada is not playing yet, play the sound
            sourceCicada.Play();
        }
        if(!_playCicada && sourceCicada.isPlaying) {
            //if _playCicada is false and sourceCicada is playing, play the sound
            sourceCicada.Stop();
        }
    }

    public void PlayAllSounds(){
        _playBird = true;
        _playCicada = true;
    }

    public void StopAllSounds(){
        _playBird = false;
        _playCicada = false;
    }
}
