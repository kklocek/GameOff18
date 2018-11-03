using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour {

    [SerializeField]
    private float power = 10f;
    private ParticleSystem waterParticles;
    private bool isShooting = false;

    public void StartShooting()
    {
        if(!isShooting)
        {
            waterParticles.Play();
            isShooting = true;
        }
    }

    public void StopShooting()
    {
        waterParticles.Stop();
        isShooting = false;
    }

    private void Start()
    {
        waterParticles = GetComponent<ParticleSystem>();
        waterParticles.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle collision: " + other);
        Flammable flammable = other.GetComponent<Flammable>();
        if(flammable)
        {
            flammable.Extinguish(power);
        }
    }

    private void Update()
    {

    }


}
