using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor 
{
    Blue,
    Cyan,
    Ghost,
    Green,
    Red,
    Orange,
    Purple,
    Yellow,
}

public static class BlockSprites
{
    public static Sprite getSpriteForColor(BlockColor color)
    {
        return Resources.Load<Sprite>(color.ToString());
    }
}
