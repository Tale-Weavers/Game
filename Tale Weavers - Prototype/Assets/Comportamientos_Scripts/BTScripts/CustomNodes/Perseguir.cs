using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/Perseguir")]
    [AddComponentMenu("")]
    public class Perseguir : Leaf
    {
        private BasicEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Perseguir();

            return NodeResult.success;
        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<BasicEnemy>();
        }

    }
}
