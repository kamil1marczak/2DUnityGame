using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointsManager : MonoBehaviour
{
    private int _points = 0;
    private static int _pointsToLevel = 5;
    private int _pointsToNextLevel = _pointsToLevel;
    public Text pointsDisplay;
    public Text levelUpDisplay;
    private Astronaut _astronautScript;
    private Asteroid _asteroidScript;

    public void Start()
    {
        pointsDisplay.text = _points.ToString();
    }

    public void AddPoint()
    {
        _points += 1;
        _pointsToNextLevel -= 1;
        pointsDisplay.text = _points.ToString();
        if (_pointsToNextLevel == 0)
        {
            LevelUp(1.5);
            StartCoroutine(DisableLevelUpDisplay(3));
            _pointsToNextLevel = _pointsToLevel;
        }
    }

    IEnumerator  DisableLevelUpDisplay(int seconds)
    {
        levelUpDisplay.text = ("Leveled Up!");
        yield return new WaitForSeconds(2f);
        levelUpDisplay.text = ("");
    }

    public void LevelUp(double spedUp)
    {
        _astronautScript = GameObject.FindGameObjectWithTag("Astronaut").GetComponent<Astronaut>();
        _astronautScript.SpeedUp(spedUp);
        _asteroidScript = GameObject.FindGameObjectWithTag("Asteroid").GetComponent<Asteroid>();
        _asteroidScript.SpeedUp(spedUp);
    }
    

}
