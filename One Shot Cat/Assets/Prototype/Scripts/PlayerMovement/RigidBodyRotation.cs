/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 07/10/2024 (DD/MM/YY)
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneShotCat.Prototype {
    [RequireComponent(typeof(Rigidbody))]
	public class RigidBodyRotation : MonoBehaviour {
        #region Variables
        [SerializeField]
        private float mouseSensitivity = 1f;

        [SerializeField]
        private float minimumX = -360f;
        [SerializeField]
        private float maximumX = 360f;


        private Rigidbody rigidBody;
        private Vector3 eulerAngleVelocity;

        #endregion

        #region MonoBehaviour
        private void Start() {
            rigidBody = GetComponent<Rigidbody>();

            //Set the angular velocity of the Rigidbody (rotating around the Y axis, 100 deg/sec)
            eulerAngleVelocity = Vector3.zero;
        }

        private void FixedUpdate() {
            Rotate();
        }
        #endregion

        #region Public methods
        public void Rotate() {
            eulerAngleVelocity.y += ClampAngle( Input.GetAxis( "Mouse X" ) * mouseSensitivity * -1, minimumX, maximumX );

            Quaternion deltaRotation = Quaternion.Euler( -eulerAngleVelocity );
            rigidBody.MoveRotation( deltaRotation );
        }
        #endregion

        #region Private methods
        private float ClampAngle( float angle, float min, float max ) {
            if( angle < -360f ) {
                angle += 360f;
            } else if( angle > 360 ) {
                angle -= 360f;
            }

            return Mathf.Clamp( angle, min, max );
        }
        #endregion
    }
}