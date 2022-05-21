using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
public class ActionObserver : MonoBehaviour
{

    public static ActionObserver Instance { get; private set; }
    

    [SerializeField] private Character _activeCharacter;

    [SerializeField] private UIManager _uIManager;

    [SerializeField] private ActionCharacter _actionCharacter;

    public void SetActivCharacter(Character character) 
    {
        Debug.Log("Name");
        _activeCharacter = character;
        _uIManager.AddActionSkipButton(character);
        _uIManager.AddActionAttackButton(character);
    }

    public Character GetActiveCharacter() 
    {
        return _activeCharacter;
    }

    public void AddTarget(Character character) 
    {
        _actionCharacter.ClearListTarget();
        _actionCharacter.AddTartget(character);
        
    }



    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }



    
}
