using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AITournament.David
{
    public class Init : AState
    {
        public Init(GameObject ai) : base(ai)
        {
        }

        public override void BeginState()
        {
            //start unity
        }

        public override void EndState()
        {
            //Ondestroy
        }

        public override void UpdateState()
        {
            //update unity
        }
    }
}