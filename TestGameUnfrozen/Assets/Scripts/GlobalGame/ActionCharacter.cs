using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
using Spine.Unity;

namespace TZUnfrozen.GlobalGame
{
    public class ActionCharacter : MonoBehaviour
    {
        [SerializeField] private List<Character> _targetCharacters;
        [SerializeField] private Character _activeCharacter;
        [SerializeField] private Transform _rightPosition;
        [SerializeField] private Transform _leftPosition;
        [SerializeField] private GameObject _backGround;
        private Vector3 _rightStartPosition;
        private Vector3 _leftStartPosition;


        public void ClearListTarget()
        {
            _targetCharacters = new List<Character>();
        }

        public void Skip()
        {
            _backGround.SetActive(true);
            _activeCharacter = ActionObserver.Instance.GetActiveCharacter();
            if (_activeCharacter.GetFlagIsEnemy() == false)
            {
                _leftStartPosition = _activeCharacter.transform.position;
                _activeCharacter.transform.position = _leftPosition.transform.position;

            }
            else
            {
                _rightStartPosition = _activeCharacter.transform.position;
                _activeCharacter.transform.position = _rightPosition.transform.position;

            }
            StartCoroutine(SkipStep());
        }

        public void AddTarget(Character target)
        {
            _backGround.SetActive(true);
            _targetCharacters.Add(target);
            _activeCharacter = ActionObserver.Instance.GetActiveCharacter();
            if (_activeCharacter.GetFlagIsEnemy() == false)
            {
                _rightStartPosition = _targetCharacters[0].transform.position;
                _leftStartPosition = _activeCharacter.transform.position;
                _activeCharacter.transform.position = _leftPosition.transform.position;
                _targetCharacters[0].transform.position = _rightPosition.transform.position;
            }
            else
            {
                _rightStartPosition = _activeCharacter.transform.position;
                _leftStartPosition = _targetCharacters[0].transform.position;
                _activeCharacter.transform.position = _rightPosition.transform.position;
                _targetCharacters[0].transform.position = _leftPosition.transform.position;
            }
            StartCoroutine(Fight());
        }


        IEnumerator SkipStep()
        {
            var track1 = _activeCharacter.GetComponent<AnimatorCharacters>().Skip();
            yield return new WaitForSpineAnimationComplete(track1);
            _backGround.SetActive(false);
            _activeCharacter.GetComponent<AnimatorCharacters>().Idle();
            if (_activeCharacter.GetFlagIsEnemy() == false)
            {
                _activeCharacter.transform.position = _leftStartPosition;
            }
            else
            {
                _activeCharacter.transform.position = _rightStartPosition;
            }
            ActionObserver.Instance.UseNextCharacter();
        }
        IEnumerator Fight()
        {
            var track1 = _activeCharacter.GetComponent<AnimatorCharacters>().Attack();
            yield return new WaitForSpineEvent(_activeCharacter.GetComponent<AnimatorCharacters>().skeletonAnimation.state, _activeCharacter.GetComponent<AnimatorCharacters>().eventData);
            _targetCharacters[0].GetComponent<AnimatorCharacters>().Damage();
            yield return new WaitForSpineEvent(_activeCharacter.GetComponent<AnimatorCharacters>().skeletonAnimation.state, _activeCharacter.GetComponent<AnimatorCharacters>().eventData);
            _targetCharacters[0].GetComponent<AnimatorCharacters>().Damage();
            yield return new WaitForSpineAnimationComplete(track1);
            _targetCharacters[0].SetDamage(_activeCharacter.GetAttackPower());
            _activeCharacter.GetComponent<AnimatorCharacters>().Idle();
            _targetCharacters[0].GetComponent<AnimatorCharacters>().Idle();
            _backGround.SetActive(false);
            if (_activeCharacter.GetFlagIsEnemy() == false)
            {
                _activeCharacter.transform.position = _leftStartPosition;
                _targetCharacters[0].transform.position = _rightStartPosition;
            }
            else
            {

                _activeCharacter.transform.position = _rightStartPosition;
                _targetCharacters[0].transform.position = _leftStartPosition;
            }
            ActionObserver.Instance.UseNextCharacter();
        }
    }
}
