using UnityEngine;

namespace SirStudiosCase.Camera
{
    [CreateAssetMenu(menuName = "SirStudiosCase/Camera/CameraSettings")]
    public class CameraSettings : ScriptableObject
    {
        // Kameranýn ne kadar smooth hareket edeceðini tutan deðiþken.
        [SerializeField] private float _followSmooth;
        public float FollowSmooth => _followSmooth;

        // Karakter ile kamera arasýndaki mesafeyi tutan deðiþken.
        [SerializeField] private Vector3 _distance;
        public Vector3 Distance { get { return _distance; } set { _distance = value; } }
    }
}