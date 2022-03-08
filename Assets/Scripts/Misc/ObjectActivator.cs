using System;
using JobTest.Events;
using UnityEngine;

namespace JobTest.Misc
{
    public class ObjectActivator : MonoBehaviour, IAppear
    {
        [SerializeField] private GameObject _object;
        public void Appear()
        {
            _object.SetActive(true);
        }
    }
}