using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour
{

	public static string levelName;
	public string level;


	public void ContinueGame()
	{
		levelName = PlayerPrefs.GetString("Updated CIIT Game Jam");
		SceneManager.LoadScene("Updated CIIT Game Jam");

	}


	public void LoadScene(string level)
	{
		levelName = level;
		SceneManager.LoadScene("Updated CIIT Game Jam");

	}

	public void MainMenu()
	{
		Time.timeScale = 1.0f;
		PlayerPrefs.SetString("Updated CIIT Game Jam", levelName);
		PlayerPrefs.Save();
		SceneManager.LoadScene("MainMenu");
	}


	public void ApplicationExitSave()
	{
		PlayerPrefs.SetString("Updated CIIT Game Jam", levelName);
		PlayerPrefs.Save();
		Application.Quit();
	}


	public void ApplicationExit()
	{
		Application.Quit();
	}


}