using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    
    private GameObject startPoint = null;

    [SerializeField] private GameObject contentLog;
    
    [SerializeField] private Text textLog;
    
    
    [Header("Wood Seller")] 
    [SerializeField] private float woodMoney = 500f;
    [SerializeField] private float woodUnits = 0f;
    [SerializeField] private float woodToolsCount = 10f;
    [SerializeField] private float woodFood = 100f;
    
    
    
    [SerializeField] private InputField woodMoneyF;
    [SerializeField] private InputField woodUnitsF;
    [SerializeField] private InputField woodToolsCountF;
    [SerializeField] private InputField woodFoodF;
    
    [Header("Iron Seller")]
    [SerializeField] private float ironMoney = 500f;
    [SerializeField] private float ironUnits = 0f;
    [SerializeField] private float ironToolsCount = 10f;
    [SerializeField] private float ironFood = 100f;
    
    [SerializeField] private InputField ironMoneyF;
    [SerializeField] private InputField ironUnitsF;
    [SerializeField] private InputField ironToolsCountF;
    [SerializeField] private InputField ironFoodF;
    
    [Header("Tools Seller")]
    [SerializeField] private float toolMoney = 500f;
    [SerializeField] private float toolUnits = 0f;
    [SerializeField] private float toolWoodCount = 50f;
    [SerializeField] private float toolIronCount = 50f;
    [SerializeField] private float toolFood = 100f;
    
    [SerializeField] private InputField toolMoneyF;
    [SerializeField] private InputField toolUnitsF;
    [SerializeField] private InputField toolWoodCountF;
    [SerializeField] private InputField toolIronCountF;
    [SerializeField] private InputField toolFoodF;
    
    [Header("Food Seller")]
    [SerializeField] private float foodMoney = 500f;
    [SerializeField] private float foodUnits = 0f;
    [SerializeField] private float foodSup = 100f;
    
    [SerializeField] private InputField foodMoneyF;
    [SerializeField] private InputField foodUnitsF;
    [SerializeField] private InputField foodSupF;
    
    [Header("Supplies Seller")]
    [SerializeField] private float supMoney = 500f;
    [SerializeField] private float supUnits = 0f;
    [SerializeField] private float supWoodCount = 100f;
    [SerializeField] private float supIronCount = 100f;
    
    [SerializeField] private InputField supMoneyF;
    [SerializeField] private InputField supUnitsF;
    [SerializeField] private InputField supWoodCountF;
    [SerializeField] private InputField supIronCountF;
   

    [Header("Prices")]
    [SerializeField] private float woodPrice = 25f;
    [SerializeField] private float ironPrice = 30f;
    [SerializeField] private float toolPrice = 35f;
    [SerializeField] private float foodPrice = 15f;
    [SerializeField] private float supPrice = 20f;
    
    [SerializeField] private InputField woodPriceF;
    [SerializeField] private InputField ironPriceF;
    [SerializeField] private InputField toolPriceF;
    [SerializeField] private InputField foodPriceF;
    [SerializeField] private InputField supPriceF;
    
    [Header("Time")]
    [SerializeField] private float woodCreatePeriod = 2f;
    private float nextWoodCreateTime = 0f;    
    
    [SerializeField] private float ironCreatePeriod = 3f;
    private float nextIronCreateTime = 0f;   
    
    [SerializeField] private float toolCreatePeriod = 5f;
    private float nextToolCreateTime = 0f;
    
    [SerializeField] private float foodSpendPeriod = 3f;
    private float nextFoodSpendTime = 0f;
    
    [SerializeField] private float supCreatePeriod = 5f;
    private float nextSupCreateTime = 0f;
    
    [SerializeField] private float foodCreatePeriod = 2f;
    private float nextFoodCreateTime = 0f;
    
    [SerializeField] private InputField woodCreatePeriodF;
    [SerializeField] private InputField ironCreatePeriodF;
    [SerializeField] private InputField toolCreatePeriodF;
    [SerializeField] private InputField foodSpendPeriodF;
    [SerializeField] private InputField supCreatePeriodF;
    [SerializeField] private InputField foodCreatePeriodF;
    
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (startPoint == null)
        {
            startPoint = GameObject.FindGameObjectWithTag("Start");
            woodMoney = Convert.ToSingle(woodMoneyF.text);
            woodUnits = Convert.ToSingle(woodUnitsF.text);
            woodToolsCount = Convert.ToSingle(woodToolsCountF.text);
            woodFood = Convert.ToSingle(woodFoodF.text);
        
            ironMoney = Convert.ToSingle(ironMoneyF.text);
            ironUnits = Convert.ToSingle(ironUnitsF.text);
            ironToolsCount = Convert.ToSingle(ironToolsCountF.text);
            ironFood = Convert.ToSingle(ironFoodF.text);
        
            toolMoney = Convert.ToSingle(toolMoneyF.text);
            toolUnits = Convert.ToSingle(toolUnitsF.text);
            toolWoodCount = Convert.ToSingle(toolWoodCountF.text);
            toolIronCount = Convert.ToSingle(toolIronCountF.text);
            toolFood = Convert.ToSingle(toolFoodF.text);
        
            foodMoney = Convert.ToSingle(foodMoneyF.text);
            foodUnits = Convert.ToSingle(foodUnitsF.text);
            foodSup = Convert.ToSingle(foodSupF.text);
        
            supMoney = Convert.ToSingle(supMoneyF.text);
            supUnits = Convert.ToSingle(supUnitsF.text);
            supWoodCount = Convert.ToSingle(supWoodCountF.text);
            supIronCount = Convert.ToSingle(supIronCountF.text);

            woodPrice = Convert.ToSingle(woodPriceF.text);
            ironPrice = Convert.ToSingle(ironPriceF.text);
            toolPrice = Convert.ToSingle(toolPriceF.text);
            foodPrice = Convert.ToSingle(foodPriceF.text);
            supPrice = Convert.ToSingle(supPriceF.text);

            woodCreatePeriod = Convert.ToSingle(woodCreatePeriodF.text);
            ironCreatePeriod = Convert.ToSingle(ironCreatePeriodF.text);
            toolCreatePeriod = Convert.ToSingle(toolCreatePeriodF.text);
            foodSpendPeriod = Convert.ToSingle(foodSpendPeriodF.text);
            supCreatePeriod = Convert.ToSingle(supCreatePeriodF.text);
            foodCreatePeriod = Convert.ToSingle(foodCreatePeriodF.text); 
        }
        else
        {
            CreateWood();
            CreateIron();
            CreateTool();
            CreateSup();
            CreateFood();
            BuyToolsForWood();
            BuyToolsForIron();
            BuyResForTool();
            BuySupForFood();
            BuyResForSup();
            BuyFood();
            SpendFood();
            
            woodMoneyF.text = woodMoney + "";
            woodUnitsF.text = woodUnitsF + "";
            woodToolsCountF.text = woodToolsCount + "";
            woodFoodF.text = woodFood + "";
            
            ironMoneyF.text = ironMoney + "";
            ironUnitsF.text = ironUnitsF + "";
            ironToolsCountF.text = ironToolsCount + "";
            ironFoodF.text = ironFood + "";
            
            toolMoneyF.text = toolMoney + "";
            toolUnitsF.text = toolUnitsF + "";
            toolWoodCountF.text = toolWoodCount + "";
            toolIronCountF.text = toolIronCount + "";
            toolFoodF.text = toolFood + "";
        
            foodMoneyF.text = foodMoney + "";
            foodUnitsF.text = foodUnits + "";
            foodSupF.text = foodSup + "";
        
            supMoneyF.text = supMoney + "";
            supUnitsF.text = supUnits + "";
            supWoodCountF.text = supWoodCount + "";
            supIronCountF.text = supIronCount + "";

            woodPriceF.text = woodPrice + "";
            ironPriceF.text = ironPrice + "";
            toolPriceF.text = toolPrice + "";
            foodPriceF.text = foodPrice + "";
            supPriceF.text = supPrice + "";

            woodCreatePeriodF.text = woodCreatePeriod + "";
            ironCreatePeriodF.text = ironCreatePeriod + "";
            toolCreatePeriodF.text = toolCreatePeriod + "";
            foodSpendPeriodF.text = foodSpendPeriod + "";
            supCreatePeriodF.text = supCreatePeriod + "";
            foodCreatePeriodF.text = foodCreatePeriod + "";
        }
        
    }

    #region CreateMethodsRegion
    private void CreateWood()
    {
        if (nextWoodCreateTime < Time.time && woodToolsCount > 0 && woodFood > 4 && woodUnits < 500)
        {        
            nextWoodCreateTime = Time.time + woodCreatePeriod;
            woodUnits += 100f;
            woodToolsCount--;
            textLog.text = "Create Wood " + woodUnits; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);    
        }
    }

    private void CreateIron()
    {
        if (nextIronCreateTime < Time.time && ironToolsCount > 0 && ironFood > 4 && ironUnits < 500)
        {
            nextIronCreateTime = Time.time + ironCreatePeriod;
            ironUnits += 100f;
            ironToolsCount--;
            textLog.text = "Create Iron " + ironUnits; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);  
        }
    }
    
    private void CreateTool()
    {
        if (nextToolCreateTime < Time.time && toolIronCount > 0 && toolWoodCount > 0 && toolFood > 4 && toolUnits < 10)
        {  
            nextToolCreateTime = Time.time + toolCreatePeriod;
            toolUnits += 4;
            toolIronCount -= 10;
            toolWoodCount -= 10;
            textLog.text = "Create Tool " + toolUnits; 
            Instantiate(textLog).transform.SetParent(contentLog.transform); 
        }
    }

    private void CreateSup()
    {
        if (nextSupCreateTime < Time.time && supWoodCount >= 20 && supIronCount >= 20 && supUnits < 1000)
        {
            nextSupCreateTime = Time.time + supCreatePeriod;
            supUnits += 100;
            supWoodCount -= 10;
            supIronCount -= 10;
            textLog.text = "Create Sup " + supUnits; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);  
        }
    }
    
    private void CreateFood()
    {
        if (nextFoodCreateTime < Time.time && foodSup >= 50 && foodUnits < 300)
        {
            nextFoodCreateTime = Time.time + foodCreatePeriod;
            foodUnits += 50;
            foodSup -= 50;
            textLog.text = "Create Food " + foodUnits; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);  
        }
    }
    #endregion

    #region BuyMethodsRegion
    private void BuyToolsForWood()
    {
        if (woodToolsCount < 2 && toolUnits > 5 && woodMoney > toolPrice)
        {
            woodToolsCount += 5;
            toolUnits -= 5;
            toolMoney += toolPrice;
            woodMoney -= toolPrice;
            textLog.text = "BuyToolsForWood " + woodToolsCount; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);  
        }
    }
    
    private void BuyToolsForIron()
    {
        if (ironToolsCount < 2 && toolUnits > 5 && ironMoney > toolPrice)
        {
            ironToolsCount += 5;
            toolUnits -= 5;
            toolMoney += toolPrice;
            ironMoney -= toolPrice;
            textLog.text = "BuyToolsForIron " + ironToolsCount; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);  
        }
    }
    
    private void BuyResForTool()
    {
        if (toolIronCount < 1 && toolWoodCount < 1 && ironUnits > 1 && woodUnits > 1 && toolMoney > (woodPrice + ironPrice))
        {
            ironUnits -= 10;
            woodUnits -= 10;
            toolIronCount += 10;
            toolWoodCount += 10;
            toolMoney -= (woodPrice + ironPrice);
            woodMoney += woodPrice;
            ironMoney += ironPrice;
            textLog.text = "BuyResForTool " + toolIronCount; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);  
        }
    }

    private void BuySupForFood()
    {
        if (foodSup < 1 && foodMoney > supPrice && supUnits > 49)
        {
            foodSup += 50;
            foodMoney -= supPrice;
            supUnits -= 50;
            supMoney += supPrice;
            textLog.text = "BuyResForFood " + foodSup; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);
        }
    }
    
    private void BuyResForSup()
    {
        if (supIronCount < 50 && supWoodCount < 50 && ironUnits > 50 && woodUnits > 50 && supMoney > (woodPrice + ironPrice))
        {
            ironUnits -= 50;
            woodUnits -= 50;
            supIronCount += 50;
            supWoodCount += 50;
            supMoney -= (woodPrice + ironPrice);
            woodMoney += woodPrice;
            ironMoney += ironPrice;
            textLog.text = "BuyResForSup " + supIronCount; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);
        }
    }

    private void BuyFood()
    {
        if (woodFood < 1 && foodUnits > 49 && woodMoney > 10)
        {
            woodFood += 50;
            foodUnits -= 50;
            woodMoney -= foodPrice;
            foodMoney += foodPrice;
            textLog.text = "BuyFoodWood " + woodFood; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);
        }
        
        if (ironFood < 1 && foodUnits > 49 && ironMoney > 10)
        {
            ironFood += 50;
            foodUnits -= 50;
            ironMoney -= foodPrice;
            foodMoney += foodPrice;
            textLog.text = "BuyFoodIron " + ironFood; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);
        }
        
        if (toolFood < 1 && foodUnits > 49 && toolMoney > 10)
        {
            toolFood += 50;
            foodUnits -= 50;
            toolMoney -= foodPrice;
            foodMoney += foodPrice;
            textLog.text = "BuyFoodTool " + toolFood; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);
        }
    }
    #endregion

    private void SpendFood()
    {
        if (nextFoodSpendTime < Time.time)
        {
            nextFoodSpendTime = Time.time + foodSpendPeriod;
            if (woodFood > 4) woodFood -= 5;
            if (ironFood > 4) ironFood -= 5;
            if (toolFood > 4) toolFood -= 5;          
            textLog.text = "SpendFood " + woodFood; 
            Instantiate(textLog).transform.SetParent(contentLog.transform);
        } 
    }
}
