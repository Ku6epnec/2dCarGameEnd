using UnityEngine;


namespace Game.Trail
{
    public class CursorTrailView : MonoBehaviour
    {
        #region Fields

        private bool _isInit;
        private Camera _camera;

        #endregion

        #region Methods

        public void Init()
        {
            _camera = Camera.main;
            _isInit = _camera != null;
        }

        private void Update()
        {
            if (_isInit)
            {
                Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = transform.position.z;
                transform.position = mousePosition;
            }
        }

        #endregion
    }
}

