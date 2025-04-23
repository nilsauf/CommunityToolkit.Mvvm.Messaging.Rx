namespace CommunityToolkit.Mvvm.Messaging.Rx;
using System;
using System.Reactive.Disposables;

internal class ReactiveRecipient<TMessage> : IRecipient<TMessage>, IDisposable
	where TMessage : class
{
	private readonly IObserver<TMessage> observer;
	private readonly IDisposable cleanup;

	public ReactiveRecipient(IObserver<TMessage> observer, IMessenger messenger)
	{
		this.observer = observer;

		this.cleanup = Disposable.Create(() =>
		{
			messenger.UnregisterAll(this);
			this.observer.OnCompleted();
		});

		messenger.RegisterAll(this);
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
