using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStar : MonoBehaviour
{
    public AudioSource starSound;

    public void getStarSound()
    {
        starSound.Play();
    }
}
