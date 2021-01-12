using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenuController : MonoBehaviour
{
    public void PlayLevel()
    {
        SceneManager.LoadSceneAsync("Level");
    }    
}
