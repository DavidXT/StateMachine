using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : AState
{
    private AState _currentState; //le state courant de ma SM

    public StateMachine(GameObject ai, AState currentState) : base(ai)//le constructeur
    {
        _currentState = currentState;
    }

    public override void BeginState()//le start de la SM
    {
        _currentState.BeginState();//le start du state courant
    }
    public override void UpdateState()//l'update de la SM
    {
        _currentState.UpdateState();//l'update du state courant
        CheckState();
    }
    public override void EndState()//le end de la SM
    {
        _currentState.EndState();//le end du state courant
    }


    private void CheckState()//on demande au state courant de checker ses transitions
    {
        AState tempState = _currentState.Check();//si une des transition est vrai on récupère le nouveau state
        if(tempState != null)//si le nouveau state est différent de null c'est qu'une transition est vraie
        {
            _currentState.EndState();//on demande à l'ancien state courant de faire son end
            _currentState = tempState;//on change de state courant
            _currentState.BeginState();//on demande au nouveau state courant de faire son begin
        }
    }
}