# Unity ScriptableObject Event System

A decoupled, data-driven event architecture for Unity. Zero singletons, zero hard dependencies. Connect your logic through the inspector.

### The Problem
Standard Unity setups often lead to tightly coupled dependencies. Your `Player.cs` takes damage and needs to update the health bar, so it calls `UIManager.Instance`. Now your player is hard-coupled to your UI. If you delete the UI canvas to test something, your game crashes. 

Singletons create hidden dependencies. Standard C# events make designer iteration slow.

### The Solution
ScriptableObject Event Channels. Scripts literally do not know each other exist.
* Player takes damage -> raises a `DamageEvent` (ScriptableObject).
* UI is listening to `DamageEvent` -> updates the health bar.

Zero singletons. Zero hard dependencies. Connect your game logic visually through the Inspector.

![GIF 1](https://github.com/user-attachments/assets/ccadc7a1-40f3-4671-896d-3c1bbccfb811)
> *Visually linking isolated systems in the Inspector. No bridge scripts required.*

### Quick Start
1. Create an event: `Right-click -> Create -> Platformer Core -> Events -> Game Event`. Name it `OnPlayerDamaged`.
2. Add a `GameEventListener` component to your UI Canvas. Assign the `OnPlayerDamaged` event to it.
3. Link your UI update function in the UnityEvent response.
4. In your player script, simply call `.Raise()` on the event.

<img width="511" height="455" alt="image" src="https://github.com/user-attachments/assets/fa145c3b-b177-40dc-923a-b1acec12205f" />



![GIF 2](https://github.com/user-attachments/assets/8a46828b-a182-42af-9fc1-198adb94a818)
> *Triggering the event in code is literally one line. Fast and clean.*

### Advanced: Local Filtering
Tired of global events triggering everywhere? The `GameEventListener` includes an `onlyFromThisObject` toggle. Drop a global `OnTakeDamage` event onto 10 different enemies, and the listener will only trigger the UI for the specific enemy that actually took damage. 


> *Using![GIF 3](https://github.com/user-attachments/assets/27cae1c3-f0ff-4ccb-b7ba-6acf6ed4f9ab)
 `onlyFromThisObject` to isolate events to local prefab hierarchies and prevent global noise.*

---

### Need a full game foundation?
I open-sourced this event system because it's the backbone of my own games. 

If you don't want to spend the next 3 weeks coding your own save systems, jump physics, and UI stacks from scratch, I packaged my internal engine into a **2D Platformer Starter Template**. 

It uses this exact event system and includes Verlet ropes, dynamic dashes, Ghost Health combat (Dark Souls style), and a tiered Save Manager right out of the box.

![GIF 4](https://github.com/user-attachments/assets/eb378634-758d-4abb-a8a1-b3bd5259a8ce)
> *The game feel out of the box: custom physics, dashes, and hit-stop combat. Fully decoupled.*

**[Grab the full starter template on Itch.io](https://akirihito-heavy.itch.io/platformer-core)**
