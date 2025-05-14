using UnityEngine;

namespace Shafir.EventBus.Test
{
    internal class EventReceiver2 : MonoBehaviour
    {
        private ShafirEventBus _eventBus;

        public void Initialize(ShafirEventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<Message2>(OnReceived);
        }

        private void OnReceived(Message2 message)
        {
            Debug.LogError("Received Message2", gameObject);
            _eventBus.UnSubscribe<Message2>(OnReceived);
            _eventBus.Subscribe<Message2>(OnReceived);
        }
    }
}