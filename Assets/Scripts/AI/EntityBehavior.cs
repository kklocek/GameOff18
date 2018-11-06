using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public abstract class EntityBehavior : ScriptableObject
    {
        public abstract float GetScore();
        public abstract void OnBehaviorUpdate();
        public abstract void Execute();
        public abstract bool IsFinished();
        public abstract void Reset();

        [HideInInspector]
        public Blackboard blackboard;
        [HideInInspector]
        public AIManager manager;
    }
}
