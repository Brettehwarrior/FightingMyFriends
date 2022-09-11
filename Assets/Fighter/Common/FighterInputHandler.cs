using System;
using UnityEngine;
using UnityEngine.Events;

namespace Fighter.Common
{
    public abstract class FighterInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; protected set; }
        public bool JumpInput { get; protected set; }
        public UnityEvent AttackEvent { get; protected set; }

        protected virtual void Awake()
        {
            AttackEvent = new UnityEvent();
        }
    }
}