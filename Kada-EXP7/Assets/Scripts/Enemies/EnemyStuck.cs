using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyStuck : MonoBehaviour
    {
        private PlayerTrap _playerTrap;
        private EnemyPatrol _enemyPatrol;
        void Start()
        {
            _playerTrap = transform.GetComponentInParent<PlayerTrap>();
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                _playerTrap.CanStuck(true);
                _enemyPatrol = col.GetComponent<EnemyPatrol>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                _playerTrap.CanStuck(false);
                _enemyPatrol = null;
            }
        }

        public void StuckEnemy()
        {
            if (_enemyPatrol != null)
            {
                _enemyPatrol.enabled = false;
            }
        }
    }
}
