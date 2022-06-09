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
                // Objeyi oluþturup listeye ekle, parent objesini deðiþtir, görünürlüðü pasif yap, oluþan objenin id sine i deðerini ata.
                balls.Add(Instantiate(_ballPrefab));
                balls[i].transform.parent = _ballParentObject;
                balls[i].SetActive(false);
                balls[i].GetComponent<BallController>().objectID = i;
            }
        }
    }
}