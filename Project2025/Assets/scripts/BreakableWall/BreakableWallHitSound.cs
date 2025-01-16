using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWallHitSound : MonoBehaviour
{
    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void PlaySoundHit(float health, float maxHealth)
    {
        audioSources[0].pitch = 2.6f - ((health / maxHealth) * 2.5f);
        audioSources[0].Play();
    }
    public void PlaySoundDestroy()
    {
        audioSources[1].Play();
    }

}
