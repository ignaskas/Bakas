using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class menuBehaviur : MonoBehaviour
{
    public int pointsLeft = 10;
    public int intelStat;
    public int strStat;
    public int agyStat;

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
    public GameObject storyPlate;
    public GameObject key;
    public GameObject sword;
    public GameObject staff;
    public GameObject blaster;
    public GameObject flaskEmpty;
    public GameObject flaskFull;
    public GameObject coinPurse;
    public GameObject armor;

    public Main_Behaviour mainBehaviourRef;
    
    void Start()
    {
        didintSpendAllPoints.gameObject.SetActive(false);
        storyPlate.gameObject.SetActive(false);
        key.gameObject.SetActive(true);
        sword.gameObject.SetActive(false);
        staff.gameObject.SetActive(false);
        blaster.gameObject.SetActive(false);
        flaskEmpty.gameObject.SetActive(true);
        flaskFull.gameObject.SetActive(false);
        coinPurse.gameObject.SetActive(false);
        armor.gameObject.SetActive(false);
        foreach (var i in mainBehaviourRef.menuCards)
        {
            i.gameObject.SetActive(false);
        }
    }

    // Register Button events
    private void OnEnable()
    {
        buttonint.onClick.AddListener(() => buttonCallBackint());
        buttonstr.onClick.AddListener(() => buttonCallBackstr());
        buttonagy.onClick.AddListener(() => buttonCallBacksagy());
        buttonStartGame.onClick.AddListener(() => ButtonCallBackStartGame());
    }

    // Start the game only if all atribute points were spent if not display a message remove all menu elements off screen
    private void ButtonCallBackStartGame()
    {
        if (pointsLeft != 0)
        {
            didintSpendAllPoints.gameObject.SetActive(true);
        }
        else
        {
            mainBehaviourRef.CreateObjects();
            foreach (var i in mainBehaviourRef.menuCards)
            {
                i.gameObject.SetActive(true);
            }
            pointsLeftToSpend.gameObject.SetActive(false);
            didintSpendAllPoints.gameObject.SetActive(false);
            buttonint.gameObject.SetActive(false);
            buttonstr.gameObject.SetActive(false);
            buttonagy.gameObject.SetActive(false);
            buttonStartGame.gameObject.SetActive(false);
            pointsLeftToSpendBackdrop.gameObject.SetActive(false);
            storyPlate.gameObject.SetActive(true);
        }
    }
    //TODO: Missing button lockout before the animation finishes
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
            intelStat += 1;
            txtint.text = "Intelligence: " + intelStat.ToString();
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