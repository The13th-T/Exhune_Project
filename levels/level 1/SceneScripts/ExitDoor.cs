using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private bool bossDefeated = false;

    public void Unlock()
    {
        bossDefeated = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (bossDefeated && other.CompareTag("Player"))
        {
            Debug.Log("Dungeon Cleared!");
        }
    }
}