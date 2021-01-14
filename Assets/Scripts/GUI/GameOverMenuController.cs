using UnityEngine;

namespace GUI
{
    public class GameOverMenuController : AbstractMenuController
    {
        public override void PlayLevel()
        {
#if !UNITY_EDITOR
            base.PlayLevel();
#endif
        }
    }
}
