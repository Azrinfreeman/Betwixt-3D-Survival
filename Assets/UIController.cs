using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
         healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        healthText = GameObject.Find("number").GetComponent<TextMeshProUGUI>();
    }
    public void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
