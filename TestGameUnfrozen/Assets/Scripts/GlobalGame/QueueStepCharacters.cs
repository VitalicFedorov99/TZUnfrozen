using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
namespace TZUnfrozen.GlobalGame
{
    public class QueueStepCharacters : MonoBehaviour
    {
        [SerializeField] private List<Character> _liveCharactersPlayer;
        [SerializeField] private List<Character> _liveCharactersEnemy;
        [SerializeField] private List<Character> _actionCharacters;
        
        private ActionObserver _actionObserver;
       

        public void SetupListCharacterPlayer(List<Character> character) 
        {
            _liveCharactersPlayer = character;
        }
        public void SetupListCharacterEnemy(List<Character> character)
        {
            _liveCharactersEnemy = character;
        }

        public void SetupActionObserver(ActionObserver actionObserver)
        {
            _actionObserver = actionObserver;
        }

        public void CreateListActionCharacters()
        {
            _actionCharacters = new List<Character>();
            for (int i = 0; i < _liveCharactersPlayer.Count; i++)
            {
                _actionCharacters.Add(_liveCharactersPlayer[i]);
            }
            for (int i = 0; i < _liveCharactersEnemy.Count; i++)
            {
                _actionCharacters.Add(_liveCharactersEnemy[i]);
            }
        }

        public void RandomChoiceCharacter()
        {   
            if (_actionCharacters.Count > 0)
            {
                int rand = Random.Range(0, _actionCharacters.Count);
                Character character = _actionCharacters[rand];
                _actionCharacters[rand].SetIsActiv(true);
                _actionCharacters.RemoveAt(rand);
                _actionObserver.SetActivCharacter(character);
            }
            else if(_actionCharacters.Count == 0) 
            {
                CreateListActionCharacters();
            }
        }

        public void RemoveCharacter(Character character, bool flag) 
        {
            if (flag == false) 
            {
                _liveCharactersPlayer.Remove(character);
                _actionCharacters.Remove(character);
                
            }
            else 
            {
                _liveCharactersEnemy.Remove(character);
                _actionCharacters.Remove(character);
            }
            Destroy(character.gameObject,1f);
        }

    }
}

