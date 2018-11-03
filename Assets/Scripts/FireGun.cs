using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour {

    private ParticleSystem fireParticles;
    private bool isShooting = false;

    public void StartShooting()
    {
        if (!isShooting)
        {
            fireParticles.Play();
            isShooting = true;
        }
    }

    public void StopShooting()
    {
        fireParticles.Stop();
        isShooting = false;
    }

    private void Start()
    {
        fireParticles = GetComponent<ParticleSystem>();
        fireParticles.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle collision: " + other);
        Flammable flammable = other.GetComponent<Flammable>();
        if (flammable)
        {
            flammable.Burn();
        }
    }
}
