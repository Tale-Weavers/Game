using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/Vigilar")]
    [AddComponentMenu("")]
    public class Vigilar : Leaf
    {
        private StaticEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Vigilar();

            return NodeResult.success;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<StaticEnemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
