/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 10/10/2024 (DD/MM/YY)
*/



using UnityEngine;


namespace OneShotCat.Prototype {
	[System.Serializable]
	public class PlayerHPController {
		#region Variables
		[SerializeField]
		private UnityEngine.UI.Image healthBar;

		[SerializeField]
		private int maxHP = 1000;
		private int currentHP;
		#endregion

		#region Public methods
		public void Initialize() {
			currentHP = maxHP;
			RefreshHealthBar();
		}

		public void DealDamage( int _damageAmount ) {
			currentHP -= _damageAmount;
			RefreshHealthBar();
		}
		#endregion

		#region Private methods
		private void RefreshHealthBar() {
			healthBar.fillAmount = (float)currentHP / (float)maxHP;
		}
		#endregion
	}
}