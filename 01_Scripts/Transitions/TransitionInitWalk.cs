using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionInitWalk : ATransition
{
    public TransitionInitWalk(AState nextState) : base(nextState)
    {
    }

    public override bool Check()
    {
        return true; //c'est dans tout les cas vrai donc au premier check c'est valide
    }
}