using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableBlockScript : MonoBehaviour
{
    public GameObject currentControlledBlock;
    public GameObject model;
    public GameManagement gameManagement;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D someBodyPart = (Rigidbody2D)currentControlledBlock.GetComponentInChildren(typeof(Rigidbody2D), false);
        Collider2D someCollider = (Collider2D)currentControlledBlock.GetComponentInChildren(typeof(Collider2D), false);

        // Create new block & move to start position
        if (gameManagement.GameRunning && someCollider.IsTouchingLayers() && someBodyPart.velocity.magnitude.Equals(0))
        {
            // TODO: create new random block, assign to currentControlledBlock

            currentControlledBlock = Instantiate(model, new Vector2(0, 40), new Quaternion());

            // TODO: transform to start location (centre)
            // take into account shape of said block & align it with lines
        }
    }
}
