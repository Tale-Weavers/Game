using BehaviourAPI.Core;
using BehaviourAPI.Core.Actions;
using BehaviourAPI.StateMachines;
using BehaviourAPI.UnityToolkit;
using BehaviourAPI.UnityToolkit.GUIDesigner.Runtime;
using Unity.VisualScripting;
using UnityEngine;

public class RGA : BehaviourRunner
{
    [SerializeField] private Transform ir_objetivo_action_target;
    private BSRuntimeDebugger _debugger;
    PushPerception click;
    protected override void Init()
    {
        _debugger = GetComponent<BSRuntimeDebugger>();
        base.Init();
    }

    protected override BehaviourGraph CreateGraph()
    {
        FSM colorFSM = new FSM();

        UnityTimePerception delay = new UnityTimePerception(3);

        var amarillo = colorFSM.CreateState("Amarillo", new SimpleAction(SetYellow));
        var verde = colorFSM.CreateState("Verde", new SimpleAction(SetRed));
        var rojo = colorFSM.CreateState("Rojo", new SimpleAction(SetGreen));

        var iniarojo = colorFSM.CreateTransition("iinicial", amarillo, rojo,delay);

        var rojoaverde = colorFSM.CreateTransition("delay", rojo, verde,delay);
        var t_click = colorFSM.CreateTransition("click", verde,rojo,statusFlags: StatusFlags.None );

        click = new PushPerception(t_click);


        return colorFSM;
    }

    protected override void OnUpdated()
    {
        if (Input.GetMouseButtonDown(0))
        {
            click.Fire();  
        }
        base.OnUpdated();
    }

    private void SetGreen()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void SetRed()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void SetYellow()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}