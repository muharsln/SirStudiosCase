using UnityEngine;

namespace SirStudiosCase.Camera
{
    [CreateAssetMenu(menuName = "SirStudiosCase/Camera/CameraSettings")]
    public class CameraSettings : ScriptableObject
    {
        // Kameran�n ne kadar smooth hareket edece�ini tutan de�i�ken.
        [SerializeField] private float _followSmooth;
        public float FollowSmooth => _followSmooth;

        // Karakter ile kamera aras�ndaki mesafeyi tutan de�i�ken.
        [SerializeField] private Vector3 _distance;
        public Vector3 Distance { get { return _distance; } set { _distance = value; } }
    }
}