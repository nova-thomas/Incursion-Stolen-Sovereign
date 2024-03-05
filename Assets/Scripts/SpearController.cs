using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    public void normalizeDir()
    {
        rb.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
