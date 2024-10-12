/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 12/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace OneShotCat.Prototype {
	[System.Serializable]
	public class AnimationController {
		#region Variables
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private string movingBool = "movingBool";
		#endregion


		#region Contructors
		public AnimationController() {
		}
		#endregion


		#region Public methods
		public void PlayMovingAnimation() {
			animator.SetBool( movingBool, true );
		}

		public void PlayIdleAnimation() {
			animator.SetBool( movingBool, false );
		}
		#endregion
	}
}