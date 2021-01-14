using UnityEngine;
using UnityEngine.SceneManagement;

namespace GUI
{
    public abstract class AbstractMenuController : MonoBehaviour
    {
        public virtual void PlayLevel()
        {
            SceneManager.LoadSceneAsync("Level");
        }    
    }    
}
