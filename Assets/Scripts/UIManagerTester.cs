﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DoozyUI;
using UnityEngine.Events;

namespace AllNetXR
{
    public class UIManagerTester : MonoBehaviour
    {
        private bool IsShowing;

        //private void OnEnable()
        //{
        //    OVRTouchpad.TouchHandler += LocalTouchEventCallback;
        //}

        //private void OnDisable()
        //{
        //    OVRTouchpad.TouchHandler -= LocalTouchEventCallback;
        //}

        private void Start()
        {

            #region PullFromHiearchy
            //if (PullFromHieararchy)
            //{
            //    for (int i = 0; i < gameObject.transform.childCount; i++)
            //    {
            //        GameObject go = gameObject.transform.GetChild(i).gameObject; Debug.Log(go.name);
            //        if (go.activeInHierarchy == true)
            //        {
            //            Manager.RegisterChildrenCheerleaders(go);
            //        }
            //    }
            //}
            // UIManager.ChangeStateTo(eUIState.EnterLocation);
            #endregion

            //GameMgr = TempGameManager.Instance;
        }

        public void Update()
        {
            ProcessAdditiveUIStateRequests();
            //ProcessSequentialUIStateRequests();

        }


        private void ProcessAdditiveUIStateRequests()
        {       
         
            UIManagerAdditive uim = UIManagerAdditive.Instance;

            if (Input.GetKeyDown(KeyCode.Keypad0))  //BUSy  needs rotating sprite
            {
                //AppStateController.Instance.animator.Play("Alert3", 1, 0f);

                //UIManagerAdditive.responseHandler -= UIManagerAdditive.Instance.DefaultResponseHandler; // unload the default
                //UIManagerAdditive.responseHandler += ResponseHandler;
                //UIManagerAdditive.Instance.ShowNotification(eNotificationType.Busy, eNotificationType.Busy.ToString(), "A busy test message");  // needs a callback for each button

                //DoozyUI.UIManager.ShowNotification("Busy", -1, false, "Busy", "A test message with informative info");  // works simple
                DoozyUI.UIManager.ShowNotification("Busy", -1, false, "Busy", "Click inside Inspector to EXIT ", uim.NotificationCallbackCancel);  //simple cancel callback
            }

         
            if (Input.GetKeyDown(KeyCode.Keypad1))  // single button - info
            {             
                DoozyUI.UIManager.ShowNotification("SingleButton", -1, false, "Single Button Info", "A test message with informative info", 
                    null,
                    new string[] { "OKHit" },
                    new string[] { "OK" },
                   new UnityAction[] { uim.NotificationCallbackOk } );
            }

            //if (Input.GetKeyDown(KeyCode.Keypad4))  // single button - info  // not escaping but think I can do it with a big button or pursue further
            //{
            //    DoozyUI.UIManager.ShowNotification("SingleButtonEsc", -1, false, "Single Button ESCAPABLE Info", "A test message with informative info",
            //        null,
            //        new string[] { "OKHit" },
            //        new string[] { "OK" },
            //        new UnityAction[] { uim.NotificationCallbackOk });  //   new UnityAction[] { uim.NotificationCallbackOk }
            //}


            if (Input.GetKeyDown(KeyCode.Keypad2))
            {            
                              UnityAction[] callbacks = { uim.NotificationCallbackOk, uim.NotificationCallbackCancel };
                DoozyUI.UIManager.ShowNotification("Choice2Way", -1, false,
                    "Choice 2-Way(bi)",
                    "A test message with informative info",
                    uim.notificationSprite,
                    new string[] { "OKHit", "CancelHit" },  // broadcast game event name
                    new string[] { "OK", "Cancel" },  // titles that appear
                    callbacks);
            }

            if (Input.GetKeyDown(KeyCode.Keypad3))
            {            
                UnityAction[] callbacks = { uim.NotificationCallbackOk, uim.NotificationCallbackCancel, uim.NotificationCallbackRetry };
                DoozyUI.UIManager.ShowNotification("Choice3Way", -1, false,
                    "Choice 3-Way", 
                    "A test message with informative info", 
                    uim.notificationSprite,
                    new string[] { "OKHit", "CancelHit", "RetryHit" },  // is associated with broadcast game event that gets published
                    new string[] { "OK", "Cancel", "Retry" }, // title
                    callbacks);
            }

            //ToggleViewVisibility(state);
        }

