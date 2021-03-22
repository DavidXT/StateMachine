using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AITournament.David
{
    public class TransitionInitWalk : ATransition
    {
        public TransitionInitWalk(AState nextState) : base(nextState)
        {
        }

        public override bool Check()
        {
            return true;
        }
    }
}