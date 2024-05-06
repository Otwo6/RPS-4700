using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source---------")]
    [SerializeField] AudioSource musicSource;
     [SerializeField] AudioSource SFXSource;
    
    [Header("--------Audio Clip---------")]
    
    public AudioClip background;   
    public AudioClip footsteps;
    public AudioClip jumping;
    public AudioClip landing;
    
    public AudioClip Scissorattack;
    public AudioClip Paperattack;
    public AudioClip Rockattack;
    public AudioClip enemyhit;
    public AudioClip death;
    public AudioClip BoulderBlasterShoot;
     public AudioClip Destroyed;
 public AudioClip equip;
    public AudioClip respawn;

    public AudioClip gameover;
   
    //public AudioClip Attack;

private void Start()
{
    musicSource.clip = background;
    musicSource.Play();
}
public void PlaySFX(AudioClip clip)
{
    SFXSource.PlayOneShot(clip);
}
}


