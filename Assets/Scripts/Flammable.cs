using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammable : MonoBehaviour {

    public bool IsBurning { get; private set; }
    public bool IsBurned { get; private set; }

    [SerializeField]
    [Range(0f, 100f)]
    private float hp = 100f;
    [SerializeField]
    private float hpDropOrig = 5f;
    private float hpDrop = 5f;
    private SpriteRenderer spriteRenderer;

    public void Burn()
    {
        if(IsBurned)
        {
            return;
        }
        IsBurning = true;
    }

    public void Extinguish(float power)
    {
        if(IsBurning)
        {
            hpDrop -= power * Time.deltaTime;
            if(hpDrop <= 0)
            {
                IsBurning = false;
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
        if(IsBurned)
        {
            return;
        }
        if(IsBurning)
        {
            hp -= hpDrop * Time.deltaTime;
            if(hp <= 0)
            {
                IsBurned = true;
                IsBurning = false;
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
