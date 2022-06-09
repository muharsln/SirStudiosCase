using UnityEngine;

namespace SirStudiosCase.Ball
{
    public class BallController : MonoBehaviour, ICollectable
    {
        public int objectID;
        public void Collect()
        {
            // Temas edilen objenin g�r�n�rl���n� pasif hale getir ve yeni top olu�tur.
            BallCreator.Instance.balls[objectID].SetActive(false);
            BallSpawner.Instance.GetNewBall();
        }
    }
}