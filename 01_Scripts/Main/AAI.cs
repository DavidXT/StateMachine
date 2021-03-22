using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//namespace AITournament.PrenomN
namespace AITournament.Main
{
    public abstract class AAI : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bullet;

        private float _moveSpeed = 5;
        protected float MoveSpeed
        {
            get
            {
                return _moveSpeed;
            }
        }
        private float _jumpForce = 20;
        protected float JumpForce
        {
            get
            {
                return _jumpForce;
            }
        }

        protected NavMeshAgent _agent;

        [SerializeField]
        protected float _angularSpeed = 2;

        private float _shotCooldown = 3;
        protected float ShotCooldown
        {
            get
            {
                return _shotCooldown;
            }
        }
        private float _lastShot;

        protected virtual void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        /// <summary>
        /// Est-ce que l'IA peut tirer ou non
        /// </summary>
        /// <returns></returns>
        public bool CanShoot()
        {
            return _lastShot + _shotCooldown < Time.time;//renvoie si le cooldown est écoulé ou non
        }

        /// <summary>
        /// Instantie une bullet juste devant le joueur qui la summon
        /// </summary>
        /// <param name="rotation">Permet de modifier la direction dans laquelle la balle va partir</param>
        protected GameObject SpawnBullet(Quaternion rotation)
        {
            if(_lastShot + _shotCooldown < Time.time)//si le cooldown est fini
            {
                _lastShot = Time.time;//on réinitialise le cooldown

                //on créé une nouvelle instance de balle dans la scène juste devant le joueur et avec la rotation passée en paramètre de la méthode
                //on retourne ensuite la référence de la nouvelle instance
                GameObject tempObj = Instantiate(_bullet, transform.forward + transform.position, rotation);
                BulletsManagers.Instance.AddNewBullet(tempObj);
                return tempObj;
            }
            //Si on ne créé pas de nouvelle bullet, on ne revoie rien du tout
            return null;
        }

        /// <summary>
        /// Instantie une bullet juste devant le joueur qui la summon
        /// </summary>
        /// <param name="rotation">Permet de modifier la direction dans laquelle la balle va partir</param>
        protected GameObject SpawnBullet(Vector3 rotation)
        {
            if (_lastShot + _shotCooldown < Time.time)//si le cooldown est fini
            {
                _lastShot = Time.time;//on réinitialise le cooldown

                //on créé une nouvelle instance de balle dans la scène juste devant le joueur et avec la rotation passée en paramètre de la méthode
                //on retourne ensuite la référence de la nouvelle instance
                
                GameObject tempObj = Instantiate(_bullet, transform.forward + transform.position, Quaternion.Euler(rotation));
                BulletsManagers.Instance.AddNewBullet(tempObj);
                return tempObj;
            }
            //Si on ne créé pas de nouvelle bullet, on ne revoie rien du tout
            return null;
        }
    }
}