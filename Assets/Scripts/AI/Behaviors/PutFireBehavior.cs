using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Behaviors
{
    [CreateAssetMenu(fileName = "PutFire", menuName = "My AI/Put fire")]
    public class PutFireBehavior : EntityBehavior
    {
        private bool isFinished = false;
        private Flammable possibleTarget = null;

        public override void Execute()
        {
            Debug.Log("Execute");
            if(possibleTarget == null)
            {
                Debug.LogError("Null possible target!");
                isFinished = true;
                return;
            }

            possibleTarget.Burn();
            isFinished = true;
        }

        public override float GetScore()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(manager.transform.position, 2f);
            for (int i = 0; i < colliders.Length; i++)
            {
                Flammable flammable = colliders[i].GetComponent<Flammable>();
                if(flammable)
                {
                    if(flammable.IsBurned || flammable.IsBurning)
                    {
                        continue;
                    }
                    possibleTarget = flammable;
                    return 100f; //TODO
                }
            }
            return 0f;

            //TODO: below would be for running and putting fire
            //List<Flammable> flammables = blackboard.Flammables;
            //Vector2 playerPos = blackboard.Player.transform.position;
            //float minDistance = float.MaxValue;
            //float maxDistance = 0;
            //float singleScore = 0;
            //for(int i = 0; i < flammables.Count; i++)
            //{
            //    Flammable current = flammables[i];
            //    if(current != null && current.enabled)
            //    {
            //        if(current.IsBurned || current.IsBurning)
            //        {
            //            continue;
            //        }
            //        singleScore = (playerPos - (Vector2)current.transform.position).sqrMagnitude;
            //        if(singleScore < minDistance)
            //        {
            //            minDistance = singleScore;
            //            possibleTarget = current;
            //        }
            //        else if(singleScore > maxDistance)
            //        {
            //            maxDistance = singleScore;
            //        }
            //    }
            //}
            //return maxDistance / minDistance;
        }

        public override bool IsFinished()
        {
            Debug.Log("is finished");
            return isFinished;
        }

        public override void OnBehaviorUpdate()
        {
        }

        public override void Reset()
        {
            isFinished = false;
            possibleTarget = null;
        }
    }
}
