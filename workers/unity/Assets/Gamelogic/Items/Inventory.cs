using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ItemCode;

public class Inventory : MonoBehaviour {

	public List<RealItem> InventoryItems = new List<RealItem>();
	public List<BaseItemClass> items = new List<BaseItemClass>();


	//public SOWeapon MainHand;
	//public SOWeapon Offhand;

	public SOItemDatabase itemList;
	// Use this for initialization
	void Start () {		

		// create a couple of items
		CraftingMaterial ironBar = new CraftingMaterial
		(
			ItemType.TradeGood,
			10,
			false,
			1,
			TradeGoodType.Iron | TradeGoodType.Ingot
		);

		//items.Add(ironBar);

		WeaponItemClass sword = new WeaponItemClass
		(
			WeaponType.Sword | WeaponType.OneHand, 
			10,
			1,
			true,
			new Dictionary<ItemStats, short>
			{
				{ItemStats.Durability, 100},
				{ItemStats.Damage, 150},
				{ItemStats.Strength, 10}
			}
		);

		//items.Add(sword);

		WeaponItemClass differentSword = new WeaponItemClass
		(
			WeaponType.Sword | WeaponType.TwoHand,
			10,
			30,
			false,
			new Dictionary<ItemStats, short>
			{
				{ItemStats.Durability, 100},
				{ItemStats.Damage, 100},
			}
		);

		//items.Add(differentSword);


		
		// Create a new item
		//RealItem newSword = itemList.LongSword;

		// Add the item to the inventory
		//InventoryItems.Add(newSword);

		//Debug.Log(itemList.LongSword.m_DamageType.ToString());
	}

	void AddInventoryToThis(Inventory otherInven)
	{
		InventoryItems.AddRange(otherInven.InventoryItems);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
