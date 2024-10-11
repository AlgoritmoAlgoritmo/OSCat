/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 11/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace OneShotCat.Prototype {
	[CreateAssetMenu(fileName = "new PlayerDataScriptableObject", menuName = "OneShotTraps/Player Data" )]
	public class PlayerDataScriptableObject : ScriptableObject {
		#region Variables
		[SerializeField]
		private int currentScore;
		public int CurrentScore {
			get {
				return currentScore;
			}
			set {
				currentScore = value;
			} 
		}

		[SerializeField]
		private int highestScore;
		public int HighestScore {
			get {
				return highestScore;
			}
			set {
				highestScore = value;
			}
		}
		#endregion
	}
}