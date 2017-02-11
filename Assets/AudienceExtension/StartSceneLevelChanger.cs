using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneLevelChanger : MonoBehaviour {

    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
