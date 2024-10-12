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
        private PlayerDataScriptableObject playerData;


        [SerializeField]
        private ScoreController scoreController;
        [SerializeField]
        private TMPro.TMP_Text currentScoreDisplay;
        [SerializeField]
        private TMPro.TMP_Text highestScoreDisplay;
        [SerializeField]
        private GameObject newRecordDisplay;


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
            playerData.CurrentScore = 0;
            playerFacade.OnEnemyTouch.AddListener( PlayerTouchedByEnemy );
            playerFacade.OnPlayerDies.AddListener( GameOver );
            mousePreferences.Initialize();
            gameOverPanel.SetActive( false );
            Pause();
        }

        private void FixedUpdate() {
            if( Input.GetKeyUp( KeyCode.Pause ) ) {
                Pause();        
            }
        }

        #if UNITY_EDITOR
        private void OnApplicationQuit() {
            playerData.CurrentScore = 0;
            playerData.HighestScore = 0;
        }
        #endif
        #endregion


        #region Public methods
        public void EnemyDamaged( GameObject _enemyGameObject) {
            DestroyEnemy( _enemyGameObject );
            scoreController.IncreaseHighScore( 100 );
            playerData.CurrentScore = scoreController.CurrentHighScore;
        }

        public void Pause() {
            Cursor.lockState = CursorLockMode.None;
            pausePanel.SetActive( true );
            Time.timeScale = 0;
        }

        public void Resume() {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
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
            Cursor.lockState = CursorLockMode.None;
            gameOverPanel.SetActive( true );

            currentScoreDisplay.text = playerData.CurrentScore.ToString();
            highestScoreDisplay.text = playerData.HighestScore.ToString();

            if( playerData.CurrentScore > playerData.HighestScore ) {
                newRecordDisplay.SetActive( true );
                playerData.HighestScore = playerData.CurrentScore;
            }

            Time.timeScale = 0;
        }

        public void Restart() {
            SceneManager.LoadScene( 0 );
        }

        public void TrapActivated() {
            playerFacade.ActivateFarCamera();
        }        
        #endregion


        #region Private methods
        private void DestroyEnemy( GameObject _enemyGameObject ) {
            enemyManager.DestroyEnemy( _enemyGameObject );
        }
        #endregion
    }
}