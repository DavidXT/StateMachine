using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AITournament.Main;

namespace AITournament.David
{
    public class AISoldier : AAI
    {
        private StateMachine _sm;
        public Transform _target;

        private void Start() //il existe déjà un Start dans AAI, dont tu hérites
        {
            _sm = InitSM();
            _sm.BeginState();
        }

        private StateMachine InitSM()
        {
            //SM1 Init => Walk => Shoot => Walk
            Init tempInit = new Init(gameObject);
            Walk tempWalk = new Walk(gameObject, this);
            Shoot tempShoot = new Shoot(gameObject, this);


            StateMachine tempSM1 = new StateMachine(gameObject, tempInit);

            TransitionInitWalk tempInitWalk = new TransitionInitWalk(tempWalk);
            TransitionWalkShoot tempWalkShoot = new TransitionWalkShoot(tempShoot, this);
            TransitionShootWalk tempShootWalk = new TransitionShootWalk(tempWalk, this);

            tempInit.Transitions = new ATransition[1] { tempInitWalk };
            tempWalk.Transitions = new ATransition[1] { tempWalkShoot };
            tempShoot.Transitions = new ATransition[1] { tempShootWalk };

            //SM0
            Death tempDeath = new Death(gameObject);

            StateMachine tempSM0 = new StateMachine(gameObject, tempSM1);

            TransitionSM1Death tempSM1Death = new TransitionSM1Death(tempDeath, this);

            tempSM1.Transitions = new ATransition[1] { tempSM1Death };

            return tempSM0;
        }

        private void Update()
        {
            _sm.UpdateState();
        }

        //Check si CD disponible et pas de mur
        public bool CanShootCheck()
        {
            //Check si le CD est disponible
            if (CanShoot())
            {
                //RayCast pour check si il y'a un mur entre le joueur et la target
                RaycastHit temphit;
                if (Physics.Raycast(transform.position, _target.position - transform.position, out temphit))
                {
                    if (temphit.transform == _target)
                    {
                        return true;
                    }
                    //on peut simplifier : 
                    //return temphit.transform == _target;
                }
            }
            return false;
        }

        //Méthode héritage AAI pour les States
        public GameObject Shoot(Quaternion q)
        {
            if (q != null)
            {
                GameObject tempBullet = SpawnBullet(q);
                return tempBullet;
            }
            return null;
        }
        public GameObject Shoot(Vector3 v)
        {
            if (v != null)
            {
                GameObject tempBullet = SpawnBullet(v);
                return tempBullet;
            }
            return null;
        }
    }
}