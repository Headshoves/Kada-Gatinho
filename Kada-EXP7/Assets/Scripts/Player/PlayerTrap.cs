using Enemies;
using UnityEngine;

namespace Player
{
    public class PlayerTrap : MonoBehaviour
    {
        private EnemyStuck _enemyStuck;
        private Player_Essence _playerEssence;
    
        private bool _canStuck;
        private bool _playerInRange;

        [SerializeField] private int qtdEssence;

        private void Start()
        {
            _enemyStuck = transform.GetChild(0).GetComponent<EnemyStuck>();
            _playerEssence = FindObjectOfType<Player_Essence>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Attack") && _playerEssence.CanUseEnemyEssence(qtdEssence))
            {
                if (_canStuck && _playerInRange)
                {
                    _enemyStuck.StuckEnemy();
                    _playerEssence.UseEnemyEssence(qtdEssence);
                }
            }
        }

        public void CanStuck(bool can)
        {
            _canStuck = can;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerInRange = false;
            }
        }
    }
}
