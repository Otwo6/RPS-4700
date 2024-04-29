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
    public AudioClip playerdeath;
    public AudioClip AttackCollision;
    public AudioClip BoulderBlasterShoot;
    public AudioClip BoulderBlasterhit;
    public AudioClip playerrespawn;
    public AudioClip rocksound;
    public AudioClip scissorsound;
    public AudioClip paperplanesound;
    public AudioClip Attack;
    public AudioClip equip;


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

