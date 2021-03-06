using UnityEngine;

namespace SirStudiosCase.Ball
{
    public class BallController : MonoBehaviour, ICollectable
    {
        public int objectID;
        public void Collect()
        {
            // Temas edilen objenin görünürlüğünü pasif hale getir ve yeni top oluştur.
            BallCreator.Instance.balls[objectID].SetActive(false);
            BallSpawner.Instance.GetNewBall();
        }
    }
}