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
        StartShooting(Vector2.zero);
    }

    public void StartShooting(Vector2 target)
    {
        //TODO
        //rotate
        transform.LookAt(target);
        //Vector2 myPos = transform.position;
        //Vector2 direction = (target - myPos).normalized;
        //float cosAlfa = Vector2.Dot(direction, transform.right); //unit vectors
        //float alfa = Mathf.Acos(cosAlfa) * Mathf.Rad2Deg;
        //float y = transform.rotation.eulerAngles.y;
        //transform.rotation = Quaternion.Euler(alfa, y, 0);
        //Debug.Log(cosAlfa + " " + alfa + ", rotation y: " + y);
        if (!isShooting)
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
