using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TZUnfrozen.GlobalGame
{
    public class ExitAndRestart : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private bool _isOpen = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isOpen == false)
                {
                    _menu.SetActive(true);
                    _isOpen = true;
                    return;
                }
                else
                {
                    _menu.SetActive(false);
                    _isOpen = false;
                    return;
                }
            }
        }


        public void Restart()
        {
            SceneManager.LoadScene("Game");
        }
        public void Exit()
        {
            Application.Quit();
        }
    }
}