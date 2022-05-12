using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    private void Update()
    {
        moneyText.text = "" + TowerManager.money;
    } 
    public void Remake()
    {
        SceneManager.LoadScene(0);
    }
}
