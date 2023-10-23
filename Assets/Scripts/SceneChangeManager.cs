using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    private static SceneChangeManager _instance;

    public static SceneChangeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("SceneChangeManager is null");
            }

            return _instance;
        }
    }
    
    private void Awake()
    {
        _instance = this;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
