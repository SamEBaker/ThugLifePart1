using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
        public void StartGame ()
        {
            SceneManager.LoadScene(1);
            Debug.Log("Loaded");
        }
}
