using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody thisRigidyBody;

    void Start()
    {
        thisRigidyBody = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            thisRigidyBody.AddForce(Vector3.up * 200);
        }
        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y,-5, 3.5f));
        if(transform.position.y <= -5)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
            Destroy(other.gameObject);
        }
    }
}
