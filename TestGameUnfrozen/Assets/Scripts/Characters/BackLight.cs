using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZUnfrozen.Characters
{
    public class BackLight : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _system;
        [SerializeField] private bool _isActiv;

        public void OnLight(Color color)
        {
            _system.startColor = color;
            _system.Play();

        }

        public void OffLight()
        {
            _system.Stop();
        }
    }

}