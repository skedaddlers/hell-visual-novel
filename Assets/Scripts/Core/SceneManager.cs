using UnityEngine;
using RS;

public class SceneManager : PersistentSingleton<SceneManager>
{
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
