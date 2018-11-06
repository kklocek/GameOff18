using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AIManager : MonoBehaviour
    {
        public EntityBehavior[] behaviors;
        public float updateRate = 0.05f; //20 fps

        private float timer = 0;
        private EntityBehavior currentBehavior = null;
        [SerializeField]
        private Blackboard blackboard;

        private void Start()
        {
            for(int i = 0; i < behaviors.Length; i++)
            {
                behaviors[i].blackboard = blackboard;
                behaviors[i].manager = this;
            }
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if(timer >= updateRate)
            {
                timer = 0;
                if(currentBehavior != null)
                {
                    currentBehavior.OnBehaviorUpdate();
                    if(currentBehavior.IsFinished())
                    {
                        currentBehavior.Reset();
                        currentBehavior = null;
                    }
                    else
                    {
                        return;
                    }
                }
                UpdateBehaviors();
            }
        }

        private void UpdateBehaviors()
        {
            Debug.Log("update behaviors");
            float maxScore = 0;
            float currentScore = maxScore;
            int behaviorIndex = -1;
            for(int  i = 0; i < behaviors.Length; i++)
            {
                currentScore = behaviors[i].GetScore();
                if(currentScore > maxScore)
                {
                    maxScore = currentScore;
                    behaviorIndex = i;
                }
            }
            if(behaviorIndex >= 0)
            {
                currentBehavior = behaviors[behaviorIndex];
                currentBehavior.Execute();
            }
        }
    }

}
