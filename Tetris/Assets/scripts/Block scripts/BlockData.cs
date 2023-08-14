using UnityEngine;

public static class BlockData
{
    public static Vector2Int[] I = new Vector2Int[] { new Vector2Int(-2, 2), new Vector2Int( 0, 2), new Vector2Int( 2, 2), new Vector2Int( 4, 2) };
    public static Vector2Int[] J = new Vector2Int[] { new Vector2Int(-2, 2), new Vector2Int(-2, 0), new Vector2Int(0, 0), new Vector2Int(2, 0) } ;
    public static Vector2Int[] L = new Vector2Int[] { new Vector2Int(2, 2), new Vector2Int(-2, 0), new Vector2Int(0, 0), new Vector2Int(2, 0) } ;
    public static Vector2Int[] O = new Vector2Int[] { new Vector2Int(0, 2), new Vector2Int(2, 2), new Vector2Int(0, 0), new Vector2Int(2, 0) } ;
    public static Vector2Int[] S = new Vector2Int[] { new Vector2Int(0, 2), new Vector2Int(2, 2), new Vector2Int(-2, 0), new Vector2Int(0, 0) } ;
    public static Vector2Int[] T = new Vector2Int[] { new Vector2Int(0, 2), new Vector2Int(-2, 0), new Vector2Int(0, 0), new Vector2Int(2, 0) } ;
    public static Vector2Int[] Z = new Vector2Int[] { new Vector2Int(-2, 2), new Vector2Int(0, 2), new Vector2Int(0, 0), new Vector2Int(2, 0) } ;

}
