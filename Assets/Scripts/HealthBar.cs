using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health PlayerHealth;
    [SerializeField] private Image TotalHealthBar;
    [SerializeField] private Image CurrentHealthBar;
    void Start()
    {
        TotalHealthBar.fillAmount = PlayerHealth.currenthealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealthBar.fillAmount = PlayerHealth.currenthealth / 10;
    }
}
