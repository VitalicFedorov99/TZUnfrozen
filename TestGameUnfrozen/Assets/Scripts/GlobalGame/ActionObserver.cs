using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
using TZUnfrozen.GlobalGame;

public class ActionObserver : MonoBehaviour
{

    public static ActionObserver Instance { get; private set; }

    [SerializeField] private QueueStepCharacters _queue;

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
        _activeCharacter.SkipStep();
        //_activeCharacter = null;
        StartCoroutine(NextCharacter());
    }

    public void DeleteCharacter(Character character) 
    {
        _queue.RemoveCharacter(character, character.GetFlagIsEnemy());
    }

    IEnumerator NextCharacter()
    {
        yield return new WaitForSeconds(3f);
        _queue.RandomChoiceCharacter();
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
