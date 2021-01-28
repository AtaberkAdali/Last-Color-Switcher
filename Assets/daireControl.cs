using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daireControl : MonoBehaviour
{
    public bool solaDon;
    public float DonmeHizi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (solaDon)
        {
            transform.Rotate(0f, 0f, DonmeHizi * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, 0f, -DonmeHizi * Time.deltaTime);
        }
    }
}
