using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int healt = 10;
    [SerializeField] int healtDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamage;
    // Use this for initialization
    void Start () {
        healthText.text = healt.ToString();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamage);
        healt -= healtDecrease;
        healthText.text = healt.ToString();
    }
}
