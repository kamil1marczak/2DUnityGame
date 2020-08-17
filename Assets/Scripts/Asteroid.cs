using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    
    public double minSpeed;
    public double maxSpeed;
    
    private float _asteroidSpeed;

    private Astronaut _astronautScript;

    public int damage;

    public GameObject explosion;
    private PointsManager _pointsScript;
    private GameObject _astronaut;
    private GameObject _explosion;
    
    void Start()
    {
        _asteroidSpeed = Random.Range((float) minSpeed, (float) maxSpeed);
        _astronautScript = GameObject.FindGameObjectWithTag("Astronaut").GetComponent<Astronaut>();
        _pointsScript = GameObject.FindGameObjectWithTag("PointsManager").GetComponent<PointsManager>();
        _astronaut = GameObject.FindGameObjectWithTag("Astronaut");
        _explosion = GameObject.FindGameObjectWithTag("Explosion");

    }

    void Update()
    {
        if (_astronaut != null)
        {
            transform.Translate(Vector2.down * (_asteroidSpeed * Time.deltaTime));
        }
        else
        {
            Destroy(gameObject);
            Destroy(_explosion);
        }

    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Astronaut")
        {
            _astronautScript.TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        if (hitObject.tag == "Ground")
        {
            _pointsScript.AddPoint();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void SpeedUp(double speedUp)
    {
        minSpeed *= speedUp;
        maxSpeed *= speedUp;
    }
}
