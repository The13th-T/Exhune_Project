using UnityEngine;
namespace SceneScript
{
    public class PlayerMovement1 : MonoBehaviour
    {
        public float baseSpeed = 10f; // Player movement speed
        private Rigidbody2D rb;
        public static string playerFace = "right";

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the object
        }

        private void Update()
        {
        	Movement();
        }
        
        private void CheckFace() {
        	if(Input.GetKey("up"))
        		playerFace = "up";
        	if(Input.GetKey("down"))
        		playerFace = "down";
        	if(Input.GetKey("left"))
        		playerFace = "left";
        	if(Input.GetKey("right"))
        		playerFace = "right";
        }
        
        private void Movement() {
        	CheckFace();
        	float moveSpeed = baseSpeed;
            float horizontal = Input.GetAxis("Horizontal"); // Left/Right arrows
            float vertical = Input.GetAxis("Vertical"); // Up/Down arrows
            Vector2 movement = new Vector2(horizontal, vertical) * moveSpeed;
            if(Input.GetKey(KeyCode.LeftShift))
            	rb.linearVelocity = movement * 5;
            else
            	rb.linearVelocity = movement;
        }
    }
}