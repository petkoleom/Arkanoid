using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Newtonsoft.Json.Serialization;

namespace darkvoyagestudios
{
    public class scr_GameManager : StaticInstance<scr_GameManager>
    {



        [SerializeField]
        int maxLives = 3;
        int lives;

        int level = 1;


        public static event Action<GameState> OnBeforeStateChanged;
        public static event Action<GameState> OnAfterStateChanged;

        public GameState State { get; private set; }

        void Start() => ChangeState(0);

        private void Update()
        {


        }


        public void ChangeState(int newState)
        {
            OnBeforeStateChanged?.Invoke((GameState)newState);

            State = (GameState)newState;

            switch ((GameState)newState)
            {
                case GameState.Menu:
                    HandleMenu();
                    break;
                case GameState.Starting:
                    HandleStarting();
                    break;
                case GameState.Playing:
                    HandlePlaying();
                    break;
                case GameState.Ending:
                    HandleEnding();
                    break;
                case GameState.Paused:
                    HandlePause();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnAfterStateChanged?.Invoke((GameState)newState);

            Debug.Log($"New state: {(GameState)newState}");
            
        }

        public void LevelDone()
        {
            ChangeState(3);
        }


        private void HandleStarting()
        {
            
            lives = maxLives;
            scr_UIManager.Instance.OpenGame();
            scr_UIManager.Instance.UpdateUI(level, lives);
            scr_UnitManager.Instance.Spawn();
            scr_BlockManager.Instance.GenerateBlocks();
            scr_BlockManager.Instance.enabled = true;
            ChangeState(2);
        }


        private void HandlePlaying()
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            scr_UIManager.Instance.OpenGame();


        }

        private void HandleEnding()
        {
            Cursor.visible = true;
            scr_UnitManager.Instance.Despawn();
            scr_UIManager.Instance.OpenEndScreen();
        }

        private void HandleMenu()
        {
            Cursor.visible = true;
            scr_BlockManager.Instance.enabled = false;
            scr_UIManager.Instance.OpenMenu();
        }

        private void HandlePause()
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            scr_UIManager.Instance.OpenPause();
        }

        public void LoadNextLevel()
        {
            level++;
            scr_UIManager.Instance.UpdateUI(level, lives);
        }

        public void LostLife()
        {
            lives--;
            scr_UIManager.Instance.UpdateUI(level, lives);
            scr_UnitManager.Instance.ResetPositions();
            if( lives == 0 )
            {
                ChangeState(3);
            }
        }

    }


    [Serializable]
    public enum GameState
    {
        Menu = 0,
        Starting = 1,
        Playing = 2,
        Ending = 3,
        Paused = 4
    }

}
