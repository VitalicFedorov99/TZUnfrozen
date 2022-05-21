using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
using DG.Tweening;
using Spine.Unity;
public class ActionCharacter : MonoBehaviour
{

    [SerializeField] private List<Character> _targetCharacters;
    [SerializeField] private Character _activeCharacter;
    [SerializeField] private Transform _rightPosition;
    [SerializeField] private Transform _leftPosition;
    [SerializeField] private Vector3 _rightStartPosition;
    [SerializeField] private Vector3 _leftStartPosition;

    public void ClearListTarget() 
    {
        _targetCharacters = new List<Character>();
    }

    public void AddTartget(Character target) 
    {
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
  
    IEnumerator Fight() 
    {
        Debug.Log(_activeCharacter + " ударил " + _targetCharacters[0]);
        _activeCharacter.GetComponent<AnimatorCharacters>().Attack("DoubleShift");
        _targetCharacters[0].GetComponent<AnimatorCharacters>().Damage("Damage");
        _targetCharacters[0].SetDamage(_activeCharacter.GetAttackPower());
        yield return new WaitForSeconds(1f);
        _activeCharacter.GetComponent<AnimatorCharacters>().Idle("Idle");
        _targetCharacters[0].GetComponent<AnimatorCharacters>().Idle("Idle");
        //_activeCharacter.GetComponent<AnimatorCharacters>().Idle("Idle");
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
    }
    

    

}
