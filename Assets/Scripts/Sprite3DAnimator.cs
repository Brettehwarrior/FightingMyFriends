
using System;
using UnityEngine;

public class Sprite3DAnimator : MonoBehaviour
{
    [SerializeField] private string rowProperty = "_CurrentRow";
    [SerializeField] private string columnProperty = "_CurrentColumn";
    [SerializeField] private string gridProperty = "_GridSize";

    [SerializeField] private SpriteAnimation spriteAnimation;
    
    private MeshRenderer _meshRenderer;
    private float _currentFrame = 0;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        ChangeAnimation(spriteAnimation);
    }
    
    public void ChangeAnimation(SpriteAnimation anim)
    {
        spriteAnimation = anim;
        _currentFrame = 0;
        SetFrame();
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        _meshRenderer.material.SetVector(gridProperty, new Vector4(spriteAnimation.gridSize.x, spriteAnimation.gridSize.y, 0, 0));
        _meshRenderer.material.SetTexture("_MainTex", spriteAnimation.spriteSheet);
        SetFrame();
    }

    private void SetFrame()
    {
        var column = ((int) _currentFrame) % spriteAnimation.gridSize.x;
        var row = ((int) _currentFrame) / spriteAnimation.gridSize.x;

        _meshRenderer.material.SetInt(columnProperty, column);
        _meshRenderer.material.SetInt(rowProperty, row);
    }

    private void Update()
    {
        _currentFrame += Time.deltaTime * spriteAnimation.speed;
        _currentFrame %= spriteAnimation.totalFrames;
        SetFrame();
    }
}