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
        private Enemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.Levantar();

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
