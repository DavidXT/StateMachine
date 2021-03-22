using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AITournament.David
{
    public class TransitionShootWalk : ATransition
    {
        private AISoldier _ai;

        public TransitionShootWalk(AState nextState, AISoldier ai) : base(nextState)
        {
            _ai = ai;
        }

        public override bool Check()
        {
            return !_ai.CanShootCheck();
        }
    }
}