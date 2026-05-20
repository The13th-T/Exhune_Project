using UnityEngine;

public class hitBox : MonoBehaviour
{
    public GameObject shot;
    public GameObject shot2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testPlayer.playerDirection == "right")
        {
            transform.position = new Vector3(testPlayer.playerPositionX + 2, testPlayer.playerPositionY, 0);
        }
        if (testPlayer.playerDirection == "left")
        {
            transform.position = new Vector3(testPlayer.playerPositionX - 2, testPlayer.playerPositionY, 0);
        }
        if (Input.GetKey("space"))
        {
            if (testPlayer.playerDirection == "right")
            {
                Instantiate(shot, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.identity);
            }
            if (testPlayer.playerDirection == "left")
            {
                Instantiate(shot2, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.identity);
            }
        }
    }
}
