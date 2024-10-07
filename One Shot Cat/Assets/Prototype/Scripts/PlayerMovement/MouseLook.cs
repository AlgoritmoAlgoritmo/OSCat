/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 06/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace OneShotCat.Prototype {
    public class MouseLook : MonoBehaviour {
        #region Variables
        public enum RotationAxes {
            MouseX, MouseY
        }
        public RotationAxes axes = RotationAxes.MouseY;

        public static bool allowRotation = true;

        [SerializeField]
        private float mouseSensitivity = 1.7f;

        [SerializeField]
        private float minimumX = -360f;
        [SerializeField]
        private float maximumX = 360f;

        [SerializeField]
        private float minimumY = -60f;
        [SerializeField]
        private float maximumY = 60f;

        private float currentSensitivityX = 1.5f;
        private float currentSensitivityY = 1.5f;

        private float rotationX;
        private float rotationY;

        private Quaternion originalRotation;
        #endregion

        #region MonoBehaviour functions
        private void Start() {
            originalRotation = transform.rotation;
        }

        void FixedUpdate() {
            HandleRotation();
        }
        #endregion


        #region Private functions
        private void HandleRotation() {
            if( currentSensitivityX != mouseSensitivity
                || currentSensitivityY != mouseSensitivity ) {
                currentSensitivityX = currentSensitivityY = mouseSensitivity;
            }

            mouseSensitivity = currentSensitivityX;
            mouseSensitivity = currentSensitivityY;

            if( axes == RotationAxes.MouseX ) {
                rotationX += Input.GetAxis( "Mouse X" ) * mouseSensitivity;

                rotationX = ClampAngle( rotationX, minimumX, maximumX );
                Quaternion xQuaternion = Quaternion.AngleAxis( rotationX, Vector3.up );
                transform.localRotation = originalRotation * xQuaternion;


            } else if( axes == RotationAxes.MouseY ) {
                rotationY += Input.GetAxis( "Mouse Y" ) * mouseSensitivity;

                rotationY = ClampAngle( rotationY, minimumY, maximumY );
                Quaternion yQuaternion = Quaternion.AngleAxis( -rotationY, Vector3.right );
                transform.localRotation = originalRotation * yQuaternion;
            }
        }


        private float ClampAngle( float angle, float min, float max ) {
            if( angle < -360f ) {
                angle += 360f;
            } else if( angle > 360 ) {
                angle -= 360f;
            }

            return Mathf.Clamp( angle, min, max );
        }


        private void CursorControl() {
            if( Input.GetKeyDown( KeyCode.Tab ) ) {
                if( Cursor.lockState == CursorLockMode.Locked ) {
                    Cursor.lockState = CursorLockMode.None;
                } else {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
        #endregion
    }
}