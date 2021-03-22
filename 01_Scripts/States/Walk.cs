using AITournament.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//namespace AITournament.PrenomN
public class Walk : AState
{
    private Transform _target;

    private NavMeshAgent _agent;

    private List<GameObject> _players;

    public Walk(GameObject ai) : base(ai)
    {
        _agent = _ai.GetComponent<NavMeshAgent>();
    }

    public override void BeginState()
    {
        //_target = GameObject.FindGameObjectWithTag("Player").transform;//on récupère une target qui est pour le coup un joueur (/!\ pas fonctionnel pour vendredi)
        _agent.isStopped = false;//on s'assure que le NavMeshAgent est disponible pour bouger

        _target = NearestPlayer();
    }

    private Transform NearestPlayer()//on cherche le joueur le plus proche (vol d'oiseau)
    {
        _players = PlayersManagers.Instance.LivingPlayers;//on récupère tous les joueurs
        Transform tempResult = null;//on initialize les variables
        float tempDistance = 0;

        for(int i = 0; i < _players.Count; ++i)//on parcours toutes la liste des joueurs (vivants)
        {
            //merci JC
            if(_players[i] == _ai)//Si c'est nous même
            {
                continue;//on passe au suivant
            }

            float tempNewDistance = Vector3.Distance(_ai.transform.position, _players[i].transform.position);//on calcule la distance entre le joueur[i] et notre ia
            //merci JC
            if(tempNewDistance < tempDistance || tempResult == null)//si cette distance est plus courte
            {
                tempDistance = tempNewDistance;//on sauvegarde les infos 
                tempResult = _players[i].transform;
            }
        }

        return tempResult; //on retourne le transform du joueur le plus proche
    }

    public override void UpdateState()
    {

        _agent.SetDestination(_target.position);//on change la destination de l'agent qui se met à marcher automatiquement


    }

    public override void EndState()
    {
        _agent.isStopped = true;//on s'assure de bien arrêter l'agent (on ne veut pas le faire marcher dans tout les states
    }
}