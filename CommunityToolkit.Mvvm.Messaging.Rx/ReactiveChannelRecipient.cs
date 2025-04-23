namespace CommunityToolkit.Mvvm.Messaging.Rx;
using System;
using System.Reactive.Disposables;

internal class ReactiveRecipient<TMessage, TToken> : IRecipient<TMessage>, IDisposable
	where TMessage : class
	where TToken : IEquatable<TToken>
{
	private readonly IObserver<TMessage> observer;
	private readonly IDisposable cleanup;

	public ReactiveRecipient(IObserver<TMessage> observer, IMessenger messenger, TToken token)
	{
		this.observer = observer;

		this.cleanup = Disposable.Create(() =>
		{
			messenger.UnregisterAll(this, token);
			this.observer.OnCompleted();
		});

		messenger.RegisterAll(this, token);
	}

	public void Receive(TMessage message)
	{
		this.observer.OnNext(message);
	}

	public void Dispose()
	{
		this.cleanup.Dispose();
	}
}
