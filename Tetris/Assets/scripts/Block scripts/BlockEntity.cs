using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEntity : MonoBehaviour
{
    public float maxDroppingSpeed; 
    public Rigidbody2D rigidbody;

    private List<BlockUnit> blockUnits = new List<BlockUnit>();

    public void SetBlockUnits(List<BlockUnit> blocks)
    {
        blockUnits = blocks;
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    private void FixedUpdate()
    {
        // Limit max speed
        if(rigidbody.velocity.magnitude > maxDroppingSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxDroppingSpeed;
        }
    }

    public bool isAsleep()
    {
        return blockUnits.TrueForAll(u => u.body.IsSleeping());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
