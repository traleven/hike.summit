using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour
{
	public string SceneName = "Default";
	public Image ProgressBar;

	private IEnumerator Start ()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		GameObject[] objects = FindObjectsOfType<GameObject>();
		AsyncOperation loading = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
		int progress = 0;
		while (!loading.isDone)
		{
			yield return new WaitForSeconds(0.1f);
			progress = (progress + 1) % 101;
			ProgressBar.fillAmount = progress / 100f;
			//yield return loading;
		}
		foreach (GameObject obj in objects)
			Destroy(obj);

		SceneManager.UnloadScene(currentScene.name);
		Debug.Log("Scene loaded");
	}
}
