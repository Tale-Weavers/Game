using MBT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/ifCloseWollball")]
    [AddComponentMenu("")]
    public class ifCloseWollball : Leaf
    {
        //private BasicEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            //if (_thisEnemy.GoAwake) return NodeResult.success;
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
            //_thisEnemy = GetComponentInParent<BasicEnemy>();
        }
    }
}