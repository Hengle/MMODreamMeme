using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;

//using ItemDatabase;
using ItemCode;

[CreateAssetMenu(menuName = "Items/ItemDatabase")]
public class SOItemDatabase : ScriptableObject
{
    // Trade goods?
 
    

    public void InitItems()
    {
    }

    void OnEnable()
    {
    }

    void InitAndBenchmarkItems()
    {
        Stopwatch myStopwatch = new Stopwatch();
        int count = 3000000;

        BaseItemClass myItemTestClass = new BaseItemClass();

        myStopwatch.Start();


        for (int i = 0; i < count; i++)
        {
            // RealItem newItem = new RealItem
            // (
            // 	ItemType.Weapon | ItemType.OneHanded | ItemType.TwoHand,
            // 	100,
            // 	1,
            // 	new IAPair[]
            // 	{
            // 		new IAPair(ItemModifiers.Damage, 10),
            // 		new IAPair(ItemModifiers.Durability, 100),
            // 	}
            // );
            //ItemTestClass newclass = new ItemTestClass();
            //ChildClass childClass = new ChildClass();
            
			// Weapon testing class
			// WeaponItemClass shortSword = new WeaponItemClass
			// (
            //     WeaponType.OneHand | WeaponType.PoleArm,
            //     13,
            // 	true,
			// 	new Dictionary<ItemModifiers, short>
			// 	{
			// 		{ItemModifiers.Durability, 100},
			// 		{ItemModifiers.Weight, 150}
			// 	}	
            // );

			// Weapon testing class light
			//WeaponItemClass longSword = new WeaponItemClass(WeaponType.Bow | WeaponType.Axe, 10);
			//CraftingMaterial IronIngot = new CraftingMaterial(ItemType.TradeGood, TradeGoodType.Ingot | TradeGoodType.Iron);
        }

        myStopwatch.Stop();
        UnityEngine.Debug.Log(myStopwatch.Elapsed);
    }
}


// DELETE ME THIS IS ONLY A TEST

