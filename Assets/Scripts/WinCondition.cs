using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
