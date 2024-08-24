using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] GameObject panelGameOver;

    public Image healthBar;
    public float healthAmount = 100;
    public static HealthManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount > 0 && healthAmount <= 100)
        {
            TakeDamage(6f);
        }
        else if (healthAmount > 100)
        {
            healthAmount = 100;
        }
        else if (healthAmount < 0)
        {
            healthAmount = 0;
        }

        if (healthAmount <= 0)
        {
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage * Time.deltaTime * 1.1f;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Heal(float healingAmount)
    {
        if (healthAmount > 0 && healthAmount < 100)
        {
            healthAmount += healingAmount;
            healingAmount = Mathf.Clamp(healingAmount, 0, 100);

            healthBar.fillAmount = healthAmount / 100;
        }
    }
}
