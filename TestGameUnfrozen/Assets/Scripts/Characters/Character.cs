using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TZUnfrozen.Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private float _attackPower;
        [SerializeField] private StateCharacters _stateCharacters;


        [SerializeField] private bool _isActiv = false;
        [SerializeField] private bool _isEnemy = false;
        private BackLight backLight;

        private void Awake()
        {
            backLight=GetComponent<BackLight>();
        }


        public void SetIsActiv(bool flag)
        {
            _isActiv=flag;
            _stateCharacters = StateCharacters.Stay;
            backLight.OnLight(Color.green);
        }

        public void SetFlagIsEnemy(bool flag) 
        {
            _isEnemy = flag;
        }

        public StateCharacters GetStateCharacters() 
        {
            return _stateCharacters;
        }

        public bool GetFlagIsEnemy() 
        {
            return _isEnemy;
        }

        public void SkipStep() 
        {
             SetIsActiv(false);
             backLight.OffLight();
        }

        public void Attack()
        {
            _stateCharacters = StateCharacters.Attack;
        }

        public float GetAttackPower() 
        {
            return _attackPower;
        }

        public void  SetDamage(float damage) 
        {
            _health = _health - damage;
            if (_health <= 0) 
            {
                Death();
            }
        }
        
        public void Death() 
        {
            Debug.Log("Умер");
            ActionObserver.Instance.DeleteCharacter(this);
        }
    }
}
