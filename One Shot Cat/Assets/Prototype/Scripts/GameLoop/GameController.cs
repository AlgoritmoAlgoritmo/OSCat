/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 07/10/2024 (DD/MM/YY)
*/


using UnityEngine;


namespace OneShotCat.Prototype {
	public class GameController : MonoBehaviour {
        #region Variables
        [SerializeField]
        private EnemyManager enemyManager;
        [SerializeField]
        private ScoreController scoreController;
        #endregion


        #region MonoBehaviour
        private void Awake() {
            if( !enemyManager )
                enemyManager = FindObjectOfType<EnemyManager>();
        }

        private void Start() {
            Pause();
        }
        #endregion


        #region Public methods
        public void EnemyDamaged( GameObject _enemyGameObject) {
            enemyManager.DestroyEnemy( _enemyGameObject );

            scoreController.IncreaseHighScore( 100 );
        }

        public void Pause() {
            Cursor.lockState = CursorLockMode.None;
            Screen.fullScreen = false;
            Time.timeScale = 0;
        }

        public void Resume() {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Screen.fullScreen = true;
        }
        #endregion


        #region Private methods
        #endregion
    }
}