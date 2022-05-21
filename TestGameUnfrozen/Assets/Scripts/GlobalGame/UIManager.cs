using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TZUnfrozen.Characters;
using TZUnfrozen.GlobalGame;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _skipButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private QueueStepCharacters _queue;

    public void AddActionSkipButton(Character character) 
    {
        _skipButton.onClick.RemoveAllListeners();
        _skipButton.onClick.AddListener(character.SkipStep);
        _skipButton.onClick.AddListener(_queue.RandomChoiceCharacter);
    }

    public void AddActionAttackButton(Character character) 
    {
        _attackButton.onClick.RemoveAllListeners();
        _attackButton.onClick.AddListener(character.Attack);
    }
}
