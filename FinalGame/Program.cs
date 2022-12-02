Random gen = new Random(); // random generator to tell how much money you dug up

string MinDir; //Mining Direction
string DC = ""; //Diggin Choise
string MinStat; //Mine Status
string Pos = "Mine"; //Position in game
string BuyNI;//Buy New Item
string game = "ON"; //used for game while loop
string CBls; //Check Balance

int MonMin1 = 0; //Money per Mined (how much money you earned when you hit 'dig')
int CASH = 0; //your balance
int power = 2; //your power level
int eff = 1; //the effect that your magic upgrades have on your tool

bool Ni1 = true; //New Items 1 (unlocks the next part of the store)
bool mgc = false; //Magic (unlocks the magicians house to upgrade tools)

Store store = new Store();//connects store tab to main tab
tut tut = new tut(); //connects tutorial tab with main tab
MagicStore magic = new MagicStore();

List<Item> owned = new List<Item>(); //the list of owned tools
List<Magic> ownedM = new List<Magic>();//the list of owned magic upgrades


owned.Add(new Item { name = "hands", power = 2 }); //Starting Item

tut.intro(); //Asks for name and explain shortly what to do

System.Console.WriteLine("now that you are in your mine you will have 3 direction to mine, so start by writing which direction you want to go by typing in 'Right', 'Left' or 'Straight'");//these are part of the tutorial
MinDir = Console.ReadLine();
while (game == "ON") //while loop to be able to get to the start after leaving the shop
{
    while (Pos == "Mine") // while loop for when you are in the mine
    {
        Console.WriteLine("You are now in your mine!");
        while (!(MinDir == "Right" || MinDir == "right" || MinDir == "Left" || MinDir == "left" || MinDir == "Straight" || MinDir == "straight"))//as long as you haven't chosen any direction you will be asked to do so
        {
            System.Console.WriteLine("Please enter a valid direction!");
            System.Console.WriteLine("Would you like to go Right, Left or Straight?");
            MinDir = Console.ReadLine();
        }
        int CuIt = -1;
        int CuEn = -1;
        foreach (Item V in owned) // to choose the last Item in your 'owned list' to use while mining
        {
            CuIt++;
        }
        foreach (Magic mg in ownedM)// to choose the last enchantment in your owned enchantments list
        {
            CuEn++;
        }
        while (MinDir == "Right" || MinDir == "right" || MinDir == "Left" || MinDir == "left" || MinDir == "Straight" || MinDir == "straight") //while loop for when you want to stay in your location or change location to dig
        {
            if (!(DC == "Dig" || DC == "dig" || DC == "Exit" || DC == "exit"))//if you have not chosen to dig yet, you will be asked if you want to check your balance and then if you want to start digging
            {
                Console.WriteLine("would you like to check your balance please type 'Check'");
                CBls = Console.ReadLine();
                if (CBls == "Check" || CBls == "check")
                {
                    Console.WriteLine($"you currently have ${CASH}, press enter to continue!");
                    Console.ReadLine();
                }
                if (eff < 2){
                System.Console.WriteLine($"Dig with your {owned[CuIt].name} that has {owned[CuIt].power} in power level? If so, please write 'Dig'");
                DC = Console.ReadLine();
                }else {
                    Console.WriteLine($"Dig with your {owned[CuIt].name} that has {owned[CuIt].power} in power level and is enchanted with {ownedM[CuEn].desc}? if so, please write 'Dig'");
                    DC = Console.ReadLine();
                }
            }
            if (!(DC == "Dig" || DC == "dig" || DC == "Exit" || DC == "exit")) //gives second chance if you did not give a valid answer
            {
                Console.WriteLine("Please write 'Dig' if you wish to dig, if you wish to leave please write 'Exit'");
                DC = Console.ReadLine();
            }

            while (DC == "Dig" || DC == "dig") //while loop for when you are digging so you can dig multiple times
            {
                if (power < 5) //if-statement to chose how much is possible for you to dig up based on the power of your item
                {
                    MonMin1 = gen.Next(16);
                }
                else if (power < 11 && power > 5)
                {
                    MonMin1 = gen.Next(21);
                }
                else if (power > 10 && power < 20)
                {
                    MonMin1 = gen.Next(41);
                }
                else if (power > 20)
                {
                    MonMin1 = gen.Next(61);
                }
                if (eff > 1){
                Console.WriteLine($"You dug up {MonMin1} but with your enchant you dug up {MonMin1*eff}!");
                    MonMin1 *= eff;//uses the enchantment effect to mine more
                }else{
                System.Console.WriteLine($"You dug up {MonMin1}!");
                }
                CASH += MonMin1; // adding what you dug up to your balance
                System.Console.WriteLine($"You now have ${CASH}!");
                if (Ni1) // if-statement to unlock new items in the shop
                {
                    if (CASH > 30)
                    {
                        Console.WriteLine($"Congrats! You have now unlocked new content in the shop!");
                        Ni1 = false;
                    }
                }
                if (mgc == false)//if-statement to unlock the magicians house
                {
                    if(CASH > 200)
                    {
                        Console.WriteLine("Congrats! You have now unlocked the Magicians house! Leave the mine to enter his house");
                    mgc = true;
                    }
                }
                System.Console.WriteLine("If you would like to dig again type 'Dig', if not, type 'Exit'");
                DC = Console.ReadLine();
            }
            if (DC == "Exit" || DC == "exit")
            {
                System.Console.WriteLine("You are now back to the start of the mine. Would you like to go another direction, please type 'Right', 'Left' or 'Straight. If you would like to leave please type 'Leave'");
                MinStat = Console.ReadLine();

                if (MinStat == "Leave" || MinStat == "leave") // if player chose to leave, position will change to 'Out' and Mining Direction will change to blank so when they go back to the mine they wont start in a certain direction without having a choice
                {
                    Pos = "out";
                    MinDir = "";
                }
            }
            while (!(DC == "Dig" || DC == "dig" || DC == "Exit" || DC == "exit")) //if player answered invalid they will be asked again until they give a valid answer
            {
                Console.WriteLine("please enter a valid answer, either 'Dig' or 'Exit'");
                DC = Console.ReadLine();
            }
        }
    }

    while (Pos == "out" || Pos == "Out") //while loop for if the player tries to write something invalid they will start over
    {
        DC = ""; //changing Digging Choice so when they re-enter the mine they wont be imediatly sent back out again
        Console.WriteLine("You are now outside!");
        if(mgc == false){
        System.Console.WriteLine("Would you like to go to the shop, then please type 'Shop', or would you like to enter the mine again, then please type 'Mine'");
        string OutMove = Console.ReadLine(); //'OutMove' is the string to decide where the player diceded to move while being 'Out'
        if (OutMove == "Mine" || OutMove == "mine") //if player answered 'Mine' Position will be changed to 'Mine' 
        {
            Pos = "Mine";
        }
        else if (OutMove == "Shop" || OutMove == "shop")//if player answered 'Shop' Position will be changed to 'Shop'
        {
            Pos = "Shop";
        }
        else // if player answered invalid they will be asked to give a valid answer and they will then be asked again
        {
            Console.WriteLine("Please enter a valid option!");
        }
        }else{
            System.Console.WriteLine("Would you like to go to the shop, then please type 'Shop', if you would like to go to the magician and upgrade your current tool type 'Magic' or would you like to enter the mine again, then please type 'Mine'");
            string OutMove = Console.ReadLine();
             if (OutMove == "Mine" || OutMove == "mine") //if player answered 'Mine' Position will be changed to 'Mine' 
        {
            Pos = "Mine";
        }
        else if (OutMove == "Shop" || OutMove == "shop")//if player answered 'Shop' Position will be changed to 'Shop'
        {
            Pos = "Shop";
        }
        else if(OutMove == "Magic" || OutMove == "magic"){//if player answered 'Magic' position will be changed to 'Magic'
            Pos = "Magic";
        }
        else // if player answered invalid they will be asked to give a valid answer and they will then be asked again
        {
            Console.WriteLine("Please enter a valid option!");
        }
            
        }
    }

    while (Pos == "Shop") //while loop for when you are in the store in case the player tries to break out
    {
        Console.WriteLine("Welcome to the store!");
        int u = 0; //'u' is for calculating which item was bought
        int l = 1; //'l' is the number the item is given when listed in the store
        int LiNu = 0; //'LiNu' stands for List Number and is used to decide which item on the list to print out
        foreach (Item it in store.tool)//foreach loop to print the first 3 store items
        {
            if (LiNu < 3) // making sure only the first 3 items are printed incase all items havent been unlocked yet
            {
                Console.WriteLine($"{l}.{store.tool[LiNu].name}, price: ${store.tool[LiNu].price}, power: {store.tool[LiNu].power}");
                l++;
                LiNu++;
            }
        }

        if (Ni1 == false) // asking if second part of store is unlocked
        {
            int WrIt = 3; //'WrIt' stands for Write Item which has the same function as 'LiNu'
            foreach (Item it in store.tool)//foreach loop to print the next 3 store items
            {
                if (WrIt < 6) //making sure only the second part of the list is printed incase the next part isn't unlocked yet
                {
                    Console.WriteLine($"{l}.{store.tool[WrIt].name}, price: ${store.tool[WrIt].price}, power: {store.tool[WrIt].power}");
                    WrIt++;
                    l++;
                }
            }
        }
        System.Console.WriteLine("What would you like to buy? please enter a number! If you wish to leave please type 'Back'");
        BuyNI = Console.ReadLine();
        if (BuyNI == "Back" || BuyNI == "back") //if nothing is wished to be bought player is able to leave with this fucntion
        {
            Pos = "out";
        }
        int.TryParse(BuyNI, out u); //try to translate the answer of which item to buy into an integer

        if (u > 0 && u <= l) //used to see if the answer was valid
        {
            u -= 1; //since list items start at 0, the listed number is one higher and so u-1 is necessary 
            CASH -= store.tool[u].price; // reduce price from your balance
            if (CASH >= 0) //checking if you can afford this item or if you went negative in your balance
            {
                owned.Add(new Item { name = store.tool[u].name, power = store.tool[u].power }); //adding the item to your inventory
                Console.WriteLine($"You bought a {store.tool[u].name}, your balance is now ${CASH}");
                Pos = "out"; //if sucessfully bought you will be placed outside again
                power = store.tool[u].power; //upgrading your power to the item power that you bought
            }
            else
            {
                CASH += store.tool[u].price; //adding back the money that was taken from you if you couldn't afford
                Console.WriteLine($"That item is too expensive for you, you only have ${CASH}");
            }
        }
        else if (!(u > 0 && u <= l || BuyNI == "Back" || BuyNI == "back")) //if the question of wether you wanted to buy something or if you wanted to leave was answered incorectly you will be asked to give a valid choice and store will then restart
        {
            Console.WriteLine("Please enter a valid choice!");
        }
    }

    while (Pos == "Magic"){
         Console.WriteLine("Welcome to the enchantment store!");
        int u = 0; //'u' is for calculating which item was bought
        int l = 1; //'l' is the number the item is given when listed in the store
        int LiNu = 0; //'LiNu' stands for List Number and is used to decide which item on the list to print out
        foreach (Magic it in magic.tool)//foreach loop to print the first 3 store items
        {
                Console.WriteLine($"{l}.{magic.tool[LiNu].name}, price: ${magic.tool[LiNu].price}, power: {magic.tool[LiNu].desc}");
                l++;
                LiNu++;
        }
        System.Console.WriteLine("What would you like to buy? please enter a number! If you wish to leave please type 'Back'");
        BuyNI = Console.ReadLine();
        if (BuyNI == "Back" || BuyNI == "back") //if nothing is wished to be bought player is able to leave with this fucntion
        {
            Pos = "out";
        }
        int.TryParse(BuyNI, out u); //try to translate the answer of which item to buy into an integer

        if (u > 0 && u <= l) //used to see if the answer was valid
        {
            u -= 1; //since list items start at 0, the listed number is one higher and so u-1 is necessary 
            CASH -= magic.tool[u].price; // reduce price from your balance
            if (CASH >= 0) //checking if you can afford this item or if you went negative in your balance
            {
                ownedM.Add(new Magic{name = magic.tool[u].name, effect = magic.tool[u].effect, desc = magic.tool[u].desc}); //adding the item to your inventory
                Console.WriteLine($"You bought {magic.tool[u].name}, your balance is now ${CASH}");
                Pos = "out"; //if sucessfully bought you will be placed outside again
                eff = magic.tool[u].effect; //upgrading your power to the item power that you bought
            }
            else
            {
                CASH += store.tool[u].price; //adding back the money that was taken from you if you couldn't afford
                Console.WriteLine($"That item is too expensive for you, you only have ${CASH}");
            }
        }
        else if (!(u > 0 && u <= l || BuyNI == "Back" || BuyNI == "back")) //if the question of wether you wanted to buy something or if you wanted to leave was answered incorectly you will be asked to give a valid choice and store will then restart
        {
            Console.WriteLine("Please enter a valid choice!");
        }
    }
}




Console.ReadLine();