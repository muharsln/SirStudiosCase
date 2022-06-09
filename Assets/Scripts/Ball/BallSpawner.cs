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
                // _spawnRandomPosition deðiþkenine x ve z deðerleri random üretilen bir vector3 deðer ata.
                _spawnRandomPosition = new Vector3(Random.Range(-2, 2), 0.5f, Random.Range(2, 12));
                // Eðer spawnPosition dizisi içerisinde _spawnRandomPosition deðerinde bir eleman içermiyor ise listeye ekle.
                if (!spawnPositions.Contains(_spawnRandomPosition))
                {
                    spawnPositions.Add(_spawnRandomPosition);
                }
            }

            // Sahnede ayný anda 5 tane obje olmasýný istediðimiz için count'ý 2 ye böldük.
            for (int i = 0; i < BallCreator.Instance.balls.Count / 2; i++)
            {
                // Sýrasýyla elemanlarýn pozisyon deðerlerini güncelle ve görünür hale getir.
                BallCreator.Instance.balls[i].transform.position = spawnPositions[i];
                BallCreator.Instance.balls[i].SetActive(true);
                // Kaç tane obje üretildiðini tutan deðiþken.
                _objectCounter++;
            }
        }

        public void GetNewBall()
        {
            // Eðer üretilen obje ball listesinin eleman sayýsýndan küçük ise.
            if (_objectCounter < BallCreator.Instance.balls.Count)
            {
                // Üretilmeyen elemanlarý sýrasýyla üret ve obje sayacýný güncelle.
                BallCreator.Instance.balls[_objectCounter].transform.position = spawnPositions[_objectCounter];
                BallCreator.Instance.balls[_objectCounter].SetActive(true);
                _objectCounter++;
            }
        }
        #endregion
    }
}