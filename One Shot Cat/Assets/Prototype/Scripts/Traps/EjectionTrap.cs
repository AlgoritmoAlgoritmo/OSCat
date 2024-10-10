/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 09/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace OneShotCat.Prototype {
	public class EjectionTrap : MonoBehaviour {
		#region Variables
		[SerializeField]
		private Vector3 force = new Vector3(0, 100, 0);

		private Rigidbody auxRigidbody;
		#endregion

		#region Public methods
		public void ApplyForceToEnemy( GameObject _enemyGameObject ) {
			auxRigidbody = _enemyGameObject.GetComponent<Rigidbody>();
			auxRigidbody.useGravity = true;
			auxRigidbody.AddForce( force );
		}
		#endregion

		#region Private methods
		#endregion
	}
}