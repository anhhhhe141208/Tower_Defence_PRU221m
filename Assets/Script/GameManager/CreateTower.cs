using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTower : MonoBehaviour
{
    public Button buttonBasicTower;
    public Button buttonAdvancedTower;
    public Button buttonProTower;
    public GameObject towerBasicPrefab;
    public GameObject towerAdvancedPrefab;
    public GameObject towerProPrefab;
    public GameObject buildButton;
    void Start()
    {
        buttonBasicTower.onClick.AddListener(TaskOnClickBasic);
        
        buttonProTower.onClick.AddListener(TaskOnClickPro);

        buttonAdvancedTower.onClick.AddListener(TaskOnClickAdvanced);
    }
    public void TaskOnClickBasic()
    {
        //Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(buttonBasicTower.transform.parent.position);
        GameObject towerObj = Instantiate(towerBasicPrefab, mousePoint, Quaternion.identity);
        buildButton.SetActive(false);

        //PlayerManager.Instance.SubtractMoney(5);
    }
    public void TaskOnClickAdvanced()
    {
        //Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(buttonAdvancedTower.transform.parent.position);
        GameObject towerObj = Instantiate(towerAdvancedPrefab, mousePoint, Quaternion.identity);
        buildButton.SetActive(false);

        //PlayerManager.Instance.SubtractMoney(5);
    }
    public void TaskOnClickPro()
    {
        //Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(buttonProTower.transform.parent.position);
        GameObject towerObj = Instantiate(towerProPrefab, mousePoint, Quaternion.identity);
        buildButton.SetActive(false);

        //PlayerManager.Instance.SubtractMoney(5);
    }
    private void Update()
    {
        
    }
}
