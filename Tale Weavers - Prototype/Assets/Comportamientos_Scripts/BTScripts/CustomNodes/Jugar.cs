using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/Jugar")]
    [AddComponentMenu("")]
    public class Jugar : Leaf
    {
        private BasicEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Jugar();

            return NodeResult.success;
        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<BasicEnemy>();
        }



    }
}
