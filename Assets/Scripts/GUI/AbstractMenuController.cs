using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AbstractMenuController : MonoBehaviour
{
    public void PlayLevel()
    {
        SceneManager.LoadSceneAsync("Level");
    }    
}
