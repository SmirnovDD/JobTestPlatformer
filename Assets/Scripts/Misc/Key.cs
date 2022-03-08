using UniRx;
using UnityEngine;

namespace JobTest.Misc
{
    public class Key : MonoBehaviour
    {
        public ReactiveProperty<bool> Collected = new();
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Player.Player>();
            if (player)
            {
                Collected.Value = true;
                Destroy(gameObject);
            }
        }
    }
}