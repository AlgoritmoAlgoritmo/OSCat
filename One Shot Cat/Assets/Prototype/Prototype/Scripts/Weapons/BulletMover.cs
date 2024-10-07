/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 07/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace OneShotCat.Prototype {
	[RequireComponent(typeof(Rigidbody))]
	public class BulletMover : MonoBehaviour {
		#region Variables
		[SerializeField]
		private float speed = 1f;
        #endregion

        #region Public methods
        private void Start() {
            GetComponent<Rigidbody>().AddForce( speed * transform.forward );
        }
        #endregion
    }
}