using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FSM<T> where T : IState 
{
    public readonly Dictionary<Type, IState> states = new Dictionary<Type, IState>();

    public void AddState(System.Object state) 
    {
    }

    public void TransitionTo(Type type) 
    {
    }
}

public interface IState
{
    void Setup(FSM<IState> fsm);
    void EnterState();
    void Update();
    void ExitState();
}

/*public interface IState 
{
    void Setup(FSM fsm);
    void EnterState();
    void Update();
    void ExitState();
}

public abstract class HealthState : IState 
{
    public event Action<Type> OnEnter;
    protected FSM fsm;

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void Setup(FSM fsm) { this.fsm = fsm; }
    public virtual void Update() { }
    public virtual void TakeHit() { }
}

/// <summary>
/// Dependant on HealthyState and InjuredState.
/// </summary>
public class HealthStateHandler 
{
    private FSM fsm;

    public void Setup() 
    {
        fsm.AddState(new HealthyState());
        fsm.AddState(new InjuredState());
        fsm.AddState(new DonwedState());
    }

    public void Update() 
    {

    }

    public void TakeHit() 
    { }
}

public class HealthyState : HealthState
{
    public override void EnterState() { }
    public override void ExitState() { }
    public override void Setup(FSM fsm) { }
    public override void Update() { }
    public override void TakeHit() { }
}

public class InjuredState : HealthState
{
    public override void EnterState() { }
    public override void ExitState() { }
    public override void Setup(FSM fsm) { }
    public override void Update() { }
    public override void TakeHit() { }
}

public class DonwedState : HealthState
{
    public override void EnterState() { }
    public override void ExitState() { }
    public override void Setup(FSM fsm) { }
    public override void Update() { }
    public override void TakeHit() { }
}*/