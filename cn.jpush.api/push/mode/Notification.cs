using cn.jpush.api.push.notificaiton;
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
namespace cn.jpush.api.push.mode
{
    public class Notification : IPushMode
	{
        private  String alertNotificaiton;
        private  HashSet<PlatformNotification> notifications;
        
        private Notification(String alert, HashSet<PlatformNotification> notifications)
        {
            this.alertNotificaiton = alert;
            this.notifications = notifications;
        }
        public static Notification alert(string alert)
        {
            return new Notification(alert, null);
        }
        public static Notification android(String alert, String title, Dictionary<String, String> extras)
        {
            var platformNotification = AndroidPlatformNotification.alert(alert).setTitle(title).setExras(extras);
            return Notification.alert(alert).addPlatform(platformNotification);
        }
        public static Notification ios(String alert, Dictionary<String, String> extras)
        {
            var platformNotification = iosPlatformNotification.alert(alert).setExtras(extras);
            return Notification.alert(alert).addPlatform(platformNotification);
        }
        public static Notification ios_auto_badge()
        {
           var platformNotification = iosPlatformNotification.alert("").autoBadge();
           return Notification.alert(null).addPlatform(platformNotification);
        }
        public static Notification ios_set_badge(int badge)
        {
            var platformNotification = iosPlatformNotification.alert("").setBadge(badge);
            return Notification.alert(null).addPlatform(platformNotification);
        }
        public static Notification ios_incr_badge(int badge)
        {
            var platformNotification = iosPlatformNotification.alert("").incrBadge(badge);
            return Notification.alert(null).addPlatform(platformNotification);
        }
        public static Notification winphone(String alert,Dictionary<string,string> extras)
        {
            var plarformNotification = WinphonePlatformNotification.alert("").setExras(extras);
            return Notification.alert(null).addPlatform(plarformNotification);
        }
        public   Notification  addPlatform(PlatformNotification platformNotification)
        {
            notifications.Add(platformNotification);
            return this;
        }
        public object toJsonObject()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (alertNotificaiton != null)
            {
                dict.Add(PlatformNotification.ALERT, alertNotificaiton);
            }
            if (this.notifications != null)
            {
                foreach (var item in this.notifications)
                {
                    dict.Add(item.getPlatformName(), item.toJsonObject());
                }
            }
            return dict;
        }
	}
}
