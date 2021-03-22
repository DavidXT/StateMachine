using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AITournament.Main
{
    public class PlayersManagers : MonoBehaviour
    {
        //singleton
        public static PlayersManagers Instance;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        //fin singleton

        private Text _alive;
        private Text _dead;

        [SerializeField]
        private List<string> _playersName, _playersDead;

        public List<GameObject> LivingPlayers;

        private void Start()
        {
            _alive = GameObject.FindGameObjectWithTag("Alive").GetComponent<Text>();
            _dead = GameObject.FindGameObjectWithTag("Dead").GetComponent<Text>();

            _playersName = new List<string>();//on initialise les listes des joueurs vivants et morts
            _playersDead = new List<string>();
            LivingPlayers = new List<GameObject>();

            //on récupère tous les joueurs et on les ajoutes aux vivants
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
            {
                LivingPlayers.Add(obj);
                _playersName.Add(obj.name);
            }
            ChangeDisplay();
        }

        private void Update()
        {
            for (int i = LivingPlayers.Count; i > 0; --i)
            {
                if (LivingPlayers[i].transform.position.y >= -5)
                {
                    PlayerDied(LivingPlayers[i]);
                    Destroy(LivingPlayers[i]);
                }
            }
        }

        public void PlayerDied(GameObject player)//quand un joueur meurt
        {
            LivingPlayers.Remove(player);//on enlève le joueur des objets vivants
            _playersName.Remove(player.name);//on l'enlève des vivants
            _playersDead.Add(player.name);//et on l'ajoute aux morts
            ChangeDisplay();
        }

        private void ChangeDisplay()
        {
            _alive.text = "Alive :\n";
            foreach(string name in _playersName)
            {
                _alive.text += name + "\n";
            }
            _dead.text = "Dead :\n";
            foreach (string name in _playersDead)
            {
                _dead.text += name + "\n";
            }
        }
    }
}