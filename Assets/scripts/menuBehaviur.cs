﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class menuBehaviur : MonoBehaviour
{
    public int pointsLeft = 10;
    public int inteStat = 0;
    public int strStat = 0;
    public int agyStat = 0;

    public Text txtint;
    public Text txtstr;
    public Text txtagy;
    public Text txtPointsLeft;

    public Button buttonint;
    public Button buttonstr;
    public Button buttonagy;
    public Button buttonStartGame;

    public GameObject didintSpendAllPoints;
    public GameObject pointsLeftToSpend;
    public GameObject pointsLeftToSpendBackdrop;

    // Start is called before the first frame update
    void Start()
    {
        didintSpendAllPoints.gameObject.SetActive(false);
    }

    // Register Button events
    private void OnEnable()
    {
        buttonint.onClick.AddListener(() => buttonCallBackint());
        buttonstr.onClick.AddListener(() => buttonCallBackstr());
        buttonagy.onClick.AddListener(() => buttonCallBacksagy());
        buttonStartGame.onClick.AddListener(() => buttonCallBackStartGame());
    }

    // Start the game only if all atribute points were spent if not display a message remove all menu elements off screen
    private void buttonCallBackStartGame()
    {
        if (pointsLeft != 0)
        {
            didintSpendAllPoints.gameObject.SetActive(true);
        }
        else
        {
            pointsLeftToSpend.gameObject.SetActive(false);
            didintSpendAllPoints.gameObject.SetActive(false);
            buttonint.gameObject.SetActive(false);
            buttonstr.gameObject.SetActive(false);
            buttonagy.gameObject.SetActive(false);
            buttonStartGame.gameObject.SetActive(false);
            pointsLeftToSpendBackdrop.gameObject.SetActive(false);
            // Debug.Log("Start the game points are at 0");
        }
    }
    
    // adds 1 point to attribte agy evry time a button is pressed
    private void buttonCallBacksagy()
    {
        if (pointsLeft > 0)
        {
            agyStat += 1;
            txtagy.text = "Agility: " + agyStat.ToString();
            removePoint();
        }
        txtPointsLeft.text = "Points Left: " + pointsLeft.ToString();
    }
    
    // adds 1 points to attribute str evry time a button is pressed
    private void buttonCallBackstr()
    {
        if (pointsLeft > 0)
        {
            strStat += 1;
            txtstr.text = "Strength: " + strStat.ToString();
            removePoint();
        }
        txtPointsLeft.text = "Points Left: " + pointsLeft.ToString();
    }
    
    // adds 1 points to attribute int evry time a button is presses
    private void buttonCallBackint()
    {
        if (pointsLeft > 0)
        {
            inteStat += 1;
            txtint.text = "Intelligence: " + inteStat.ToString();
            removePoint();
        }
        txtPointsLeft.text = "Points Left: " + pointsLeft.ToString();
    }

    // removes 1 point from atribute pool evry time a button is clicked
    private void removePoint()
    {
        pointsLeft -= 1;
    }
}