using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
        public void StartGameAgain ()
        {
            SceneManager.LoadScene(1);
            Debug.Log("Loaded");
        }
}
