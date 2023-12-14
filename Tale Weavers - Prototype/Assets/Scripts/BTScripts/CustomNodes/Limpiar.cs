using MBT;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/Limpiar")]
    [AddComponentMenu("")]
    public class Limpiar : Leaf
    {
        //private StaticEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            //_thisEnemy.Vigilar();

            return NodeResult.success;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            //_thisEnemy = GetComponentInParent<StaticEnemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
