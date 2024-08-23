using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5;
    public GameObject PlayerHands;
    public GameObject ObjectInMyHands;  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            this.transform.position += Camera.main.transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            other.gameObject.transform.SetParent(PlayerHands.transform);
            other.gameObject.transform.position = PlayerHands.transform.position;
            ObjectInMyHands = other.gameObject;
        }

        if (other.gameObject.tag == "Target")
        {
            other.gameObject.SetActive(false);
            ObjectInMyHands.transform.SetParent(null);
            ObjectInMyHands.transform.position = other.gameObject.transform.position + new Vector3(0, -0.09f, 0);
            ObjectInMyHands.tag = "BallDown";
        }
    }
}
