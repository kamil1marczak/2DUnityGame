using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Astronaut : MonoBehaviour
{
    public GameObject losePanel;
    public Text healthDisplay;
    public double speed;
    private float _input;
    private Rigidbody2D _rb;
    private Animator _playerAnimator;
    private AstronautSounds _astronautSounds;
    

    public int health;
    void Start()
    {
        _astronautSounds = GameObject.FindGameObjectWithTag("AstronautSounds").GetComponent<AstronautSounds>();
        healthDisplay.text = health.ToString();
        _rb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        
    }
    // Update is called once per frame

    void Update()
    {
        if (_input != 0)
        {
            _playerAnimator.SetBool("isFlying", true);
        }
        else
        {
            _playerAnimator.SetBool("isFlying", false);
        }

        if (_input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (_input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
    }

    void FixedUpdate()
    {
        // store input value (determined by arrows in range [-1, 0, 1])
        _input = Input.GetAxisRaw("Horizontal");
        print(_input);
        
        // moving player
        _rb.velocity = new Vector2((float) (_input * speed), 0);
        
    }

    public void TakeDamage(int damageAmount)
    {
        _astronautSounds.PlayHurtSounds();
        health -= damageAmount;
        healthDisplay.text = health.ToString();
        
        if (health <= 0)
        {
            _astronautSounds.PlayEndGameSound();
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
        
        print(health);
    }

    public void SpeedUp(double speedUp)
    {
        speed = speed * speedUp;
    }
}
