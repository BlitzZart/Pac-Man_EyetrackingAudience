using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
