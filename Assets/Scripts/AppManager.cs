﻿using Talespin;
using UnityEngine;
using System.Collections.Generic;

namespace Evgo
{
    public enum eGameState //DH
    {
        //None = -1,
        State0 = 0,  //splash
        State1 = 1,
        State2 = 2,
        State3 = 3,
        Count
    }
      
    public class AppManager : MainApplication
    {
        public static new AppManager Instance;
        //public static eGameState GameState;
        public GameMetadata Metadata;

        //-------------------- MANAGERS
        //[Header("MANAGERS")]
        //public ScoreManager ScoreManager;
        //public BaseManager BaseManager;
        //public AudioManager AudioManager;
        //public DifficultyManager DifficultyManager;
        //public BaseballTrajectoryCalculator TrajectoryCalculator;
        //public UISystemManager UISystemManager;

        ////-------------------- OBJECTS
        //[Header("OBJECTS")]
        //public Bat Bat;
        //public Pitcher Pitcher;
        //public Transform Strikezone;
        //public ReplayCameraSystem ReplayCamera;

        [Header("Customize default states")]
        public eGameState StartGameState;
        public eGameState LoopStartGameState;
        public eGameState LoopEndGameState;
        public eGameState CurrentGameState;

        //-------------------- MODES               
       /*
        [System.Serializable]
        public struct GameModeToUIStateBinding
        {
            public ApplicationMode GameMode;  // Game play controllers
            public UIViewControllerSequential ViewController; //UI
            public GameObject ScoreboardPanel;

            public GameModeToUIStateBinding(ApplicationMode gameMode = null,
                UIViewControllerSequential viewController = null,
                GameObject scoreboardPanel = null)
            {
                GameMode = gameMode;
                ViewController = viewController;
                ScoreboardPanel = scoreboardPanel;
            }
        }
        [Header("Game Mode to UI Bindings")]
        public GameModeToUIStateBinding[] Bindings;

        //------------------------------------------------------------------------------------- APPLICATION
        protected override void Awake()
        {
            Instance = this;

            List<GameMetadata.PlayerScore> scores = new List<GameMetadata.PlayerScore>();
            Metadata = new GameMetadata(currentGameState: (eGameState)0,
                        location: "", username: "", totalPoints: 0,
                        currentRound: 0, numberOfRounds: 2,
                        elapsedTime: 0f, timeRemaining: 0f,
                        playerScores: new List<GameMetadata.PlayerScore>());

            base.Awake();
        }

        protected override void PostStart()
        {
            base.PostStart();
            Fade(Color.black, Color.clear, 2.0f);
   
            ChangeToGameState((eGameState)0);  // start app/game/experience
        }

        // Darryl TODO:  review this with everyone should probably be on MainApplication possibly 
        public void ChangeToGameState(eGameState gameState)  // this is simply a monobehavior
        {
            // Guard statements
            if (gameState == CurrentGameState)
            {
                return;
            }

            // continue            
            ApplicationMode newMode = Bindings[(int)gameState].GameMode;
            if (newMode != null)
            {
                ChangeMode(newMode);  // previous calls used this
            }

            if (UISystemManager.Sequential != null && UISystemManager.Sequential is IUIAnimatableSingle)
            {
                UISystemManager.Sequential.ChangeStateTo(gameState);
            }

            if (UISystemManager.Scoreboard != null)
            {
                UISystemManager.Scoreboard.ChangeStateTo(gameState);
            }

            CurrentGameState = gameState;
            UISystemManager.UIStateMachine.SetInteger("GameState", (int)CurrentGameState);
          }

        */

        // On next request
        public void ChangeStateTo(eGameState toState)  // adheres to interface or could subclass
        {
            // send exit to present state controller and wait for callback
           // isBusy = true;
        }

        public void ExitCompleteCallback()  // is ready for 
        {            
            // turn off state controller

            // Turn on next state contoller after small delay

            //Set trigger for  next state controller
            // actually change the state by turning on the next controller
        }

        public void EnterCompleteCallback( )
        {


        }

    }
}