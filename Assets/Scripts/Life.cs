using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LifeReachedZero();

public class Life : MonoBehaviour {

    public event LifeReachedZero OnLifeReachedZero;

    public float Value { get { return value; } }

    [SerializeField]
    private float value = 100f;
    private bool died = false;

    private void Update()
    {
        if(!died && value <= 0)
        {
            died = true;
            OnLifeReachedZero.Invoke();
        }
    }


}
