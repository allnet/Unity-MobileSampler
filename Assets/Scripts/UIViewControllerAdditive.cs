﻿using System.Collections.Generic;
using Talespin;

namespace AllNetXR
{
    public class UIViewControllerAdditive : UIViewControllerSequential
    {
        public List<eAppState> EnabledStates;
                
        public bool ShouldShow()
        {
            if (EnabledStates.Count == 0)
            {
                return true;
            }

            return (EnabledStates.Contains(StateMachineController.instance.activeState));
        }
    }
}