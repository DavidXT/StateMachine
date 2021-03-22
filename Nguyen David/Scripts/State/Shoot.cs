using System.Collections;
using UnityEngine;


namespace AITournament.David
{
    public class Shoot : AState
    {
        private AISoldier _soldier;
        private const float _maxAngle = 180;

        public Shoot(GameObject ai, AISoldier soldier) : base(ai)
        {
            _soldier = soldier;
        }

        public override void BeginState()
        {
            Vector3 tempDirection = _soldier._target.position - _soldier.transform.position; //on calcule la direction de la target
            float tempNewDistance = Vector3.Distance(_soldier.transform.position, _soldier._target.transform.position);
            if (Vector3.Angle(_soldier.transform.forward, tempDirection) < _maxAngle) //Si la target est dans l'angle de visée
            {
                GameObject tempObj = _soldier.Shoot(Quaternion.identity);//on tire
                tempObj?.transform.LookAt(_soldier._target.position);
                if(tempNewDistance < 10)//attention aux magic numbers
                {
                    _soldier.transform.position -= tempDirection;//Petit knockback après avoir tiré
                    //ton knockback est proportionnel à la distance de ton adversaire, si tu veux que ça soit toujours la même :
                    //_soldier.transform.position -= tempDirection.normalized * _knockbackForce;
                }
            }
        }

        public override void UpdateState()
        {
        }

        public override void EndState()
        {
        }
    }
}