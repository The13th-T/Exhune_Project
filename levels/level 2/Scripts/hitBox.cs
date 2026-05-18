using UnityEngine;

public class hitBox : MonoBehaviour
{
    public GameObject shot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testPlayer.playerDirection == "right")
        {
            transform.position = new Vector3(testPlayer.playerPositionX + 1, testPlayer.playerPositionY, 0);
        }
        if (testPlayer.playerDirection == "left")
        {
            transform.position = new Vector3(testPlayer.playerPositionX - 1, testPlayer.playerPositionY, 0);
        }
        if (Input.GetKey("space"))
        {
            Instantiate(shot, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
