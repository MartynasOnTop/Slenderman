using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public Light light;

    public int dischargeRate = 2;

    int battery = 100;
    public TMP_Text percent;

    public AudioSource click;

    private void Start()
    {
        InvokeRepeating("BatteryDown", 3f, 3f);
    }
    private void Update()
    {
        light.enabled = isOn;

        if (Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;

            click.Play();
        }
        if (battery <= 0)
        {
            light.enabled = false;
            percent.text = "0";
        }
        else if (battery <= 4)
        {
            isOn = !isOn;
        }
    }
    void BatteryDown()
    {
        if (isOn)
        {
            battery -= dischargeRate;
            percent.text = battery.ToString();
        }
        if (battery >= 70)
        {
            percent.color = Color.green;
            light.range = 40;
            light.intensity = 3;
        }
        else if (battery >= 30)
        {
            percent.color = Color.yellow;
            light.range = 30;
            light.intensity = 2.5f;
        }
        else
        {
            percent.color = Color.red;
            light.range = 20;
            light.intensity = 2;
        }
    }
}
