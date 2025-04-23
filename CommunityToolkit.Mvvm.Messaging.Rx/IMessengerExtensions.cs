namespace CommunityToolkit.Mvvm.Messaging.Rx;

using System.Reactive.Linq;

public static class IMessengerExtensions
{
	public static IObservable<TMessage> Connect<TMessage>(this IMessenger messenger)
		where TMessage : class
	{
		return Observable.Create<TMessage>(
			observer => new ReactiveRecipient<TMessage>(observer, messenger));
	}

	public static IObservable<TMessage> Connect<TMessage, TToken>(this IMessenger messenger, TToken token)
		where TMessage : class
		where TToken : IEquatable<TToken>
	{
		return Observable.Create<TMessage>(
			observer => new ReactiveRecipient<TMessage, TToken>(observer, messenger, token));
	}
}
