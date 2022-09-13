using System;
using UnityEngine;
using UnityEngine.Events;

namespace Fighter.Common
{
    public abstract class FighterInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; protected set; }
        public bool JumpInput { get; protected set; }
        public bool AttackInput { get; protected set; }
    }
}