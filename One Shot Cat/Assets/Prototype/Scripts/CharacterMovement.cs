/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 06/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using UnityEngine.InputSystem;


namespace OneShotCat.Prototype {
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent( typeof( PlayerInput ) )]
	public class CharacterMovement : MonoBehaviour {
		#region Variables
		[SerializeField]
		private float speed = 1f;
		public float Speed { get; set; }

		[SerializeField]
		private string actionName = "Move";


		private  Rigidbody rigidBody;
		private PlayerInput playerInput;
		#endregion

		#region Public methods
		private void Awake() {
			rigidBody = GetComponent<Rigidbody>();
			playerInput = GetComponent<PlayerInput>();
		}

        private void FixedUpdate() {
			Move( playerInput.actions[actionName].ReadValue<Vector2>() );
		}
        #endregion

        #region Private methods
        private void Move( Vector3 _direction ) {
			rigidBody.velocity = _direction * speed;
		}
		#endregion
	}
}