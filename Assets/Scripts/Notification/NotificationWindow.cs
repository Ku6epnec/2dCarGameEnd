using System;
using Unity.Notifications.Android;
using Unity.Notifications.iOS;
using UnityEngine;
using UnityEngine.UI;

public class NotificationWindow : MonoBehaviour
{
    private const string AndroidNotifierId = "android_notifier_id";

    [SerializeField]
    private Button _buttonNotification;

    private void Start()
    {
        _buttonNotification.onClick.AddListener(CreateNotification);
    }

    private void OnDestroy()
    {
        _buttonNotification.onClick.RemoveAllListeners();
    }

    private void CreateNotification()
    {
#if UNITY_ANDROID
        var androidSettingsChanel = new AndroidNotificationChannel
        {
            Id = AndroidNotifierId,
            Name = "Game Notifier",
            Importance = Importance.High,
            CanBypassDnd = true,
            CanShowBadge = true,
            Description = "Enter the best game ever, we miss you!",
            EnableLights = true,
            EnableVibration = true,
            LockScreenVisibility = LockScreenVisibility.Public
        };

        AndroidNotificationCenter.RegisterNotificationChannel(androidSettingsChanel);

        var androidSettingsNotification = new AndroidNotification
        {
            Color = Color.blue,
            RepeatInterval = TimeSpan.FromSeconds(10)
        };

        AndroidNotificationCenter.SendNotification(androidSettingsNotification, AndroidNotifierId);
#elif UNITY_IOS
       var iosSettingsNotification = new iOSNotification
       {
           Identifier = "android_notifier_id",
           Title = "Game Notifier",
           Subtitle = "Subtitle notifier",
           Body = "Enter the best game ever, we miss you!",
           Badge = 1,
           Data = "01/02/2021",
           ForegroundPresentationOption = PresentationOption.Alert,
           ShowInForeground = false
       };
      
       iOSNotificationCenter.ScheduleNotification(iosSettingsNotification);
#endif
    }
}
