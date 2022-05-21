using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
public class ActionCharacter : MonoBehaviour
{
    [SerializeField] private Character _characterActive;

    [SerializeField] private List<Character> _targetCharacters;

    private ActionObserver _actionObserver;

    public void ClearListTarget() 
    {
        _targetCharacters = new List<Character>();
    }

    public void AddTartget(Character target) 
    {
        _targetCharacters.Add(target);
    }
    private void Start()
    {
        _actionObserver = GetComponent<ActionObserver>();
    }
}
