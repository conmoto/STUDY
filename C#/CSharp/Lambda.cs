using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Lambda
    {
        //Inventory Item
        enum ItemType
        {
            Weapon,
            Armor,
            Ring
        }

        enum Rarity
        {
            Normal,
            Uncommon,
            Rare
        }

        class Item
        {
            public ItemType itemType;
            public Rarity rarity;
        }

        static List<Item> _items = new List<Item>();

        // v1. Find 종류에 따라 무수히 많은 함수들을 생성해야 하게 됨.
        static Item FindWeapon() 
        {
            foreach(Item item in _items)
            {
                if(item.itemType == ItemType.Weapon)
                    return item;
            }
            return null;
        }

        //  v2. delegate를 이용 but Select함수는 여전히 여러개 생성해야만 됨.
        delegate bool ItemSelector(Item item);    
        static bool IsWeapon(Item item) { return item.itemType == ItemType.Weapon;}
        static Item FindItem(ItemSelector selector) // => FindItem(IsWeapon)
        {
            foreach(Item item in _items)
            {
                if(selector(item))
                    return item;
            }
            return null;
        }

        // Generic Delegate
        // C# 내부에 이미 구현되어있다.
        // 반환이 있을 경우 Func
        // 반환이 void일 경우 Action
        delegate Return MyFunc<T, Return>(T item); // C# Func
        delegate void MyFunc<T>(T item); // C# Action
        static Item FindItemV2(MyFunc<Item, bool> selector)
        {
            foreach(Item item in _items)
            {
                if(selector(item))
                    return item;
            }
            return null;
        }


        static void Run()
        {
            _items.Add(new Item() { itemType = ItemType.Weapon, rarity = Rarity.Normal });
            _items.Add(new Item() { itemType = ItemType.Armor, rarity = Rarity.Uncommon });
            _items.Add(new Item() { itemType = ItemType.Ring, rarity = Rarity.Rare });
            
            // 공통적으로, 함수를 인자로 넘긴다는건 delegate가 사용되었다는 점은 같다.
            // v2. delegate
            Item item = FindItem(IsWeapon);

            // v3. Anonymous Function(익명 함수)
            // delegate (입력값) {반환값}
            item = FindItem(delegate (Item item) { return item.itemType == ItemType.Weapon;});
            // v4. Lambda : 일회용 함수를 만든다.
            // (입력값) => {반환값}
            item = FindItem((Item item) => {return item.itemType == ItemType.Weapon;});

            // Lambda를 delegate에 구독하면 재사용 가능하다.
            ItemSelector selector = new ItemSelector((Item item) => {return item.itemType == ItemType.Weapon;});
            item = FindItem(selector);

            // v5. Generic delegate를 이용한 Lambda
            MyFunc<Item, bool> selectorV2 = (Item item) => {return item.itemType == ItemType.Weapon;};
            //MyFunc<Item, bool> selectorV2 = new MyFunc<Item, bool>((Item item) => {return item.itemType == ItemType.Weapon;});
            
            // v6. C#에 구현되어 있는 delegate : Func / Action
            Func<Item, bool> selectorV3 = (Item item) => {return item.itemType == ItemType.Weapon;};
        }
    }
}
