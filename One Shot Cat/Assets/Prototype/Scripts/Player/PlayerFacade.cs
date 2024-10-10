/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 10/10/2024 (DD/MM/YY)
*/


using System.Collections.Generic;
using UnityEngine;


namespace OneShotCat.Prototype {
	public class PlayerFacade : MonoBehaviour {
		#region Variables
		[SerializeField]
		private PlayerHPController hpController;
		[SerializeField]
		private List<string> enemyLayer = new List<string>();

		public ColliderDetection OnEnemyTouch = new ColliderDetection();
        #endregion


        #region MonoBehaviour methods
        private void Start() {
			hpController.Initialize();
		}


        private void OnCollisionEnter( Collision collision ) {
			if( enemyLayer.Contains( LayerMask.LayerToName(collision.gameObject.layer ) ) ) {
				OnEnemyTouch.Invoke( collision.gameObject );
			}
        }
        #endregion


        #region Public methods
        public void DealDamage( int _amount ) {
			hpController.DealDamage( _amount );
		}
		#endregion
	}
}