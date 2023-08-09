using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUnit : MonoBehaviour
{
    // Related components
    public Rigidbody2D body;
    public Joint2D joint;
    private BlockEntity parent;

    public BlockUnit Initialize(BlockEntity parent, int x, int y, BlockColor color)
    {
        this.parent = parent;
        this.transform.parent = parent.transform;
        this.transform.position = new Vector2(x, y);
        this.joint.connectedBody = parent.GetComponent<Rigidbody2D>();  
        GetComponent<SpriteRenderer>().sprite = BlockSprites.getSpriteForColor(color);
        return this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        // Limit max speed
        if (body.velocity.magnitude > parent.maxDroppingSpeed)
        {
            body.velocity = body.velocity.normalized * parent.maxDroppingSpeed;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }


}
