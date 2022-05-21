using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZUnfrozen.Characters;
using Spine.Unity;

namespace TZUnfrozen.GlobalGame
{
    public class FactoryCharacters : MonoBehaviour
    {
        [SerializeField] private Character _character;

        public List<Character> CreateCharacters(List<Character> characters, int count, bool flagElite)
        {
            CheckElite(flagElite);
            characters = new List<Character>();
            for (int i = 0; i < count; i++)
            {
                Character character = Instantiate(_character);
                character.name += i;
                characters.Add(character);
            }
            return characters;
        }


        public void CheckElite(bool flagElite)
        {
            if (flagElite == true)
            {
                _character.GetComponent<SkeletonAnimation>().initialSkinName = "elite";
            }
            else
            {
                _character.GetComponent<SkeletonAnimation>().initialSkinName = "base";
            }
        }

    }
}
