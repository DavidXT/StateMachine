using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionSM1Death : ATransition
{
    private AISoldier _ai;

    public TransitionSM1Death(AState nextState, AISoldier ai) : base (nextState)
    {
        _ai = ai;
    }

    public override bool Check()
    {
        //if(_ai.CurrentLife > 0)
        //{
        //    return false;
        //}
        //else
        //{
        //    return true;
        //}

        return _ai.CurrentLife <= 0;//si la vie est inférieure ou égale à 0
    }
}
