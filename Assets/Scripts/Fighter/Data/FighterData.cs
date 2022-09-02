using UnityEngine;

namespace Fighter.Data
{
    [CreateAssetMenu(fileName = "New Fighter Data", menuName = "Data/Fighter Data", order = 0)]
    public class FighterData : ScriptableObject
    {
        [Header("Movement")]
        public float walkVelocity = 10f;
        public float jumpSpeed = 5f;
        
        public float gravityScale = 1f;
        public float terminalVelocity = -20f;
        public float maxAirSpeed = 30f;
        public float airAcceleration = 2f;
        [Range(0f, 1f)] public float airFriction = 0.8f;
    }
}