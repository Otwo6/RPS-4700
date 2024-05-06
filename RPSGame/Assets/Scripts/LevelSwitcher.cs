using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public string levelToOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Change "Player" to your desired tag
        {
            SceneManager.LoadScene(levelToOpen);
        }
    }
}
