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
        [SerializeField]
        private List<NavMeshAgent> enemiesNavMeshAgents = new List<NavMeshAgent>();
		[SerializeField]
		private Transform playerTransform;

        private List<GameObject> enemiesToDestroy = new List<GameObject>();
        #endregion

        #region MonoBehaviour methods
        private void FixedUpdate() {
            foreach( NavMeshAgent agent in enemiesNavMeshAgents ) {
                if( agent.isActiveAndEnabled )
                    agent.destination = playerTransform.position;
            }

            CheckEnemiesState();
        }
        #endregion


        #region Public methods
        public void DestroyEnemy( GameObject _enemyGameObject ) {
            enemiesToDestroy.Add( _enemyGameObject );
            _enemyGameObject.gameObject.SetActive( false );
        }

        public void CheckEnemiesState() {
            for( int i = 0; enemiesToDestroy.Count > 0; i++ ) {
                enemiesNavMeshAgents.Remove( enemiesToDestroy[0].GetComponent<NavMeshAgent>() );
                GameObject.Destroy( enemiesToDestroy[0], 2f );
                enemiesToDestroy.RemoveAt( 0 );
            }
        }
        #endregion
    }
}