using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadingManager
{
    private static int _newSceneIndex;

    public static void Load(int newSceneIndex)
    {
        _newSceneIndex = newSceneIndex;
        SceneManager.LoadScene(2);
    }

    public static void OnLoadingScreenLoaded(Loader loader)
    {
        loader.LoadScene(_newSceneIndex);
    }
}
