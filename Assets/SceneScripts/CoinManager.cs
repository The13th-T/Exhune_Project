using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Coins")]
    public GameObject[] coins;

    [Header("Doors")]
    public GameObject[] doorsToUnlock;

    private bool completed = false;

    void Update()
    {
        if (completed) return;

        bool allCollected = true;

        foreach (GameObject coin in coins)
        {
            if (coin != null)
            {
                allCollected = false;
                break;
            }
        }

        if (allCollected)
        {
            CompleteRoom();
        }
    }

    void CompleteRoom()
    {
        completed = true;

        Debug.Log("All coins collected!");

        foreach (GameObject door in doorsToUnlock)
        {
            if (door != null)
            {
                door.SetActive(true);
            }
        }
    }
}