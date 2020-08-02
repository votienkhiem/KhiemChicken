using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Vector3 scale;
    public Gradient gradient;
    public Image fill;
    // public Frog frog;
    //  public opposumwalker creep;
    public void Start()
    {
       // creep = GameObject.FindGameObjectWithTag("Enemy").GetComponent<opposumwalker>();
        //frog = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Frog>();

    }
    public void SetMaxHealth(int health)
    {
        scale = gameObject.transform.localScale;
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
    //kiểm tra hướng của thanh máu
    public void checkScale()
    {
        scale.x *= -1;
        transform.localScale = scale;
    }
    
        
}
