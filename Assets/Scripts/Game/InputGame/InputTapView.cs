using Tools;
using UnityEngine;
using UnityEngine.UI;


namespace Game.InputLogic
{
    public class InputTapView : BaseInputView
    {
        [SerializeField] 
        private Button _buttonMove;

        #region Methods

        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove,
            float speed)
        {
            base.Init(leftMove, rightMove, speed);
            _buttonMove.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            OnRightMove(Time.deltaTime * _speed);
        }

        #endregion
    }
}

