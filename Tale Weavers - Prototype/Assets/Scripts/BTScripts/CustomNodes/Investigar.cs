using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/Investigar")]
    [AddComponentMenu("")]
    public class Investigar : Leaf
    {
        private Enemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Investigar();

            return NodeResult.success;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<Enemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
