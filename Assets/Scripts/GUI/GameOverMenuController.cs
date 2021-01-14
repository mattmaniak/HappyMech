using UnityEngine;

namespace GUI
{
    public class GameOverMenuController : AbstractMenuController
    {
        [SerializeField]
        GameObject androidFakePurchaseText;

        [SerializeField]
        GameObject iapFakePurchaseText;

        void Awake()
        {
#if UNITY_EDITOR
            androidFakePurchaseText.SetActive(false);
#else
            unityEditorFakePurchaseText.SetActive(false);
#endif
        }

        public override void PlayLevel()
        {
#if !UNITY_EDITOR
            base.PlayLevel();
#endif
        }
    }
}
