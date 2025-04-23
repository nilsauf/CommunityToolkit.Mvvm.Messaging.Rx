# CommunityToolkit.Mvvm.Messaging.Rx

This library provides extension methods for the CommunityToolkit.Mvvm IMessenger interface, allowing you to use the Rx (Reactive Extensions) library to send and receive messages in a more reactive way.
It allows you to create observables from messages and subscribe to them using LINQ-style queries.

## Usage
There are two main extension methods provided by this library:
- ```IObservable<TMessage> Connect<TMessage>(this IMessenger messenger)```: 
  This method creates an observable from the messenger, allowing you to subscribe to messages of a specific type.
- ```IObservable<TMessage, TToken> Connect<TMessage, TToken>(this IMessenger messenger, TToken token)```: 
  This method creates an observable from the messenger, allowing you to subscribe to messages of a specific type in a specific channel provided by the token.