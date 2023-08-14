using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor 
{
    Cyan,
    Blue,
    Orange,
    Yellow,
    Green,
    Purple,
    Red,
}
 
public static class BlockSprites
{
    public static Sprite getSpriteForColor(BlockColor color)
    {
        return Resources.Load<Sprite>(color.ToString());
    }
}
