using UnityEngine;

namespace Shafir.EventBus.Test
{
    internal class EventReceiver1 : MonoBehaviour
    {
        private ShafirEventBus _eventBus;

        public void Initialize(ShafirEventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<Message1>(OnReceived);
        }
        
        private void OnReceived(Message1 message)
        {
            Debug.LogError("Received 1", gameObject);
        }
    }
}