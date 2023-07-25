using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public Rigidbody2D Pin;
    public float pinspeed = 10f;

    private bool isPinned = false;
    private bool isLaunched = false;
    // Start is called before the first frame update
    void Start()
    {
        Pin = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPinned == false && isLaunched == true)
        {
            transform.position += Vector3.up * pinspeed * Time.deltaTime;
                //Pin.AddForce(transform.up * pinspeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
        {
            isPinned = true;

            if(other.gameObject.tag == "MainCircle")
            {
                //GameObject childObject = transform.Find("Square").gameObject;
                GameObject childObject = transform.GetChild(0).gameObject;
                SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
                childSprite.enabled = true;

                transform.SetParent(other.gameObject.transform);

                GameManager.instance.DecreaseGoal();
            }
            else if(other.gameObject.tag == "Pin")
            {
                GameManager.instance.SetGameOver(false);
            }
        }
    
    public void Launch()
    {
        isLaunched = true;
    }
}

