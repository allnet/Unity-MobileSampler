﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Talespin;

namespace AllNetXR
{
    public class UISystemManager : MonoBehaviour
    {
        public Animator UIStateMachine;  // try to have only 1
        public LoopSequencer Sequential;  // was uiManagerSequential
        public UIManagerAdditive Additive;
      //  public TempScoreboardController Scoreboard;
    }
}
