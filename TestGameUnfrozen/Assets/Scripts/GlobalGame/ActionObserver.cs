using UnityEngine;
using TZUnfrozen.Characters;

namespace TZUnfrozen.GlobalGame
{
    public class ActionObserver : MonoBehaviour
    {

        public static ActionObserver Instance { get; private set; }

        [SerializeField] private QueueStepCharacters _queue;

        [SerializeField] private Character _activeCharacter;

        [SerializeField] private UIManager _uIManager;

        [SerializeField] private ActionCharacter _actionCharacter;

        public void SetActivCharacter(Character character)
        {
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
            _actionCharacter.AddTarget(character);
            _activeCharacter.Skip();
        }

        public void DeleteCharacter(Character character)
        {
            _queue.RemoveCharacter(character, character.GetFlagIsEnemy());
        }


        public void ActionSkipStep()
        {
            _actionCharacter.Skip();
        }
        public void UseNextCharacter()
        {
            _queue.RandomChoiceCharacter();
        }

        private void Awake()
        {
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
}