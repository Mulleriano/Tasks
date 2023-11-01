using CommunityToolkit.Mvvm.Messaging.Messages;

namespace PushNotification.Model
{
    public class PushNotificationReceived : ValueChangedMessage<string>
    {
        public PushNotificationReceived(string message) : base(message) { }
    }
}