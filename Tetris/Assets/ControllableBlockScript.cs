using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllableBlockScript : MonoBehaviour
{
    public BlockEntity currentControlledBlock;
    public GameManagement gameManagement;

    public BlockEntity prefabEntity;
    public BlockUnit prefabUnit;

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
        AssignNewControllableBlock();
    }

    // Update is called once per frame
    void Update()
    {
        // Create new block & move to start position
        if (currentControlledBlock.isAsleep())
        {
            AssignNewControllableBlock();

            // TODO: transform to start location (centre)
            // take into account shape of said block & align it with lines
        }
    }

    private void MoveBlock(DirectionEnum direction)
    {
        // TODO: check if possible to move in the given direction

        Vector2 currentPos = currentControlledBlock.transform.position;
        Vector2 movement = new Vector2(2, 0);

        if (direction == DirectionEnum.Left)
            movement.x = -2;

        currentControlledBlock.transform.position = currentPos + movement;
    }

    private void RotateBlock()
    {
        // TODO
        currentControlledBlock.transform.Rotate(0, 0, 90);
    }


    private void OnEnable()
    {
        inputs.BlockControls.Enable();
    }

    private void OnDisable()
    {
        inputs.BlockControls.Disable();
    }

    private void AssignNewControllableBlock()
    {
        currentControlledBlock = Instantiate(prefabEntity);
        currentControlledBlock.transform.position = new Vector2(0, 0);

        List<BlockUnit> blocks = new List<BlockUnit>();
        blocks.Add(Instantiate(prefabUnit).Initialize(currentControlledBlock, 0, 0, BlockColor.Blue));
        blocks.Add(Instantiate(prefabUnit).Initialize(currentControlledBlock, 2, 0, BlockColor.Blue));
        blocks.Add(Instantiate(prefabUnit).Initialize(currentControlledBlock, -2, 0, BlockColor.Blue));
        blocks.Add(Instantiate(prefabUnit).Initialize(currentControlledBlock, 0, -2, BlockColor.Blue));
        blocks.Add(Instantiate(prefabUnit).Initialize(currentControlledBlock, 0, -4, BlockColor.Blue));
        currentControlledBlock.SetBlockUnits(blocks);

        currentControlledBlock.transform.position = new Vector2(0, 40);
    }
}
