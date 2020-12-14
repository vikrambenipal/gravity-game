using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloat : MonoBehaviour
{
    Vector3 positionOffset = new Vector3();
    Vector3 tempPosition = new Vector3();
    public float frequency = 1;
    public float amplitude = 0.5f;

    private void Start()
    {
        positionOffset = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        tempPosition = positionOffset;
        tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPosition;
    }
}
