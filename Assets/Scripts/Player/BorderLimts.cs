using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLimts : MonoBehaviour
{
    Vector3 ballStartPosition;
    public GameObject newPlayer;

    void Start()
    {
        ballStartPosition = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("theBall"))
        {
            Instantiate(newPlayer, ballStartPosition, transform.rotation);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
