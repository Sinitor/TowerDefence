using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public static int hp;
    [SerializeField] private Image healthSlider;
    [SerializeField] private Image losePanel;

    private void Start()
    {
        hp = 10;
    }
    private void Update()
    {
        if (hp <= 0)
        {
            losePanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp--;
            healthSlider.fillAmount -= 0.1f;
        }
    }
}
