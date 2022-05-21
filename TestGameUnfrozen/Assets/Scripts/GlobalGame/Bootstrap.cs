using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
using Spine.Unity;
namespace TZUnfrozen.GlobalGame
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Transform[] _startPosition;

        [SerializeField] private List<Character> _playerCharacters;

        [SerializeField] private List<Character> _enemyCharacters;

        [SerializeField] private QueueStepCharacters _queue;

        [SerializeField] private ActionObserver _actionObserver;


        private void Start()
        {
            _playerCharacters = GetComponent<FactoryCharacters>().CreateCharacters(_playerCharacters, 4, true);
            _enemyCharacters = GetComponent<FactoryCharacters>().CreateCharacters(_enemyCharacters, 4, false);
            PutInPositionCharacters();
            _queue.SetupActionObserver(_actionObserver);
            _queue.SetupListCharacterPlayer(_playerCharacters);
            _queue.SetupListCharacterEnemy(_enemyCharacters);
            _queue.CreateListActionCharacters();
            _queue.RandomChoiceCharacter();
        }




        private void PutInPositionCharacters()
        {
            int pCharacters = 0;
            int eCharacters = 0;
            for (int i = 0; i < _startPosition.Length; i++)
            {
                if (i < _startPosition.Length / 2)
                {
                    if (pCharacters < _playerCharacters.Count)
                    {
                        _playerCharacters[pCharacters].transform.position = _startPosition[i].transform.position;
                        _playerCharacters[pCharacters].SetFlagIsEnemy(false);
                        pCharacters++;
                        
                    }
                }
                else
                {
                    if (eCharacters < _enemyCharacters.Count)
                    {
                        _enemyCharacters[eCharacters].transform.position = _startPosition[i].transform.position;
                        _enemyCharacters[eCharacters].transform.Rotate(0, 180, 0);
                        _enemyCharacters[eCharacters].SetFlagIsEnemy(true);
                        eCharacters++;
                    }
                }
            }
        }

    }
}