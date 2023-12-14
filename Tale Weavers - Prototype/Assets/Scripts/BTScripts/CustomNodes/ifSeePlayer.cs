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
        CleanerEnemy enemy;
        public override NodeResult Execute()
        {
            if (enemy.LookAround()) return NodeResult.success;
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
            enemy = GetComponentInParent< CleanerEnemy>();
        }
    }
}