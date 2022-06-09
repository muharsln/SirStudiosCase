using System.Collections.Generic;
using UnityEngine;

namespace SirStudiosCase.Ball
{
    public class BallCreator : MonoBehaviour
    {
        #region Public Field
        public static BallCreator Instance;
        public List<GameObject> balls;
        #endregion

        #region Private Serialize Field
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private int _ballCount;
        [SerializeField] private Transform _ballParentObject;
        #endregion

        private void Awake() => Instance = this;
        private void Start()
        {
            for (int i = 0; i < _ballCount; i++)
            {
                // Objeyi olu�turup listeye ekle, parent objesini de�i�tir, g�r�n�rl��� pasif yap, olu�an objenin id sine i de�erini ata.
                balls.Add(Instantiate(_ballPrefab));
                balls[i].transform.parent = _ballParentObject;
                balls[i].SetActive(false);
                balls[i].GetComponent<BallController>().objectID = i;
            }
        }
    }
}