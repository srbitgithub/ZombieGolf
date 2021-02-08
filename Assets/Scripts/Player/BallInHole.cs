using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInHole : MonoBehaviour
{
    public Transform fireworks01;
    public Transform fireworks02;
    public Transform fireworks03;
    public GameObject dressingBall;
    public AudioSource explosion01;
    public AudioSource explosion02;
    public AudioSource explosion03;
    public AudioSource ballInHole;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("playerTrajectory");
        print("Bola en hoyo");
        if (collision.gameObject.CompareTag("theBall"))
        {
            ballInHole.Play();

            //player.GetComponent<PlayerTrajectory>().enabled = false;
            //player.GetChild(0).transform.GetComponent<PlayerTrajectory>().enabled = false;
            //player.transform.GetChild(0).GetComponent<PlayerTrajectory>().enabled = false;
            Vector3 positionDressingBall = collision.transform.position;
            Quaternion rotationDressingBall = collision.transform.rotation;
            Instantiate(dressingBall, positionDressingBall, rotationDressingBall);

            print(collision.gameObject.transform.parent.name);

            Destroy(player);
            //player.transform.GetComponent<PlayerTrajectory>().enabled = false;

            fireworks01.gameObject.SetActive(true);
            explosion01.PlayDelayed(0.5f);
            fireworks02.gameObject.SetActive(true);
            explosion02.PlayDelayed(0.65f);
            fireworks03.gameObject.SetActive(true);
            explosion03.PlayDelayed(0.8f);

        }
    }
}
