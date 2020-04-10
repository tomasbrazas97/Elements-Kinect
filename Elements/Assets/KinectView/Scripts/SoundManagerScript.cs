using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip deathSound, clickSound, explosionSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        deathSound = Resources.Load<AudioClip>("DeathSound");
        clickSound = Resources.Load<AudioClip>("ClickSound");
        explosionSound = Resources.Load<AudioClip>("Explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "DeathSound":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "ClickSound":
                audioSrc.PlayOneShot(clickSound);
                break;
            case "Explosion":
                audioSrc.PlayOneShot(explosionSound);
                break;
        }
    }
}
