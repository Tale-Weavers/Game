using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/Patrullar")]
    [AddComponentMenu("")]
    public class Patrullar : Leaf
    {
        private BasicEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Patrullar();

            return NodeResult.success;
        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<BasicEnemy>();
        }

    }
}
