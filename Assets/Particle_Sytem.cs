using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Sytem : MonoBehaviour
{
    [SerializeField] ParticleSystem pickCoin;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        pickCoin.Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "styem")
        {
            pickCoin.Play();
            Debug.Log("ajjajaa");
        }
    }
}
