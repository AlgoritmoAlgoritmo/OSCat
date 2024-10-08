/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 07/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using UnityEngine.Events;


namespace OneShotCat.Prototype {
	[RequireComponent(typeof(Collider))]
	public class CollisionDetectionController : MonoBehaviour {
		#region Variables
		public ColliderDetection onCollisionEnter = new ColliderDetection();
        public ColliderDetection onTriggerEnter = new ColliderDetection();
        #endregion

        #region MonoBehaviour methods
        private void OnCollisionEnter( Collision collision ) {
            onCollisionEnter.Invoke( collision.gameObject );
        }

        private void OnTriggerEnter( Collider collider ) {
            onTriggerEnter.Invoke( collider.gameObject );
        }
        #endregion
    }

    [System.Serializable]
    public class ColliderDetection : UnityEvent<GameObject> {
    }
}