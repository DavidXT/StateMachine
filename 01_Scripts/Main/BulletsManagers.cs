using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AITournament.Main
{
    public class BulletsManagers : MonoBehaviour
    {
        //Singleton
        public static BulletsManagers Instance;
        private void Awake()
        {
            Instance = this;
        }
        //fin singleton

        public List<GameObject> Bullets;

        private void Start()
        {
            Bullets = new List<GameObject>();//on initialize la liste
        }

        public void AddNewBullet(GameObject bullet)
        {
            Bullets.Add(bullet);//on ajoute la bullet
        }
        public void RemoveBullet(GameObject bullet)
        {
            Bullets.Remove(bullet);//on retire la bullet
        }

        private void Update()
        {
            foreach(GameObject bullet in Bullets)//on fait l'update des bullets pour l'opti du code
            {
                bullet.GetComponent<Bullet>().UpdateBullet();
            }
        }
    }
}