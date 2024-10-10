/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 07/10/2024 (DD/MM/YY)
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace OneShotCat.Prototype {
	public class WeaponController : MonoBehaviour {
		#region Variables
		[SerializeField]
		private Transform origin;
		[SerializeField]
		private GameObject projectilePrefab;

        [SerializeField]
        private PlayerInput playerInput;
        [SerializeField]
        private string shootActionName = "Shoot";

        [SerializeField]
        private float maxAimingDistance = 500f;

        private RaycastHit hit = new RaycastHit();
        #endregion

        #region MonoBehaviour
        private void FixedUpdate() {
            Shoot();
        }
        #endregion

        #region Public methods
        public void Shoot() {
            FixRotation();

            if( playerInput.actions[shootActionName].triggered ) {
                InstantiateProjectile();
            }
        }
        #endregion

        #region Private methods
        private void FixRotation() {
            // Raycasting from camera's position
            if( Physics.Raycast( Camera.main.transform.position,
                                Camera.main.transform.TransformDirection( Vector3.forward ),
                                out hit,
                                maxAimingDistance ) ) {
                transform.LookAt( hit.point );

            } else {
                transform.LookAt( Camera.main.transform.TransformDirection( Vector3.forward ) * maxAimingDistance );
            }
        }

        private void InstantiateProjectile() {
            Instantiate( projectilePrefab, origin.position, origin.rotation );
        }
        #endregion
    }
}