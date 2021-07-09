using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleBase : MonoBehaviour
{
    private const string UrlAssetBundleSprite = "https://github.com/Ku6epnec/Bundles/raw/master/LZMA/menubundle";
    private const string UrlAssetBundleAudio = "https://github.com/Ku6epnec/Bundles/raw/master/LZMA/audiobundle";

    [SerializeField]
    private DataSpriteBundle[] _dataSpriteBundles;

    [SerializeField]
    private DataAudioBundle[] _dataAudioBundles;

    private AssetBundle _spriteAssetBundle;
    private AssetBundle _audioAssetBundle;

    protected IEnumerator DownloadAndSetAssetBundle()
    {
        yield return GetSpriteAssetBundle();
        yield return GetAudioAssetBundle();

        if (_spriteAssetBundle == null || _audioAssetBundle == null)
        {
            Debug.LogError("Error Download");
            yield break;
        }

        SetAssetBundle();
        yield return null;
    }

    private IEnumerator GetSpriteAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprite);
        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        GetContentAssetBundle(request, ref _spriteAssetBundle);
    }

    private IEnumerator GetAudioAssetBundle()
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);
        yield return request.SendWebRequest();

        while (!request.isDone)
            yield return null;

        GetContentAssetBundle(request, ref _audioAssetBundle);
    }

    private void GetContentAssetBundle(UnityWebRequest request, ref AssetBundle assetBundle)
    {
        if (request.error == null)
        {
            assetBundle = DownloadHandlerAssetBundle.GetContent(request);
            Debug.Log("Download mission Completed!");
        }

        else
        {
            Debug.LogError(request.error);
        } 
            
    }

    private void SetAssetBundle()
    {
        foreach (var data in _dataSpriteBundles)
            data.Image.sprite = _spriteAssetBundle.LoadAsset<Sprite>(data.NameAssetBundle);

        foreach (var data in _dataAudioBundles)
        {
            data.AudioSource.clip = _audioAssetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
            data.AudioSource.Play();
        }
    }
}
