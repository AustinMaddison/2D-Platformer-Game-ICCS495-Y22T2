using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI HpNumberText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMaxHealth(int health)
    {
        slider.maxValue= health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        HpNumberText.text = health.ToString();
    }

}
