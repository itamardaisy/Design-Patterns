# Design Patterns
This project is a c# based to present the main design patterns in the object oriented world.

## Proxy 

Proxy pattern is the way of encapsulate an implemantation of some services.
In the next example i'll create a basic ATM machine with Console application.

#### First step 
Implement the interfaces of the service, in that case i'll implement 3 services.
- ATMMachine - This is the actual ATM Machine logic.
- UserAccount - This is the manager of a singel user account.
- UIManager - This is the service that handle the all UI Commands.

This implementation you can see inside the code under the file Proxy/Interfaces.

#### Second step

In this step we going to implement the Proxy class.
This class is the main of this project, this class is implements the DynamicObject, this class Provides a base class for specifying dynamic behavior at run time.

###### class signature
```c#
public class Proxy<T> : DynamicObject where T : class, new()
```
This class have to methods

###### As<I>
```c#
public static I As<I>() where I : class
{
    if (!typeof(I).IsInterface)
    {
         throw new ArgumentException("I must be an interface type!");
    }
    else
    {
         return new Proxy<T>(new T()).ActLike<I>();
    }
}
```
The method above is checks wether the given class is the type of the Interface if it does so is returns the Proxy that act like the class implementation.
   
###### TryInvokeMember
```c#
public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
{
     try
     {
         Console.WriteLine($"Invoking {subject.GetType().Name}.{binder.Name} with arguments: [{string.Join(",", args)}]");
         if (MethodCallCount.ContainsKey(binder.Name))
         {
               MethodCallCount[binder.Name]++;
         }
         else
         {
               MethodCallCount.Add(binder.Name, 1);
         }
         result = subject.GetType().GetMethod(binder.Name).Invoke(subject, args);
         return true;
     }
     catch
     {
         result = null;
         return false;
     }
}
```
## Factory 
Factory pattern is mainly about creating a factory method that return an object(mostly common is some service) depens on the method input. in that way it siplify the way of getting an object without having to specify the exact class of the object that will be created.

Here is a factory method that gets a time zone and return a clock object on the same place:
```c#
public IClock GetClock(string timeZone)
{
    switch (timeZone)
    {
        case TimeZones.ISRAEL:
            return _clocks.Find(c => c.TimeZone == "Israel Standard Time");
        case TimeZones.NEW_YORK:
            return _clocks.Find(c => c.TimeZone == "New-york Standard Time");
        case TimeZones.TOKYO:
            return _clocks.Find(c => c.TimeZone == "Tokyo Standard Time");
        default:
            return null;
    }
}
```
