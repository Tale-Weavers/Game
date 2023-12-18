using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/Levantar")]
    [AddComponentMenu("")]
    public class Levantar : Leaf
    {
        private BasicEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Levantar();

            return NodeResult.success;
        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<BasicEnemy>();
        }


    }
}
