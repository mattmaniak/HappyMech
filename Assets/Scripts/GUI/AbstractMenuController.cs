using UnityEngine;
using UnityEngine.SceneManagement;

namespace GUI
{
    public abstract class AbstractMenuController : MonoBehaviour
    {
        protected const string levelName = "Level";

        public virtual void PlayLevel()
        {
            SceneManager.LoadSceneAsync(levelName);
        }    
    }    
}
