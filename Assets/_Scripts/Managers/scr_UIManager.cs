using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_UIManager : StaticInstance<scr_UIManager>
    {

        //UI
        [SerializeField]
        GameObject menu;
        [SerializeField]
        GameObject game;
        [SerializeField]
        GameObject endScreen;
        [SerializeField]
        GameObject pause;

        [SerializeField]
        TMPro.TMP_Text level;
        [SerializeField]
        TMPro.TMP_Text lives;



        public void ResetUI()
        {
            menu.SetActive(false);
            game.SetActive(false);
            endScreen.SetActive(false);
            pause.SetActive(false);
        }

        public void UpdateUI(int level, int lives)
        {
            this.level.text = "Level: " + level.ToString();
            this.lives.text = "Lives: " + lives.ToString();
        }

        public void OpenMenu()
        {
            ResetUI();
            menu.SetActive(true);
        }

        public void OpenEndScreen()
        {
            ResetUI();
            endScreen.SetActive(true);
        }

        public void OpenGame()
        {  
            ResetUI();
            game.SetActive(true);
        }

        public void OpenPause()
        {
            ResetUI();
            pause.SetActive(true);
        }
    }


}


