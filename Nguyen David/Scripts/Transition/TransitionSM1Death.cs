using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AITournament.David
{
    public class TransitionSM1Death : ATransition
    {
        private AISoldier _ai;

        public TransitionSM1Death(AState nextState, AISoldier ai) : base(nextState)
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

            return false; //si elle n'est jamais vraie, autant ne pas la mettre non ?
        }
    }
}
