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
        #endregion

        #region Public methods
        private void FixedUpdate() {
            foreach( NavMeshAgent agent in enemiesNavMeshAgents ) {
                agent.destination = playerTransform.position;
            }            
        }
        #endregion
    }
}