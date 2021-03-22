using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    bool isMoving = false;
    bool whasThereAShot = false;
    Vector3 ballStartPosition;
    Quaternion ballStartAngle;
    
    public GameObject newPlayer;
    GameObject currentPlayer;
    
    Rigidbody2D rb;


    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        ballStartPosition = new Vector3(0, 0, 0);
        ballStartAngle = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        if (isMoving && rb.velocity != new Vector2 (0.0f, 0.0f))
        {
            whasThereAShot = true;
            GetComponent<PlayerTrajectory>().enabled = false;
        }
        else
        {
            isMoving = false;
            GetComponent<PlayerTrajectory>().enabled = true;
            if (whasThereAShot)
            {
                GameObject kko = Instantiate(newPlayer, ballStartPosition, ballStartAngle);
                Destroy(gameObject.transform.parent.gameObject);
                if (kko.transform.GetChild(0).transform.position != new Vector3(-7f, 2.18f, 0f))
                {
                    kko.transform.GetChild(0).transform.position = new Vector3(-7f, kko.transform.GetChild(0).transform.position.y, kko.transform.GetChild(0).transform.position.z);
                    whasThereAShot = false;
                }

            }
        }
    }

    public void playerShoot(Vector3 angleShoot, int powerShoot)
    {
        isMoving = true;
        GetComponent<AudioSource>().Play();
        transform.eulerAngles = angleShoot;
        rb.AddForce(transform.right * powerShoot, ForceMode2D.Impulse);
        isMoving = true;
    }
}
