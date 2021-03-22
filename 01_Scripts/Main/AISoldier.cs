using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISoldier : MonoBehaviour
{
    public int CurrentLife = 10;
   

    private StateMachine _sm;

    private void Start()
    {
        _sm = InitSM();//on initialise la SM
        _sm.BeginState(); //et on demande au state courant de faire sa première frame
    }

    private StateMachine InitSM()
    {
        //SM1
        Init tempInit = new Init(gameObject);//on créé les states de la SM1
        Walk tempWalk = new Walk(gameObject);

        StateMachine tempSM1 = new StateMachine(gameObject, tempInit);//on créé la SM1 et on ajoute Init en state courant

        TransitionInitWalk tempInitWalk = new TransitionInitWalk(tempWalk);//on créé la transition entre init et walk


        tempInit.Transitions = new ATransition[1] { tempInitWalk };//que l'on assigne à Init

        //SM0
        Death tempDeath = new Death(gameObject);//on créé les states de la SM0

        StateMachine tempSM0 = new StateMachine(gameObject, tempSM1);//on créé la SM0 avec SM1 comme state courant

        TransitionSM1Death tempSM1Death = new TransitionSM1Death(tempDeath, this);//on créé la transition entre tous les states (SM1) et death

        tempSM1.Transitions = new ATransition[1] { tempSM1Death }; //que l'on assigne à SM1

        return tempSM0; //et on retourne l'IA complétée
    }

    private void Update()
    {
        _sm.UpdateState();//on demande l'update de l'IA
    }
}