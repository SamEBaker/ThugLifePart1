using UnityEngine;
using UnityEngine.SceneManagement;

public class goMenu : MonoBehaviour
{
        public void StartGame ()
        {
            SceneManager.LoadScene(0);
            Debug.Log("Loaded");
        }
}
