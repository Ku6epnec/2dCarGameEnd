using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : AssetBundleBase
    {
        [SerializeField] 
        private Button _buttonStart;

        [SerializeField]
        private Button _buttonDailyReward;

        [SerializeField]
        private Button _buttonExit;

        [SerializeField]
        private Button _loadAssetBundle;

        private void Start()
        {
            _loadAssetBundle.onClick.AddListener(LoadAsset);
        }

        public void Init(UnityAction startGame, UnityAction watchDailyReward)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonDailyReward.onClick.AddListener(watchDailyReward);
            _buttonExit.onClick.AddListener(Exit);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
            _buttonDailyReward.onClick.RemoveAllListeners();
            _loadAssetBundle.onClick.RemoveAllListeners();
        }

        private void LoadAsset()
        {
            _loadAssetBundle.interactable = false;

            StartCoroutine(DownloadAndSetAssetBundle());
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}

