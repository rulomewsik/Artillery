using UnityEngine;

public class GameAdmin : MonoBehaviour
{
    public static GameAdmin GameAdminSingleton;
    public static int BallSpeed = 30;
    public static int BallsPerGame = 10;
    public static float RotationSpeed = 1;

    private void Awake()
    {
        if (GameAdminSingleton == null)
        {
            GameAdminSingleton = this;
        }
        else
        {
            Debug.LogError("Instance already created");
        }
    }
}