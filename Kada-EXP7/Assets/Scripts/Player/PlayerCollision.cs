using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private Player_Essence _playerEssence;
        private Player_Manager _playerManager;

        [SerializeField] private LayerMask layer;
    
        private bool _inAir;
        private Transform _groundCheck;

        private void Start()
        {
            _groundCheck = transform.GetChild(0);
            _playerEssence = GetComponent<Player_Essence>();
            _playerManager = GetComponent<Player_Manager>();
        }
    
        private void FixedUpdate()
        {
            _inAir = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, layer);
        }

        public bool IsInAir()
        {
            return !_inAir;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("StoneEssence"))
            {
                _playerEssence.AddStoneEssence(1);
                col.gameObject.SetActive(false);
            }
        
            if (col.gameObject.CompareTag("TreeEssence"))
            {
                _playerEssence.AddTreeEssence(1);
                col.gameObject.SetActive(false);
            }
        
            if (col.gameObject.CompareTag("EnemyEssence"))
            {
                _playerEssence.AddEnemyEssence(1);
                col.gameObject.SetActive(false);
            }

            if (col.CompareTag("Checkpoint"))
            {
                _playerManager._playerStartPos = transform.position;
            }
        }
    }
}
