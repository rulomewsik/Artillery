using UnityEngine;

namespace _Scripts
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;

        private GameObject _canonHead;
        private float _rotation;
        private int BallsShoot { get; set; }

        private void Start()
        {
            _canonHead = transform.Find("CanonHead").gameObject;
            BallsShoot = 0;
        }

        private void Update()
        {
            _rotation += Input.GetAxis("Horizontal") * GameAdmin.RotationSpeed;
            if (_rotation is <= 90 and >= 0)
            {
                transform.eulerAngles = new Vector3(_rotation, 90, 0.0f);
            }

            if (_rotation > 90) _rotation = 90;
            if (_rotation < 0) _rotation = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (BallsShoot >= GameAdmin.BallsPerGame)
                {
                    Debug.LogWarning("All balls shoot");
                }
                else
                {
                    var rotation = transform.rotation;
                    var temp = Instantiate(ballPrefab, _canonHead.transform.position, rotation);
                    var tempRb = temp.GetComponent<Rigidbody>();
                    var shotDirection = rotation.eulerAngles;
                    shotDirection.y = 90 - shotDirection.x;
                    tempRb.velocity = shotDirection.normalized * GameAdmin.BallSpeed;

                    BallsShoot += 1;
                    var ballsRemaining = GameAdmin.BallsPerGame - BallsShoot;
                    Debug.LogWarning(ballsRemaining + " -> balls remaining");
                }
            }
        }
    }
}