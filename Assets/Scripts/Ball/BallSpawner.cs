using System.Collections.Generic;
using UnityEngine;

namespace SirStudiosCase.Ball
{
    public class BallSpawner : MonoBehaviour
    {
        #region Public Field
        public static BallSpawner Instance;
        public List<Vector3> spawnPositions;
        #endregion

        #region Private Field
        private int _objectCounter;
        private Vector3 _spawnRandomPosition;
        #endregion

        private void Awake() => Instance = this;
        private void Start() => BallCreate();

        #region Void Methods
        public void BallCreate()
        {
            _objectCounter = 0;
            spawnPositions = new List<Vector3>();

            for (int i = 0; i < BallCreator.Instance.balls.Count * 2; i++)
            {
                // _spawnRandomPosition de�i�kenine x ve z de�erleri random �retilen bir vector3 de�er ata.
                _spawnRandomPosition = new Vector3(Random.Range(-2, 2), 0.5f, Random.Range(2, 12));
                // E�er spawnPosition dizisi i�erisinde _spawnRandomPosition de�erinde bir eleman i�ermiyor ise listeye ekle.
                if (!spawnPositions.Contains(_spawnRandomPosition))
                {
                    spawnPositions.Add(_spawnRandomPosition);
                }
            }

            // Sahnede ayn� anda 5 tane obje olmas�n� istedi�imiz i�in count'� 2 ye b�ld�k.
            for (int i = 0; i < BallCreator.Instance.balls.Count / 2; i++)
            {
                // S�ras�yla elemanlar�n pozisyon de�erlerini g�ncelle ve g�r�n�r hale getir.
                BallCreator.Instance.balls[i].transform.position = spawnPositions[i];
                BallCreator.Instance.balls[i].SetActive(true);
                // Ka� tane obje �retildi�ini tutan de�i�ken.
                _objectCounter++;
            }
        }

        public void GetNewBall()
        {
            // E�er �retilen obje ball listesinin eleman say�s�ndan k���k ise.
            if (_objectCounter < BallCreator.Instance.balls.Count)
            {
                // �retilmeyen elemanlar� s�ras�yla �ret ve obje sayac�n� g�ncelle.
                BallCreator.Instance.balls[_objectCounter].transform.position = spawnPositions[_objectCounter];
                BallCreator.Instance.balls[_objectCounter].SetActive(true);
                _objectCounter++;
            }
        }
        #endregion
    }
}