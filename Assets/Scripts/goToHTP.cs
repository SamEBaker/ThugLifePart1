using UnityEngine;
using UnityEngine.SceneManagement;

public class goToHTP : MonoBehaviour
{
        public void StartGame ()
        {
            SceneManager.LoadScene(4);
            Debug.Log("Loaded");
        }
}
