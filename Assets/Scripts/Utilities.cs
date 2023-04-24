using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Utilities
{
	public static int playerDeaths = 0;

	public static string UpdateDeathCount(ref int countReference)
	{
		countReference += 1;
		return "Next time you'll be at " + countReference + " deaths. Try harder would ya?";
	}
	public static void RestartLevel()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 1.0f;
		Debug.Log("Player deaths: " + playerDeaths);
		string message = UpdateDeathCount(ref playerDeaths);
		Debug.Log("Player deaths: " + playerDeaths);
	}
}