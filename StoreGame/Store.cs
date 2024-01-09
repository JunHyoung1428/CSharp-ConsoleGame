using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StoreGame
{
    class Store
    {
        Item[] storeItem;

        public  Store()
        {
            storeItem = new Item[3];
            storeItem[0] = new Item("롱소드", "기본적인 검이다.", 450, 0, 0, 15);
            storeItem[1] = new Item("천갑옷", "얇은 갑옷이다", 450, 0, 15, 0);
            storeItem[2] = new Item("여신의 눈물", "희미하게 푸른빛을 품고 있는 보석이다.", 800, 300, 0, 0);
        }


        public void StoreMenu(Player player)
        {
            Console.WriteLine("\n======== 상점 메뉴 ========");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("3. 아이템 확인");


            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("메뉴를 선택하세요.");
                key = Console.ReadKey();
            } while (key.KeyChar != '1' && key.KeyChar != '2' && key.KeyChar != '3');
            switch (key.KeyChar)
            {
                case '1':
                    ItemBuy(player);
                    break;
                case '2':
                    ItemSell(player);
                    break;
                case '3':
                    ItemConfirm(player);
                    break;
            }
            
        }

        public void ItemBuy(Player player)
        {
            Console.Clear();
            Console.WriteLine("======== 아이템 구매 ========");
            
            for(int i = 0; i < storeItem.Length; i++)
            {
                Console.Write($"\n{i+1}. ");
                storeItem[i].ShowItem();
            }

            Console.WriteLine("\n구매할 아이템을 선택하세요 (취소 0) : ");
            ConsoleKeyInfo key;
            key=Console.ReadKey();
            int index = int.Parse(key.KeyChar.ToString())-1;

            if (key.KeyChar =='0' || index >= storeItem.Length)
            {
                return;
            }

            Console.WriteLine($"\n{storeItem[index].itemName}을/를 구매합니다.");
            if(player.inventory.Count >= 6)
            {
                Console.WriteLine("가방이 다 차 더 이상 아이템을 구매 할 수 없습니다.");
                return;
            }
            player.inventory.Add(storeItem[index]);

            if (storeItem[index].armor != 0)
            {   player.Armor += storeItem[index].armor;
                Console.WriteLine($"플레이어의 방어력이 {storeItem[index].armor} 상승하여 {player.Armor}가 됩니다.");
            }
            else if (storeItem[index].damage != 0)
            {
                player.Damage += storeItem[index].damage;
                Console.WriteLine($"플레이어의 공격력이 {storeItem[index].damage} 상승하여 {player.Damage}가 됩니다.");
            }
            else if (storeItem[index].health != 0)
            { 
                player.Health += storeItem[index].health;
                Console.WriteLine($"플레이어의 체력이 {storeItem[index].health} 상승하여 {player.Health}가 됩니다.");
            }
            player.Gold -= storeItem[index].price;
            Console.WriteLine($"보유한 골드가 {storeItem[index].price}G 감소하여 {player.Gold}가 됩니다.");
        }

        public void ItemSell(Player player)
        {
            Console.Clear();
            Console.WriteLine("======== 아이템 판매 ========");

            player.ShowPlayerItem();
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            int index = int.Parse(key.KeyChar.ToString()) - 1;

            if (key.KeyChar == '0' || index >= player.inventory.Count)
            {
                return;
            }

            Console.WriteLine($"\n{player.inventory[index].itemName}을/를 판매합니다.");
            
            if (player.inventory[index].armor != 0)
            {
                player.Armor -= player.inventory[index].armor;
                Console.WriteLine($"플레이어의 방어력이 {player.inventory[index].armor} 감소하여 {player.Armor}가 됩니다.");
            }
            else if (player.inventory[index].damage != 0)
            {
                player.Damage -= player.inventory[index].damage;
                Console.WriteLine($"플레이어의 공격력이 {player.inventory[index].damage} 감소하여 {player.Damage}가 됩니다.");
            }
            else if (player.inventory[index].health != 0)
            {
                player.Health -= player.inventory[index].health;
                Console.WriteLine($"플레이어의 체력이 {player.inventory[index].health} 감소하여 {player.Health}가 됩니다.");
            }
            player.Gold += player.inventory[index].price;
            Console.WriteLine($"보유한 골드가 {player.inventory[index].price}G 증가 {player.Gold}가 됩니다.");
            player.inventory.RemoveAt(index);

        }

        public void ItemConfirm(Player player)
        {
            Console.Clear();
            Console.WriteLine("\n======== 아이템 확인 ========");
            Console.WriteLine($"플레이어   골드 보유량 : {player.Gold}");
            Console.WriteLine($"플레이어 공격력 상승량 : {player.Damage}");
            Console.WriteLine($"플레이어 방어력 상승량 : {player.Armor}");
            Console.WriteLine($"플레이어   체력 상승량 : {player.Health}");

            player.ShowPlayerItem();

            Console.WriteLine("\n계속하려면 아무키나 입력하세요:");
            Console.ReadKey();
        }

       
    }
}
