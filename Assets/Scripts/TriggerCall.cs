﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace Cluster
{

    public class TriggerCall : MonoBehaviour
    {

        public LayerMask layerMask = -1;

        [System.Serializable]
        public class TriggerEvent : UnityEvent<Collider> { }

        public TriggerEvent onTriggerEnter = new TriggerEvent();
        public TriggerEvent onTriggerExit = new TriggerEvent();
        public TriggerEvent onTriggerStay = new TriggerEvent();

        void OnTriggerEnter(Collider other)
        {
            if ((layerMask.value & 1 << other.gameObject.layer) != 0)
                onTriggerEnter.Invoke(other);
        }

        void OnTriggerExit(Collider other)
        {
            if ((layerMask.value & 1 << other.gameObject.layer) != 0)
                onTriggerExit.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            if ((layerMask.value & 1 << other.gameObject.layer) != 0)
                onTriggerExit.Invoke(other);
        }
    }

}