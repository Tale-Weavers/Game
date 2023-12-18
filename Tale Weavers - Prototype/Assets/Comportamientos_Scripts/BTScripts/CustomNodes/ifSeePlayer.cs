using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/ifSeePlayer")]
    [AddComponentMenu("")]
    public class ifSeePlayer : Leaf
    {
        AEnemy enemy;
        public override NodeResult Execute()
        {
            if (enemy.enemyType == AEnemy.TypeOfEnemy.CleanerEnemy) { 

                CleanerEnemy cleaner = enemy.GetComponent<CleanerEnemy>();
                if (cleaner.LookAround())
                {
                    return NodeResult.success;
                }
                return NodeResult.failure;
            }
            else if(enemy.enemyType == AEnemy.TypeOfEnemy.SmallEnemy)
            {
                SmallEnemy small = enemy.GetComponent<SmallEnemy>();
                if (small.LookAround())
                {
                    return NodeResult.success;
                }
                
                return NodeResult.failure;
            }
            return NodeResult.failure;
            
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Awake()
        {
            enemy = GetComponentInParent<AEnemy>();
        }
    }
}