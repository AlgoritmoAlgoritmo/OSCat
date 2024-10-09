/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 07/10/2024 (DD/MM/YY)
*/


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace OneShotCat.Prototype {
	public class EnemyManager : MonoBehaviour {
        #region Variables
        [Header( "General variables" )]
		[SerializeField]
		private Transform playerTransform;
        [SerializeField]
        private List<NavMeshAgent> enemiesNavMeshAgents = new List<NavMeshAgent>();


        [Header("Enemy spawn variables")]
        [SerializeField]
        private int maxEnemyAmount = 2;
        public int MaxEnemyAmount { get; set; }

        [SerializeField]
        private GameObject enemyPrefab;
        [SerializeField]
        private List<Transform> spawningPoints = new List<Transform>();


        private List<GameObject> enemiesToDestroy = new List<GameObject>();
        #endregion

        #region MonoBehaviour methods
        private void FixedUpdate() {
            UpdateEnemiesState();
        }
        #endregion


        #region Public methods
        public void DestroyEnemy( GameObject _enemyGameObject ) {
            enemiesToDestroy.Add( _enemyGameObject );
            _enemyGameObject.gameObject.SetActive( false );
        }

        public void UpdateEnemiesState() {
            RemoveDestroyedEnemies();
            UpdatePlayerPosition();
            AddNewEnemy();
        }
        #endregion


        #region Private methods
        private void UpdatePlayerPosition() {
            foreach( NavMeshAgent agent in enemiesNavMeshAgents ) {
                if( agent.isActiveAndEnabled )
                    agent.destination = playerTransform.position;
            }
        }


        private void RemoveDestroyedEnemies() {
            for( int i = 0; enemiesToDestroy.Count > 0; i++ ) {
                enemiesNavMeshAgents.Remove( enemiesToDestroy[0].GetComponent<NavMeshAgent>() );
                GameObject.Destroy( enemiesToDestroy[0], 2f );
                enemiesToDestroy.RemoveAt( 0 );
            }
        }

        private void AddNewEnemy() {
            if( enemiesNavMeshAgents.Count < maxEnemyAmount ) {
                enemiesNavMeshAgents.Add(   GameObject.Instantiate( enemyPrefab,
                                                spawningPoints[Random.Range( 0, spawningPoints.Count )].position,
                                                Quaternion.identity )
                                            .GetComponent<NavMeshAgent>() );                
            }
        }
        #endregion
    }
}