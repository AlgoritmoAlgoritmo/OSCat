/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 08/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using TMPro;


namespace OneShotCat.Prototype {
	[System.Serializable]
	public class ScoreController {
		#region Variables
		[SerializeField]
		private TMP_Text scoreText;
		
		[SerializeField]
		private int currentHighScore;
		public int CurrentHighScore {
			get {
				return currentHighScore;
			}
		}
		#endregion

		#region Constructors methods
		public ScoreController( TMP_Text _scoreText ) {
			scoreText = _scoreText;
			currentHighScore = 0;
		}
		#endregion

		#region Public methods
		public void IncreaseHighScore( int _score ) {
			currentHighScore += _score;
			scoreText.text = currentHighScore.ToString();
		}
		#endregion

		#region Private methods
		#endregion
	}
}