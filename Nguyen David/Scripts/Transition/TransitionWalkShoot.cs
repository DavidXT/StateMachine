using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AITournament.David
{
    public class TransitionWalkShoot : ATransition
    {
        private AISoldier _ai;

        public TransitionWalkShoot(AState nextState, AISoldier ai) : base(nextState)
        {
            _ai = ai;
        }

        public override bool Check()
        {
            return _ai.CanShootCheck();
        }
    }
}