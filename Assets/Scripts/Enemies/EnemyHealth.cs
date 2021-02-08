using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    float maxHealth = 100f;
    float currentHealth = 100f;
    int damageHits = 2;
    float damage;
    SpriteRenderer sr;
    AudioSource soundHit;
    public GameObject coin;
    public GameObject newPlayer;
    public GameObject explosionZombie;
    //GameObject newBall;
    Vector3 coinPosition;
    float coinY = -1.29f;
    float expolosionPositionY = -1.47f;
    Vector3 explosionPosition;
    Vector3 ballStartPosition;
    public Image healthBar;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("theBall"))
        {
            damageHits --;
            if (damageHits >= 1)
            {
                sr.color = Color.red;
                Invoke("ResetMaterial", .15f);
                currentHealth -= damage;
                healthBar.fillAmount = currentHealth / maxHealth;
                soundHit.Play();
                Destroy(collision.transform.parent.gameObject);
                Instantiate(newPlayer, ballStartPosition, transform.rotation);
            }
            else
            {
                killSelf(collision.transform.parent.gameObject);
            }
        }
    }

    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        damage = 100f / damageHits;
        soundHit = GetComponent<AudioSource>();
        ballStartPosition = new Vector3(0, 0, 0);
    }

    void killSelf(GameObject player)
    {
        coinPosition = new Vector3 (gameObject.transform.position.x, coinY, 0f);
        explosionPosition = new Vector3(gameObject.transform.position.x, expolosionPositionY, 0f);
        Instantiate(coin, coinPosition, gameObject.transform.rotation);
        Destroy(gameObject);
        Destroy(player);
        Instantiate(newPlayer, ballStartPosition, transform.rotation);
        Instantiate(explosionZombie, explosionPosition, transform.rotation);
        //explosionZombie.GetComponent<ParticleSystem>().Play()
    }

    void ResetMaterial()
    {
        sr.color = Color.white;
    }

}
