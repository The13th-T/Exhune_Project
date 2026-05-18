using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    [Header("Scene")]
    public string sceneToLoad;

    [Header("Spawn")]
    public string spawnPointName;

    private bool canEnter = false;

    void Update()
    {
        if (canEnter && Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetString(
                "SpawnPoint",
                spawnPointName
            );

            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canEnter = false;
        }
    }
}