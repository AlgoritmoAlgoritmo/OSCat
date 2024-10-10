/*
* Author: Iris Bermudez
* GitHub: https://github.com/AlgoritmoAlgoritmo
* Date: 09/10/2024 (DD/MM/YY)
*/


using UnityEngine;


public class DeformationTrap : MonoBehaviour {
	#region Variables
	[SerializeField]
	private Vector3 targetRelativeScale = new Vector3( 1, .1f, 1 );

	private Vector3 auxResultScale = new Vector3();
	#endregion

	#region Public methods
	public void DeformEnemy( GameObject _enemyGameObject ) {
		GameObject.Destroy( _enemyGameObject.GetComponent<Rigidbody>() );

		auxResultScale.x = _enemyGameObject.transform.localScale.x * targetRelativeScale.x;
		auxResultScale.y = _enemyGameObject.transform.localScale.y * targetRelativeScale.y;
		auxResultScale.z = _enemyGameObject.transform.localScale.z * targetRelativeScale.z;

		_enemyGameObject.transform.localScale = auxResultScale;
	}
	#endregion

	#region Private methods
	#endregion
}
