﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureMode : MonoBehaviour
{
    #region Variables
    [SerializeField] public Transform startpoint;
    [SerializeField] public Transform endpoint;
    [SerializeField] public GameObject character;
    //
    [SerializeField] private int itenscolected;
    [SerializeField] private int itensinstage;
    [SerializeField] List<GameObject> disableditens = new List<GameObject>();
    //
    [SerializeField] private int points;
    [SerializeField] public float timecounter;
    [SerializeField] List<bool> objectives = new List<bool>();
    [SerializeField] int completedobjectives;
    [SerializeField] bool MainObjective = false;
    #endregion

    void OnEnable()
    {
        timecounter = 0;
        MainObjective = false;
        CharactertoStartPoint();
        for (int i = 0; i < disableditens.Count; i++)
        {
            disableditens[i].SetActive(true);
        }
        Collect.aPoint += CollectCount;
    }

    void Update()
    {
        if (GameManager.gt == GameManager.GameStates.playing && MainObjective == false)
        {
            
            Timer(Time.deltaTime);
        }
    }
    void ObjectiveCounter()
    {
        for (int i = 0; i < objectives.Count; i++)
        {
            if (objectives[i] == true)
            {
                completedobjectives++;
            }
        }
    }

    void EndPoint(Transform a, Transform b)
    {
            MainObjective = true;
            //Reached final map point
            ObjectiveCounter();
    }

    void Timer(float delta)
    {
        timecounter += delta;
    }

    public void CollectCount(string tag)
    {
        if (tag == "collectable")
        {
            itenscolected++;
        }
        if (tag == "coin")
        {
            points++;
        }
        
        if (itenscolected == itensinstage)
        {
            objectives.Add(true);
        }
    }

    public void CharactertoStartPoint()
    {
        character.transform.position = startpoint.transform.position;
    }
}