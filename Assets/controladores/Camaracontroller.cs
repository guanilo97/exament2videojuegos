using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaracontroller : MonoBehaviour
{
    private Transform _transform;
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = personaje.transform.position.x;
        var y = personaje.transform.position.y;
        var z = _transform.position.z;
        _transform.position = new Vector3(x, y, z);

    }
}
