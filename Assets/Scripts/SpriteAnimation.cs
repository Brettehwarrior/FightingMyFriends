using UnityEngine;

[CreateAssetMenu(fileName = "New Sprite Animation", menuName = "Sprite Animation", order = 0)]
public class SpriteAnimation : ScriptableObject
{
    public Texture2D spriteSheet;
    public Vector2Int gridSize;
    public int totalFrames;
    public float speed;
}
