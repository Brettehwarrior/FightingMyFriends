using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighter.Common
{

    public class HitEffectManager : MonoBehaviour
    {
        public static HitEffectManager Instance { get; private set; }

        private void Awake()
        {
            // Singleton
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        public void PauseEffect(GameObject[] targets, float duration)
        {
            // Pause all the targets
            foreach (var target in targets)
            {
                // Disable all components
                foreach (var component in target.GetComponents<MonoBehaviour>())
                {
                    component.enabled = false;
                }

                // Pause animation (child model)
                foreach (var animator in target.GetComponentsInChildren<Animator>())
                {
                    animator.speed = 0f;
                }
            }

            // Resume after duration
            StartCoroutine(ResumeTargetsAfterDuration(targets, duration));
        }

        private IEnumerator ResumeTargetsAfterDuration(GameObject[] targets, float duration)
        {
            yield return new WaitForSeconds(duration);
            // Resume all the targets
            foreach (var target in targets)
            {
                // Enable all components
                foreach (var component in target.GetComponents<MonoBehaviour>())
                {
                    component.enabled = true;
                }

                // Resume animation (child model)
                foreach (var animator in target.GetComponentsInChildren<Animator>())
                {
                    animator.speed = 1f;
                }
            }
        }
    }
}