using UnityEngine;
using UnityEngine.SceneManagement;

public class goToCredits : MonoBehaviour
{
        public void StartGame ()
        {
            SceneManager.LoadScene(3);
            Debug.Log("Loaded");
        }
}
