using UnityEngine;

namespace Fighter.Common.Collisions
{
    [CreateAssetMenu(fileName = "New HurtBox Data", menuName = "Hurtbox Data", order = 0)]
    public class HurtboxData : ScriptableObject
    {
        [Range(0f, 360f)] public float angle = 90f;
        public float knockback = 20f;
        public float damage = 5f;
        public float hitStop = 0.1f;
        
        public GameObject hitEffectPrefab;
    }
}