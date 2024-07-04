using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LooseCondition : MonoBehaviour
{
    [SerializeField] private GameObject loosePanel;
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (player == null)
        {
            Debug.Log("Memuri ;C");
            loosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
