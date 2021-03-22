using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AITournament.Main;

namespace AITournament.David{
    public class Walk : AState
    {
        private Transform _target;

        private NavMeshAgent _agent;

        private List<GameObject> _players;

        private AISoldier _soldier;


        public Walk(GameObject ai, AISoldier soldier) : base(ai)
        {
            _agent = _ai.GetComponent<NavMeshAgent>();
            _soldier = soldier;
        }

        public override void BeginState()
        {
            _agent.isStopped = false;
            _agent.enabled = true;
            NearestPlayer();
        }

        //Fonction pour récupérer le joueur le plus proche
        private void NearestPlayer()
        {
            _players = PlayersManagers.Instance.LivingPlayers;
            float tempDistance = 0;//attention aux magic numbers
            for (int i = 0; i < _players.Count; i++)
            {
                if(_players[i] == _ai)
                {
                    continue;
                }
                float tempNewDistance = Vector3.Distance(_ai.transform.position, _players[i].transform.position);
                if(tempNewDistance < tempDistance || tempDistance == 0)
                {
                    tempDistance = tempNewDistance;
                    _target = _players[i].transform;
                }
            }
            _soldier._target = _target;
        }

        //Récupérer la distance entre le joueur et la target
        public float DistanceTarget()
        {
            return Vector3.Distance(_target.position, _soldier.transform.position);
        }

        public override void UpdateState()
        {
            if (_target)
            {
                _agent.SetDestination(_target.position);
            }
            else NearestPlayer();
        }


        public override void EndState()
        {
            if(_players == null)//je ne vois pas l'utilité de ces lignes
            {
                return;
            }
        }
    }
}