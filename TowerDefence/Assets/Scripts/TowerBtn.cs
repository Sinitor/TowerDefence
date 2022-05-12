using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    public int moneyTower;
    public GameObject Tower
    { 
        get { return tower; }
    } 
}
