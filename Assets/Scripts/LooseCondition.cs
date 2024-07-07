using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LooseCondition : MonoBehaviour
{
    public GameObject loosePanel;
    [SerializeField] private GameObject player;

    private void Update()
    {
        if (player == null)
        {
            Cursor.lockState = CursorLockMode.None;
            //Debug.Log("Memuri ;C");
            loosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
