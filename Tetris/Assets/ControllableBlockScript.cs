using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllableBlockScript : MonoBehaviour
{
    public GameObject currentControlledBlock;
    public GameObject model;
    public GameManagement gameManagement;

    public BlockMovementInputs inputs;

    void Awake()
    {
        inputs = new BlockMovementInputs();
        inputs.BlockControls.MoveRight.performed += ctx => MoveBlock(DirectionEnum.Right);
        inputs.BlockControls.MoveLeft.performed += ctx => MoveBlock(DirectionEnum.Left);
        inputs.BlockControls.RotateBlock.performed += ctx => RotateBlock();
    }

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

    private void MoveBlock(DirectionEnum direction)
    {
        // TODO: check if possible to move in the given direction

        Vector2 currentPos = currentControlledBlock.transform.position;
        Vector2 movement = new Vector2(5, 0);

        if (direction == DirectionEnum.Left)
            movement.x = -5;

        currentControlledBlock.transform.position = currentPos + movement;
    }

    private void RotateBlock()
    {
        // TODO
    }


    private void OnEnable()
    {
        inputs.BlockControls.Enable();
    }

    private void OnDisable()
    {
        inputs.BlockControls.Disable();
    }


}
