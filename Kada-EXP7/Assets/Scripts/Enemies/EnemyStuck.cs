using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyStuck : MonoBehaviour
    {
        private PlayerTrap _playerTrap;
        private EnemyPatrol _enemyPatrol;
        
        private Vector2 _startPos;
        private Collider2D _col;
        private Animator _animator;
        private Vector3 target;
        
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
                transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
                    0.5f);
            }
        }
    }
}
