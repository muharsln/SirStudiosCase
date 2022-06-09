using UnityEngine;

namespace SirStudiosCase.Camera
{
    public class CameraController : MonoBehaviour
    {
        #region Private Field
        [SerializeField] private Transform _target;
        [SerializeField] private CameraSettings _cameraSettings;
        #endregion

        #region Process
        private void Start() =>
            _cameraSettings.Distance = transform.position - _target.position;
        private void LateUpdate() =>
            transform.position = Vector3.Lerp(transform.position, _target.position + _cameraSettings.Distance, _cameraSettings.FollowSmooth * Time.deltaTime);
        #endregion
    }
}