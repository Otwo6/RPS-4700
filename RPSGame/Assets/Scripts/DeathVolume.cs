using UnityEngine;

public class DeathVolume : MonoBehaviour
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
            if (playerRespawn != null)
            {
                playerRespawn.Respawn();
                if (audioManager != null)
                {
                    audioManager.PlaySFX(audioManager.death);
                    audioManager.PlaySFX(audioManager.respawn);
                }
            }
        }
    }
}