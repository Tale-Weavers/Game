using MBT;
using UnityEngine;
namespace CustomNodes
{
    [MBTNode("CustomNodes/IrHacia")]
    [AddComponentMenu("")]
    public class MoveTo : Leaf
    {
        private CleanerEnemy _thisEnemy;
        public override NodeResult Execute()
        {
            _thisEnemy.SetCheckpoint();

            return NodeResult.success;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Awake()
        {
            _thisEnemy = GetComponentInParent<CleanerEnemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }


    }
}