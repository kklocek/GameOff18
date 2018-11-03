using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour {

    [SerializeField]
    [Range(0f, 100f)]
    private float hp = 100f;
    [SerializeField]
    private float hpDropOrig = 5f;
    [SerializeField]
    private bool isBurning = false;
    private bool isBurned = false;
    private float hpDrop = 5f;
    private SpriteRenderer spriteRenderer;

    public void Burn()
    {
        if(isBurned)
        {
            return;
        }
        isBurning = true;
    }

    public void Extinguish(float power)
    {
        if(isBurning)
        {
            hpDrop -= power * Time.deltaTime;
            if(hpDrop <= 0)
            {
                isBurning = false;
            }
        }
    }

    private void Start()
    {
        hpDrop = hpDropOrig;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isBurned)
        {
            return;
        }
        if(isBurning)
        {
            hp -= hpDrop * Time.deltaTime;
            if(hp <= 0)
            {
                isBurned = true;
                isBurning = false;
                BurnMaterial();
            }
        }
    }

    private void BurnMaterial()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.material.color = Color.black;
        }
    }

}
