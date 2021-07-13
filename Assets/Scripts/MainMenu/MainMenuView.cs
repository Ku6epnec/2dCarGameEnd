using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


namespace Ui
{
    public class MainMenuView : AssetBundleBase
    {
        #region Fields

        [SerializeField] 
        private Button _buttonStart;
        [SerializeField]
        private Button _buttonDailyReward;
        [SerializeField]
        private Button _buttonExit;
        [SerializeField]
        private Button _loadAssetBundle;
        [SerializeField]
        private Button _loadPrefab;

        [SerializeField]
        private RectTransform _mountRoot;
        [SerializeField]
        private AssetReference _assetReference;

        private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new List<AsyncOperationHandle<GameObject>>();

        #endregion

        #region UnityMethods

        private void Start()
        {
            _loadAssetBundle.onClick.AddListener(LoadAsset);
            _loadPrefab.onClick.AddListener(LoadPrefab);
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
            _loadPrefab.onClick.RemoveAllListeners();

            foreach (var addressablePrefab in _addressablePrefabs)
            {
                Addressables.ReleaseInstance(addressablePrefab);
            }

            _addressablePrefabs.Clear();
        }

        #endregion

        #region Methods

        private void LoadAsset()
        {
            _loadAssetBundle.interactable = false;

            StartCoroutine(DownloadAndSetAssetBundle());
        }

        private void LoadPrefab()
        {
            var addressablePrefab = Addressables.InstantiateAsync(_assetReference, _mountRoot);
            _addressablePrefabs.Add(addressablePrefab);
        }

        private void Exit()
        {
            Application.Quit();
        }

        #endregion
    }
}

