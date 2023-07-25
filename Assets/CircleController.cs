using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public Rigidbody2D MainCircle;
    public float rotatespeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameOver == false)
        {
        transform.Rotate(0,0,-rotatespeed * Time.deltaTime);
        }
    }
}
 