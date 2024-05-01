using UnityEngine;

public class DeathVolume : MonoBehaviour
{
    private AudioManager audioManager;
	private PlayerHealthScript playerHealth;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthScript>();
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
					playerHealth.loseHealth();
                    audioManager.PlaySFX(audioManager.respawn);
                }
            }
        }
    }
}