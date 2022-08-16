﻿using UnityEngine;

namespace Fighter.Data
{
    [CreateAssetMenu(fileName = "New Fighter Data", menuName = "Data/Fighter Data", order = 0)]
    public class FighterData : ScriptableObject
    {
        [Header("Movement")]
        public float walkVelocity = 10f;
    }
}