using UnityEngine;
using TZUnfrozen.Characters;
namespace TZUnfrozen.GlobalGame
{
    public class ChoiceCharacter : MonoBehaviour
    {

        private BackLight _backLight;
        private Character _character;

        private void Start()
        {
            _backLight = GetComponent<BackLight>();
            _character = GetComponent<Character>();
        }
        private void OnMouseDown()
        {
            if (ActionObserver.Instance.GetActiveCharacter() != null)
            {
                if (ActionObserver.Instance.GetActiveCharacter() != _character &&
                    ActionObserver.Instance.GetActiveCharacter().GetStateCharacters() == StateCharacters.Attack)
                {
                    if (ActionObserver.Instance.GetActiveCharacter().GetFlagIsEnemy() != _character.GetFlagIsEnemy())
                    {
                        ActionObserver.Instance.AddTarget(_character);
                        _backLight.OffLight();
                    }
                }
            }
        }
        private void OnMouseEnter()
        {
            if (ActionObserver.Instance.GetActiveCharacter() != null)
            {
                if (ActionObserver.Instance.GetActiveCharacter() != _character &&
                ActionObserver.Instance.GetActiveCharacter().GetStateCharacters() == StateCharacters.Attack)
                {
                    if (ActionObserver.Instance.GetActiveCharacter().GetFlagIsEnemy() != _character.GetFlagIsEnemy())
                    {
                        _backLight.OnLight(Color.red);
                    }
                    else
                    {
                        _backLight.OnLight(Color.yellow);
                    }
                }
            }
        }
        private void OnMouseExit()
        {
            if (ActionObserver.Instance.GetActiveCharacter() != null)
            {
                if (ActionObserver.Instance.GetActiveCharacter() != _character)
                    _backLight.OffLight();
            }
        }
    }
}
