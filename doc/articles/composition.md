# Composition

Composition Visuals make up the visual tree structure which all other features of the composition API use and build on.
The API allows developers to define and create one or many visual objects each representing a single node in a visual tree.

To get more info, you can refer to [Microsoft's documentation](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-visual-tree).

Uno does support few APIs of the [`Windows.UI.Composition` namespace](https://docs.microsoft.com/en-us/uwp/api/windows.ui.composition?view=winrt).

** On Android, composition APIs are functionnal only for Android 10 and upper (API 29).**

## Compositor Thread [Android]

On Android, the composition refers to the [`Draw`](https://developer.android.com/reference/android/view/View#draw(android.graphics.Canvas)) and [`OnDraw`](https://developer.android.com/reference/android/view/View#onDraw(android.graphics.Canvas)) methods.
To get more info about custom drawing on Android, you can refer to the [Android's documentation](https://developer.android.com/training/custom-views/custom-drawing).

By default, those methods are invoked on the UI Thread.

With Uno, you can request to run those methods on a dedicated thread by setting in your Android application's constructor:

```csharp
Uno.CompositionConfiguration.Configuration = Uno.CompositionConfiguration.Options.Enabled;
```

This thread will also be used for [independent animations](https://docs.microsoft.com/en-us/windows/uwp/design/motion/storyboarded-animations#dependent-and-independent-animations).

**When overriding the `[On]Draw` methods, it's really important to not access any state that can be edited from the UI Thread, including any `DependencyProperty`.**
**Instead, you should capture the state of your control into a `RenderNode` during the `ArrangeOverride` and render it on the provided `Canvas`.**

_There is few known issues associated with the used of the compositor thread, [make sure to read them](#known_issues)._

## Knwon issues

* When using the compositor thread, the native ripple effect of Android (used in native buttons) will not work anymore.