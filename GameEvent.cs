using System.Collections.Generic;
using UnityEngine;

namespace PlatformerCore
{
    /// <summary>
    /// The core of the decoupled Event System.
    /// Acts as a signal channel that objects can raise (broadcast) or listen to.
    /// </summary>
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "Platformer Core/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        [Header("Debug")]
        [Tooltip("If TRUE, prints a console message every time this event is raised, showing the sender.")]
        [SerializeField] private bool enableDebugLog;

        private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

        /// <summary>
        /// Broadcasts the event to all global listeners.
        /// </summary>
        public void Raise() => Raise(null);

        /// <summary>
        /// Broadcasts the event, passing the sender component.
        /// Allows listeners to filter events based on the sender (e.g., only listen to THIS player).
        /// </summary>
        /// <param name="sender">The component initiating the event.</param>
        public void Raise(Component sender)
        {
            // B2B DEBUGGER
            if (enableDebugLog)
            {
                string senderName = sender != null ? sender.gameObject.name : "Global (Null / No Sender)";
                Debug.Log($"[GameEvent Tracker] Event '<color=cyan>{name}</color>' raised. Source: <color=yellow>{senderName}</color>");
            }

            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(this, sender);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!_listeners.Contains(listener)) _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (_listeners.Contains(listener)) _listeners.Remove(listener);
        }
    }
}