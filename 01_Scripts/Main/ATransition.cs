using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATransition
{
    public AState NextState; //le state suivant (après validation de la transition)

    public ATransition(AState nextState)//le constructeur
    {
        NextState = nextState;
    }

    public abstract bool Check();//on check si la transition est valide ou non
}