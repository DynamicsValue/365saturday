# Raising events

Let's say - for argument's sake - that we have an interface that has
an event defined:

```csharp
public interface IRobot
{ 
    event EventHandler FellInLove;
}
```

Now in a test where we have a faked instance of this interface we can
raise that event whenever we want, specifying sender and event
args. We could also omit the sender and the Fake will be passed as
sender to the event handler. There's also a convenience method for
raising with empty event args.

```csharp
var robot = A.Fake<IRobot>();
            
robot.FellInLove += (s, e) =>
    {
        Console.WriteLine("Yay!");
    };
         
// Raise the event!
robot.FellInLove += Raise.With(someEventArgs); // the "sender" will be robot

// Use the overload for empty event args
robot.FellInLove += Raise.WithEmpty(); // sender will be robot, args will be EventArgs.Empty

// Specify sender and event args explicitly:
robot.FellInLove += Raise.With(sender: robot, e: someEventArgs);
```

Events of type `EventHandler<TEventArgs>` can be raised in exactly the same way. 

Note that as of version 3.1.0, for the .NET Standard version of the FakeItEasy library, `TEventArgs` need not extend `EventArgs` to support the above syntax. The .NET 4.0 library still requires `TEventArgs` to extend `EventArgs`.

If an event is defined using a **custom delegate**, then `Raise` needs
a typeparam to help it out:

```csharp
public delegate void CustomEventHandler(object sender, CustomEventArgs e);
public delegate void FreeformEventHandler(int count);
…
event CustomEventHandler CustomEvent;
event FreeformEventHandler FreeformEvent;
…
fake.CustomEvent += Raise.With<CustomEventHandler>(fake, sampleCustomEventArgs);
fake.FreeformEvent += Raise.With<FreeformHandler>(7);
```

Just as when we're trying to
[override a method's behavior](what-can-be-faked#what-members-can-be-overriden.md),
_for FakeItEasy to raise an event, the event must be virtual (if
defined on a class) or defined on an interface_.

## VB.Net

```
AddHandler robot.FellInLove, Raise.With(EventArgs.Empty)
```
