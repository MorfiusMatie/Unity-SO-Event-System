# Unity-SO-Event-System
A decoupled scriptableobject event system for unity. zero singletons, zero hard dependencies. connect your logic through the inspector.

# Unity ScriptableObject Event System

A decoupled, data-driven event architecture for Unity.

### The Problem
Standard Unity setups often lead to tightly coupled dependencies. Your `Player.cs` takes damage and needs to update the health bar, so it calls `UIManager.Instance`. Now your player is hard-coupled to your UI. If you delete the UI canvas to test something, your game crashes. 

Singletons create hidden dependencies. Standard C# events make designer iteration slow.

### The Solution
ScriptableObject Event Channels. Scripts literally do not know each other exist.
* Player takes damage -> raises a `DamageEvent` (ScriptableObject).
* UI is listening to `DamageEvent` -> updates the health bar.

Zero singletons. Zero hard dependencies. Connect your game logic visually through the Inspector.

### Quick Start
1. Create an event: `Right-click -> Create -> Platformer Core -> Events -> Game Event`. Name it `OnPlayerDamaged`.
2. Add a `GameEventListener` component to your UI Canvas. Assign the `OnPlayerDamaged` event to it.
3. Link your UI update function in the UnityEvent response.
4. In your player script, simply call `.Raise()` on the event.

### Advanced: Local Filtering
Tired of global events triggering everywhere? The `GameEventListener` includes an `onlyFromThisObject` toggle. Drop a global `OnTakeDamage` event onto 10 different enemies, and the listener will only trigger the UI for the specific enemy that actually took damage. 

---

### Need a full game foundation?
I open-sourced this event system because it's the backbone of my own games. 

If you don't want to spend the next 3 weeks coding your own save systems, jump physics, and UI stacks from scratch, I packaged my internal engine into a **2D Platformer Starter Template**. 

It uses this exact event system and includes Verlet ropes, dynamic dashes, Ghost Health combat (Dark Souls style), and a tiered Save Manager right out of the box.

[Grab the full starter template on Itch.io]

Link: https://akirihito-heavy.itch.io/platformer-core
