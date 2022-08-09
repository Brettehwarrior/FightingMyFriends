
using System;
using UnityEngine;

public class SimpleAnimationChanger : MonoBehaviour
{
    [SerializeField] private SpriteAnimation[] animations;
    
    private int _currentAnimationIndex = 0;
    
    private Sprite3DAnimator _spriteAnimator;

    private void Awake()
    {
        _spriteAnimator = GetComponent<Sprite3DAnimator>();
    }

    public void ChangeAnimation()
    {
        _currentAnimationIndex = (_currentAnimationIndex + 1) % animations.Length;
        _spriteAnimator.ChangeAnimation(animations[_currentAnimationIndex]);
    }
}