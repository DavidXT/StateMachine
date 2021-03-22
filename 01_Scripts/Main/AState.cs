using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AState
{
    public ATransition[] Transitions;

    protected GameObject _ai;

    public AState(GameObject ai)//constructeur
    {
        _ai = ai;
        Transitions = new ATransition[0];
    }

    public virtual AState Check()//on check les transitions
    {
        foreach(ATransition transition in Transitions) //pour toutes les transitions contenues
        {
            if(transition.Check())//si la transition est valide
            {
                return transition.NextState;//on retourne le next state de la transition
            }
        }
        return null;//sinon on ne retourne rien du tout
    }

    public abstract void BeginState(); //le start du state
    public abstract void UpdateState(); //l'update du state
    public abstract void EndState(); //le end du state
}