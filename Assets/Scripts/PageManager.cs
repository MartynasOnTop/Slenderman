using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;
    public Flashlight flashlight;
    public FirstPersonMovement firstPersonMovement;

    public AudioSource scream;

    public TMP_Text pageCount;
    public GameObject pagePicture;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        Invoke("UIdestroyer", 2f);

        pages++;
        pageCount.text = pages.ToString();
        pagePicture.SetActive(true);


        if (pages == 1)
        {
            enemy.target = transform;
            scream.Play();
        }
        if (pages == 2)
        {
            enemy.speed *= 2;
        }
        if (pages == 3)
        {
            enemy.wanderDistance *= 2;
        }
        if (pages == 4)
        {
            flashlight.dischargeRate = 3;
        }
        if (pages == 5)
        {
            enemy.viewDistance *= 2;
        }
        if (pages == 6)
        {
            firstPersonMovement.runSpeed = firstPersonMovement.speed;
        }
        if (pages == 7)
        {
            enemy.viewDistance *= 100;
            enemy.speed *= 2;
            flashlight.dischargeRate = 6;
        }
        if (pages == 8)
        {
            SceneManager.LoadScene("Victory");
        }
    }
    void UIdestroyer()
    {
        pageCount.text = "";
        pagePicture.SetActive(false);
    }
}
