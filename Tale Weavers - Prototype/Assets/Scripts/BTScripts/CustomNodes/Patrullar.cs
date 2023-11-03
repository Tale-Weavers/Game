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
        private MoveableEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Patrullar();

            return NodeResult.success;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<MoveableEnemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
