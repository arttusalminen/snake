using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks_down_movement : MonoBehaviour
{
    // Related components
    public Rigidbody2D blockBody;
    public Collider2D collider;
    public float blockSize;
    public GameManagement gameManagement;

    // Variables that can be adjusted in Unity editor
    public float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is something to collide to just underneath the body
        RaycastHit2D[] results = new RaycastHit2D[10];
        int hits = blockBody.Cast(Vector2.down, results, 0.01f);

        // Assign velocity accordingly when stationary. Conditional operator '?:', short version of if-else
        if (blockBody.velocity.sqrMagnitude < movementSpeed / 2)
        {
            blockBody.velocity = hits == 0 ? Vector2.down * movementSpeed : Vector2.zero;
            gameManagement.GameRunning = true;
        }

    }
}
