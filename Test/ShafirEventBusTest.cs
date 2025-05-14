using UnityEngine;
using UnityEngine.UI;

namespace Shafir.EventBus.Test
{
    internal class ShafirEventBusTest : MonoBehaviour
    {
        [SerializeField] private EventReceiver1 receiver1;
        [SerializeField] private EventReceiver2 receiver2;

        [SerializeField] private Button send1;
        [SerializeField] private Button send2;

        private ShafirEventBus _eventBus;

        private void Start()
        {
            _eventBus = new ShafirEventBus();

            receiver1.Initialize(_eventBus);
            receiver2.Initialize(_eventBus);

            send1.onClick.AddListener(Send1);
            send2.onClick.AddListener(Send2);
        }

        private void Send1() => _eventBus.Publish(new Message1());
        private void Send2() => _eventBus.Publish(new Message2());
    }
}