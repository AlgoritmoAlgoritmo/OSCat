/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 10/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace OneShotCat.Prototype {
	[System.Serializable]
	public class MousePreferences {
		#region Variables
		[SerializeField]
		private RigidBodyRotation rigidbodyRotationController;
		[SerializeField]
		private MouseLook mouseLook;


		[SerializeField]
		private float defaultXSensitivity = .8f;
		[SerializeField]
		private float defaultYSensitivity = 1.7f;
		[SerializeField]
		private UnityEngine.UI.Slider xSensitivitySlider;
		[SerializeField]
		private UnityEngine.UI.Slider ySensitivitySlider;
		#endregion

		#region Public methods
		public void Initialize() {
			xSensitivitySlider.value = defaultXSensitivity;
			SetMouseXSensitivity( defaultXSensitivity );

			ySensitivitySlider.value = defaultYSensitivity;
			SetMouseYSensitivity( defaultYSensitivity );
		}

		public void SetMouseXSensitivity( float _sensitivity ) {
			rigidbodyRotationController.MouseSensitivity = _sensitivity;
		}

		public void SetMouseYSensitivity( float _sensitivity ) {
			mouseLook.MouseSensitivity = _sensitivity;
		}
		#endregion

		#region Private methods
		#endregion
	}
}