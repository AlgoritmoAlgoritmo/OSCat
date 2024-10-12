/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 10/10/2024 (DD/MM/YY)
*/


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace OneShotCat.Prototype {
	public class PlayerFacade : MonoBehaviour {
		#region Variables
		[Header( "Camera variables" )]
		[SerializeField]
		private GameObject rearViewCamera;
		private float rearViewCameraTransitionTimeInSeconds = 0f;
		[SerializeField]
		private GameObject farViewCamera;
		private float farViewCameraTransitionTimeInSeconds = 1f;
		[SerializeField]
		private float farViewCameraActivationTimeInSeconds = 2f;
		[SerializeField]
		private Cinemachine.CinemachineBrain cinemachineBrain;


		[Header( "Animation variables" )]
		[SerializeField]
		private AnimationController animationController;


		[Header( "Input variables" )]
		[SerializeField]
		private PlayerInput playerInput;
		[SerializeField]
		private string movingActionName = "Move";


		[Header( "Other variables" )]
		[SerializeField]
		private PlayerHPController hpController;
		[SerializeField]
		private List<string> enemyLayer = new List<string>();		

		public ColliderDetection OnEnemyTouch = new ColliderDetection();
		public UnityEvent OnPlayerDies = new UnityEvent();
        #endregion


        #region MonoBehaviour methods
        private void Awake() {
			if( !playerInput )
				playerInput = FindObjectOfType<PlayerInput>();
		}

        private void Start() {
			hpController.Initialize();

			if( !cinemachineBrain )
				cinemachineBrain = FindObjectOfType<Cinemachine.CinemachineBrain>();
		}

        private void OnCollisionEnter( Collision collision ) {
			if( enemyLayer.Contains( LayerMask.LayerToName(collision.gameObject.layer ) ) ) {
				OnEnemyTouch.Invoke( collision.gameObject );
			}
        }

        private void FixedUpdate() {
			if( Input.GetKeyDown(KeyCode.E) ) {
				cinemachineBrain.m_DefaultBlend.m_Time = rearViewCameraTransitionTimeInSeconds;
				rearViewCamera.SetActive( true );

			} else if( Input.GetKeyUp( KeyCode.E ) ) {
				rearViewCamera.SetActive( false );
			}


			if( playerInput.actions[movingActionName].ReadValue<Vector2>() != Vector2.zero ) {
				animationController.PlayMovingAnimation();

			} else {
				animationController.PlayIdleAnimation();
			}
		}
        #endregion


        #region Public methods
        public void DealDamage( int _amount ) {
			hpController.DealDamage( _amount );

			if( !hpController.IsAlive() )
				OnPlayerDies.Invoke();
		}

		public void ActivateFarCamera() {
			cinemachineBrain.m_DefaultBlend.m_Time = farViewCameraTransitionTimeInSeconds;
			farViewCamera.SetActive( true );
			Invoke( "DeactivateFarCamera", farViewCameraActivationTimeInSeconds );
		}
		#endregion


		#region Private methods
		private void DeactivateFarCamera() {
			farViewCamera.SetActive( false );
		}
        #endregion
    }
}