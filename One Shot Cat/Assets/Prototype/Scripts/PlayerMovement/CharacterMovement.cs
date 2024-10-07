/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 06/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using UnityEngine.InputSystem;


namespace OneShotCat.Prototype {
	[RequireComponent(typeof(Rigidbody))]
	public class CharacterMovement : MonoBehaviour {
		#region Variables
		[SerializeField]
		private float speed = 1f;
		public float Speed { get; set; }

		[SerializeField]
		private PlayerInput playerInput;
		[SerializeField]
		private string actionName = "Move";

		private Rigidbody rigidBody;
		private Vector3 direction = Vector3.zero;
		private Vector2 inputValue;
		#endregion

		#region MonoBehaviour methods
		private void Awake() {
			rigidBody = GetComponent<Rigidbody>();
			if( !playerInput )
				playerInput = GetComponent<PlayerInput>();
		}

        private void FixedUpdate() {
			Move();
        }
        #endregion

        #region Private methods
        public void Move() {
			inputValue = playerInput.actions[actionName].ReadValue<Vector2>();
			direction.x = inputValue.x;
			direction.z = inputValue.y;

			rigidBody.velocity = rigidBody.rotation * direction * speed;
		}
		#endregion
	}
}