using MBT;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/CubrirSalida")]
    [AddComponentMenu("")]
    public class CubrirSalida : Leaf
    {
        private SmallEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.CoverExit();

            return NodeResult.success;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<SmallEnemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}
