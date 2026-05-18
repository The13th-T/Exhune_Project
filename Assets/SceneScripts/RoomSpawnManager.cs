using UnityEngine;

public class RoomSpawnManager : MonoBehaviour
{
    void Start()
    {
        string targetSpawn =
            PlayerPrefs.GetString("SpawnPoint", "");

        SpawnPoint[] points =
            FindObjectsByType<SpawnPoint>(
                FindObjectsSortMode.None
            );

        foreach (SpawnPoint point in points)
        {
            if (point.spawnName == targetSpawn)
            {
                GameObject player =
                    GameObject.FindGameObjectWithTag("Player");

                if (player != null)
                {
                    player.transform.position =
                        point.transform.position;
                }

                break;
            }
        }
    }
}