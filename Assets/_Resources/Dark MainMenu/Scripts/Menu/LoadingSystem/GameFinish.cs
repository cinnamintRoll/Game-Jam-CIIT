using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{

	public string level;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.transform.CompareTag("Player")) // You Tag
		{
			LoadLevel.levelName = level;
			SceneManager.LoadScene("Updated CIIT Game Jam");
		}
	}
}