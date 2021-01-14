using UnityEngine;
using UnityEngine.SceneManagement;

namespace GUI
{
    public abstract class AbstractMenuController : MonoBehaviour
    {
        public void PlayLevel()
        {
            SceneManager.LoadSceneAsync("Level");
        }    
    }    
}
