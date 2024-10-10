/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 07/10/2024 (DD/MM/YY)
*/


using UnityEngine;
using UnityEngine.SceneManagement;


namespace OneShotCat.Prototype {
	public class GameController : MonoBehaviour {
        #region Variables
        [SerializeField]
        private EnemyManager enemyManager;
        [SerializeField]
        private PlayerFacade playerFacade;

        [SerializeField]
        private ScoreController scoreController;
        [SerializeField]
        private GameObject pausePanel;
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField]
        private MousePreferences mousePreferences;
        #endregion


        #region MonoBehaviour methods
        private void Awake() {
            if( !enemyManager )
                enemyManager = FindObjectOfType<EnemyManager>();

            if( !playerFacade )
                playerFacade = FindObjectOfType<PlayerFacade>();
        }

        private void Start() {
            playerFacade.OnEnemyTouch.AddListener( PlayerTouchedByEnemy );
            playerFacade.OnPlayerDies.AddListener( GameOver );
            mousePreferences.Initialize();
            Pause();
        }

        private void FixedUpdate() {
            if( Input.GetKeyUp( KeyCode.Pause ) ) {
                Pause();        
            }
        }
        #endregion


        #region Public methods
        public void EnemyDamaged( GameObject _enemyGameObject) {
            DestroyEnemy( _enemyGameObject );
            scoreController.IncreaseHighScore( 100 );
        }

        public void Pause() {
            Cursor.lockState = CursorLockMode.None;
            Screen.fullScreen = false;
            pausePanel.SetActive( true );
            Time.timeScale = 0;
        }

        public void Resume() {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Screen.fullScreen = true;
            pausePanel.SetActive( false );
        }

        public void SetMouseXSensitivity( float _sensitivity ) {
            mousePreferences.SetMouseXSensitivity( _sensitivity );
        }

        public void SetMouseYSensitivity( float _sensitivity ) {
            mousePreferences.SetMouseYSensitivity( _sensitivity );
        }

        public void PlayerTouchedByEnemy( GameObject _enemyGameObject ) {
            playerFacade.DealDamage( 100 );
            _enemyGameObject.GetComponent<Collider>().enabled = false;
            DestroyEnemy( _enemyGameObject );
        }

        public void GameOver() {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            gameOverPanel.SetActive( true );
        }

        public void Restart() {
            SceneManager.LoadScene( 0 );
        }
        #endregion


        #region Private methods
        private void DestroyEnemy( GameObject _enemyGameObject ) {
            enemyManager.DestroyEnemy( _enemyGameObject );
        }
        #endregion
    }
}