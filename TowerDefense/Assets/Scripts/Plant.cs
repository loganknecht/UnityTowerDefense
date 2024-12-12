using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Entity
{
    public Health health = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public override void Update()
    {
        if (this.health.currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