        void ResponseHandler(eNotificationType type, eResponseType responseType, string input)
        {
            Debug.Log("HandleResponse + " + type.ToString() + " " + responseType.ToString() + "-" + input);

        }

        #region samples
        //private void ToggleViewVisibility(eUIStateAdditive state)
        //{
        //    if (state == eUIStateAdditive.None)
        //    {
        //        return;
        //    }

        //    IsShowing = UIManagerAdditive.IsAdditiveUIShowing[(int)state];
        //    if (IsShowing)
        //    {
        //        UIManagerAdditive.HideViewForState(state);
        //    }
        //    else
        //    {
        //        UIManagerAdditive.ShowViewForState(state);
        //    }
        //}

        //// Touch callbacks 
        //void LocalTouchEventCallback(object sender, EventArgs args)
        //{
        //    var touchArgs = (OVRTouchpad.TouchArgs)args;
        //    OVRTouchpad.TouchEvent touchEvent = touchArgs.TouchType;

        //    switch (touchEvent)
        //    {
        //        case OVRTouchpad.TouchEvent.SingleTap:  // single-click
        //            //Debug.Log("SINGLE CLICK\n");
        //            break;

        //        case OVRTouchpad.TouchEvent.Left:
        //            //Debug.Log("LEFT SWIPE\n");
        //            break;

        //        case OVRTouchpad.TouchEvent.Right:
        //            //Debug.Log("RIGHT SWIPE\n");
        //            break;

        //        case OVRTouchpad.TouchEvent.Up:
        //            //Debug.Log("UP SWIPE\n");
        //            break;

        //        case OVRTouchpad.TouchEvent.Down:
        //            //Debug.Log("DOWN SWIPE\n");
        //            break;
        //    }
        //}

        //private void ProcessSequentialUIStateRequests()
        //{
        //    if (Input.GetKeyDown(KeyCode.A)
        //    {
        //        Debug.Log("Next requested");
        //        //UIManagerSequential.GoToNextState();
        //        eGameState nextState = UIManagerSequential.Instance.GetNextStateFor(TempGameManager.Instance.CurrentGameState);
        //        GameMgr.ChangeToGameState(nextState);
        //    }

        //    if (Input.GetKeyDown(KeyCode.B))
        //    {
        //        Debug.Log("Previous requested");
        //        //UIManagerSequential.GoToPreviousState();
        //        //GameMgr.ChangeToGameState(nextState);
        //        eGameState previousState = UIManagerSequential.Instance.GetPreviousStateFor(TempGameManager.Instance.CurrentGameState);
        //        GameMgr.ChangeToGameState(previousState);
        //    }

        //    if (Input.GetKeyDown(KeyCode.C))  //location or launch
        //    {
        //        Debug.Log("Enter Location requested");
        //        //UIManagerSequential.ChangeStateTo(eGameState.EnterLocation);
        //        //StartCoroutine("ReturnToRandomIdle", 10.0f);
        //        GameMgr.ChangeToGameState(eGameState.EnterLocation);
        //    }

        //    if (Input.GetKeyDown(KeyCode.S))  //start
        //    {
        //        Debug.Log("Enter Username requested");
        //        // UIManagerSequential.ChangeStateTo(eGameState.PreGame);  // enter username
        //        GameMgr.ChangeToGameState(GameMgr.StartGameState);

        //    }

        //    if (Input.GetKeyDown(KeyCode.G))
        //    {
        //        Debug.Log("GamePlay requested");
        //        //StartCoroutine("ReturnToRandomIdle", 1.0f);   // if you want to return from idle after a wait interval
        //        //UIManagerSequential.ChangeStateTo(eGameState.PlayRound); 
        //        GameMgr.ChangeToGameState(GameMgr.LoopStartGameState);
        //        // GameMgr.ChangeToGameState(eGameState.PlayRound);
        //    }
        //}
        #endregion

    }
}

