using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
        public void Quit ()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
}
