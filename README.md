# Fluxamarin = flux + Xamarin

This library helps to apply a flux-like architecture on Xamarin apps


# Why flux instead of MVVM?

After years of experience developing Xamarin apps in different ways, (forms only, using MVVMCross, private MVVM core libraries...) I notice that is very easy to create bug and bad practices in a big project developed by a team.
Mobile apps should be easy to change and easy to scale over the time, for this reason, I think a flux architecture could be a good solution.

## Separate logic from views

A classic, there is a release date near and you have to finish this app feature. 
This kind of problem provoke that viewmodels ends like a mess with business logic and extra dependencies making that viewmodel not only ugly also impossible to reuse on other views.
**With Fluxamarin, unit testing is simle and easy.**
All your logic is on Actions, so views are completly logic-free so you can test and mock without pain.
## Reuse code

The idea of this library is to **create small components easy to reuse them** on any page thanks to the **0 dependencies between components.**

## Actions

Actions are simple classes that inherits from ActionBase.
The only responsability of action is to execute his own logic.
What actions can do:

 1. **Update App State** 
 2. Execute API calls 
 3. Execute business logic

## Dispatcher

Dispatcher responsability is just to execute actions and disacouple views from actions. 
The only thing dispatcher needs to execute an action is the action type and data required.

## Store

Store contains the AppState and is the one who manage it.

## Stateful widget (Views)
Widgets are components that contains a group of views of the UI that can work without any other dependencies.
This components only contains view logic and events.
The special thing of this widgets is that are subscribed to App State changed events, this way they can update themselves without other interactions.
