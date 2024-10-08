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
        #endregion

        #region MonoBehaviour
        private void Awake() {
            Cursor.lockState = CursorLockMode.Confined;
            if( !enemyManager )
                enemyManager = FindObjectOfType<EnemyManager>();
        }
        #endregion

        #region Public methods
        public void EnemyDamaged( GameObject _enemyGameObject) {
            enemyManager.DestroyEnemy( _enemyGameObject );
        }
        #endregion

        #region Private methods
        #endregion
    }
}