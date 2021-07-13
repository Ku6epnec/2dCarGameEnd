﻿using JoostenProductions;
using Tools;
using UnityEngine;


namespace Game.InputLogic
{
    public class EndlessMoveView : BaseInputView
    {

        #region Methods

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(MoveToRight);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(MoveToRight);
        }

        private void MoveToRight()
        {
            OnRightMove(_speed * Time.deltaTime);
        }

        #endregion
    }
}

