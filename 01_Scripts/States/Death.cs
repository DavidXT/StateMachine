using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : AState
{
    public Death(GameObject ai) : base(ai)
    {
    }

    public override void BeginState()
    {
        throw new System.NotImplementedException();//j'ai pas encore codé ça, ça renvoie donc une erreur dans la console
    }

    public override void UpdateState()
    {
    }

    public override void EndState()
    {
    }
}
