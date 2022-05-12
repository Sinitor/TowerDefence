using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class TowerManager : MonoBehaviour
{
    TowerBtn towerPressed;
    private Camera cam;
    private int spawn = 0;
    public static int money;
    private void Start()
    {
        cam = Camera.main;
        money = 10;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider.tag == "TowerGround" && spawn == 1 && money >= towerPressed.moneyTower)
            {
                hit.collider.tag = "TowerFull";
                PlaceTower(hit);
                spawn = 0;
            }
        }
    } 
    public void PlaceTower(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerPressed.Tower != null)
        {
            GameObject newTower = Instantiate(towerPressed.Tower);
            newTower.transform.position = hit.transform.position;
            money -= towerPressed.moneyTower;
        }
    }

    public void SelectedTower(TowerBtn towerSelected)
    {
        towerPressed = towerSelected;
        Debug.Log("Pressed" + towerPressed.gameObject);
        spawn = 1;
    } 
}
