using System;
using System.Collections.Generic;
using UnityEngine;
using BehaviourAPI.Core;
using BehaviourAPI.Core.Actions;
using BehaviourAPI.Core.Perceptions;
using BehaviourAPI.UnityToolkit;
using BehaviourAPI.StateMachines;
using BehaviourAPI.UnityToolkit.GUIDesigner.Runtime;

public class IrObjetivoCode : BehaviourRunner
{
	[SerializeField] private Transform ir_objetivo_action_target;
	BSRuntimeDebugger _debugger;

    protected override void Init()
    {
		_debugger = GetComponent<BSRuntimeDebugger>();
		base.Init();
    }
    protected override BehaviourGraph CreateGraph()
	{
		FSM newbehaviourgraph = new FSM();
		
		ChaseAction ir_objetivo_action = new ChaseAction();
		ir_objetivo_action.speed = 1f;
		ir_objetivo_action.target = ir_objetivo_action_target;
		ir_objetivo_action.maxDistance = 0.1f;
		ir_objetivo_action.maxTime = 10f;
		State ir_objetivo = newbehaviourgraph.CreateState(ir_objetivo_action);
		
		PatrolAction alejarme_action = new PatrolAction();
		alejarme_action.maxDistance = 4f;
		State alejarme = newbehaviourgraph.CreateState(alejarme_action);
		
		DistancePerception ha_llegado_perception = new DistancePerception();
		ha_llegado_perception.OtherTransform = ir_objetivo_action_target;
		ha_llegado_perception.MaxDistance = 1f;
		StateTransition ha_llegado = newbehaviourgraph.CreateTransition(ir_objetivo, alejarme, ha_llegado_perception);
		
		UnityTimePerception fin_de_patrulla_perception = new UnityTimePerception();
		fin_de_patrulla_perception.TotalTime = 3f;
		StateTransition fin_de_patrulla = newbehaviourgraph.CreateTransition(alejarme, ir_objetivo, fin_de_patrulla_perception);

		_debugger.RegisterGraph(newbehaviourgraph);
		return newbehaviourgraph;
	}
}
