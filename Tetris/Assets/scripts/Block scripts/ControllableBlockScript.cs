using System;
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
        // FIXME: this is bad
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

        Vector2Int[][] allBlockShapes = new Vector2Int[][] {
        BlockData.I, BlockData.J, BlockData.L,
        BlockData.O, BlockData.S, BlockData.T, BlockData.Z
        };

        int randomIndex = UnityEngine.Random.Range(0, allBlockShapes.Length);
        Vector2Int[] blockShape = allBlockShapes[randomIndex];

        BlockColor color = (BlockColor)randomIndex;

        for (int i = 0; i < blockShape.Length; i++)
        {
            Vector2Int position = blockShape[i];
            BlockUnit newBlockUnit = Instantiate(prefabUnit).Initialize(currentControlledBlock, position.x, position.y, color);
            blocks.Add(newBlockUnit);
        }
        currentControlledBlock.SetBlockUnits(blocks);
        currentControlledBlock.transform.position = new Vector2(0, 40);
    }
}
