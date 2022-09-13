using UnityEngine;

namespace _Scripts
{
    public class GameAdmin : MonoBehaviour
    {
        private static GameAdmin _gameAdminSingleton;
        internal const int BallSpeed = 30;
        internal const float RotationSpeed = 1;
        internal const int BallsPerGame = 10;
        
        private void Awake()
        {
            if (_gameAdminSingleton == null)
            {
                _gameAdminSingleton = this;
            }
            else
            {
                Debug.LogError("Instance already created");
            }
        }
    }
}