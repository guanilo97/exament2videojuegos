using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorController : MonoBehaviour
{
    public GameObject zombies;
    public float tiemppocreacion = 10, rangocreacion = 20f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("creando", 0.0f, tiemppocreacion);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void creando()
    {
        Vector3 position = new Vector3(0, 0, 0);
        position = this.transform.position + Random.onUnitSphere * rangocreacion;
        position = new Vector3(position.x, position.y,0);

        GameObject zombie = Instantiate(zombies, position, Quaternion.identity);
    }
}
