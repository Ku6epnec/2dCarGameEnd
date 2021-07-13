using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class Localization : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private TMP_Text _rewardText;
    [SerializeField]
    private TMP_Text _startText;
    [SerializeField]
    private TMP_Text _exitText;
    [SerializeField]
    private TMP_Text _russianText;
    [SerializeField]
    private TMP_Text _englishText;
    [SerializeField]
    private TMP_Text _bundleText;
    [SerializeField]
    private TMP_Text _notificationText;
    [SerializeField]
    private TMP_Text _prefabText;
    [SerializeField]
    private Button _russianButton;
    [SerializeField]
    private Button _englishButton;

    #endregion

    #region UnityMethods

    private void Start()
    {
        ChangedLocaleEvent(null);
        LocalizationSettings.SelectedLocaleChanged += ChangedLocaleEvent;

        _russianButton.onClick.AddListener(() => ChangeLanguage(1));
        _englishButton.onClick.AddListener(() => ChangeLanguage(0));
    }

    private void OnDestroy()
    {
        _russianButton.onClick.RemoveAllListeners();
        _englishButton.onClick.RemoveAllListeners();
    }

    private void ChangedLocaleEvent(Locale locale)
    {
        StartCoroutine(OnChangedLocale(locale));
    }

    private IEnumerator OnChangedLocale(Locale locale)
    {
        var loadingOperation = LocalizationSettings.StringDatabase.GetTableAsync("Language");
        yield return loadingOperation;

        if (loadingOperation.Status == AsyncOperationStatus.Succeeded)
        {
            var table = loadingOperation.Result;
            _rewardText.text = table.GetEntry("reward_menu")?.GetLocalizedString();
            _startText.text = table.GetEntry("start")?.GetLocalizedString();
            _exitText.text = table.GetEntry("exit")?.GetLocalizedString();
            _russianText.text = table.GetEntry("russian")?.GetLocalizedString();
            _englishText.text = table.GetEntry("english")?.GetLocalizedString();
            _bundleText.text = table.GetEntry("load_bundle")?.GetLocalizedString();
            _notificationText.text = table.GetEntry("notification")?.GetLocalizedString();
            _prefabText.text = table.GetEntry("load_prefab")?.GetLocalizedString();

        }
        else
        {
            Debug.Log("Could not load String Table\n" + loadingOperation.OperationException);
        }
    }

    private void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    #endregion
}
