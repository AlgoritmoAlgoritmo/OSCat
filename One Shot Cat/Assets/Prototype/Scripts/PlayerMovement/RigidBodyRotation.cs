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
        public float MouseSensitivity {
            get { return mouseSensitivity; }
            set { 
                mouseSensitivity = value;
                Debug.Log( mouseSensitivity );
            } 
        }

        [SerializeField]
        private float minimumX = -360f;
        [SerializeField]
        private float maximumX = 360f;


        private Rigidbody rigidBody;
        private Vector3 eulerTargetRotation = Vector3.zero;
        #endregion

        #region MonoBehaviour
        private void Start() {
            rigidBody = GetComponent<Rigidbody>();

            eulerTargetRotation.y = rigidBody.rotation.eulerAngles.y;
        }

        private void FixedUpdate() {
            Rotate();
        }
        #endregion

        #region Public methods
        public void Rotate() {
            eulerTargetRotation.y += ClampAngle( (Input.GetAxis( "Mouse X" ) * mouseSensitivity), minimumX, maximumX );
            rigidBody.rotation = Quaternion.Euler( eulerTargetRotation );
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