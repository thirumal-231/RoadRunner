using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    private int gameSceneBuildIndex = 1;
    private int titleSceneBuildIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void LoadGameSequence()
    {
        Invoke( "LoadGame", 2f );
    }
    public void LoadGame()
    {
        ScoreManager.Instance.worldSpeed = 30;
        SceneManager.LoadScene( gameSceneBuildIndex );
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene( titleSceneBuildIndex );
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
