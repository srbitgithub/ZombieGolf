using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCapture : MonoBehaviour
{
    AudioSource zombieHit;
    public GameObject player;
    Vector3 ballStartPosition;

    private void Start()
    {
        zombieHit = GetComponent<AudioSource>();
        zombieHit.Play();
        ballStartPosition = new Vector3(0, 0, 0f);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("theBall"))
        {
            Camera.main.GetComponent<PlayStar>().getStarSound();
            // Aquí haríamos la movida de la estrella sumando
            //Instantiate(player, ballStartPosition, transform.rotation);
            Destroy(gameObject);
            //Destroy(collision.transform.parent.gameObject);
        }
    }*/
    /*private void OnTriggerEnter2D(Collider other)
    {
        print(other);
        if (collision.gameObject.CompareTag("theBall"))
        {
            Camera.main.GetComponent<PlayStar>().getStarSound();
            // Aquí haríamos la movida de la estrella sumando
            //Instantiate(player, ballStartPosition, transform.rotation);
            Destroy(gameObject);
            //Destroy(collision.transform.parent.gameObject);
        //}
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Camera.main.GetComponent<PlayStar>().getStarSound();
        Destroy(gameObject);
    }
}
