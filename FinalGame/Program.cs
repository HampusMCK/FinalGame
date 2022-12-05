Random gen = new Random(); // random generator to tell how much money you dug up

string MinDir; //Mining Direction
string DC = ""; //Diggin Choise
string MinStat; //Mine Status
string Pos = "Mine"; //Position in game
string BuyNI;//Buy New Item
string CBls; //Check Balance

int game = 1; //used for game while loop
int MonMin1 = 0; //Money per Mined (how much money you earned when you hit 'dig')
int CASH = 0; //your balance
int power = 2; //your power level
int eff = 1; //the effect that your magic upgrades have on your tool

bool Ni1 = true; //New Items 1 (unlocks the next part of the store)
bool mgc = false; //Magic (unlocks the magicians house to upgrade tools)
bool NLU = false; //Next Level Unlocked? (unlocks the next level)

Store store = new Store();//connects store tab to main tab
tut tut = new tut(); //connects tutorial tab with main tab
MagicStore magic = new MagicStore();
MineTime MFunc = new MineTime();

List<Item> owned = new List<Item>(); //the list of owned tools
List<Magic> ownedM = new List<Magic>();//the list of owned magic upgrades


owned.Add(new Item { name = "hands", power = 2 }); //Starting Item

tut.intro(); //Asks for name and explain shortly what to do

System.Console.WriteLine("now that you are in your mine you will have 3 direction to mine, so start by writing which direction you want to go by typing in 'Right', 'Left' or 'Straight'");//these are part of the tutorial
MinDir = Console.ReadLine();
while (game == 1) //while loop to be able to get to the start after leaving the shop
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
                MFunc.MTime();//writes 'mining..' while mining
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
                if (CASH >= 1000){
                    Console.WriteLine("Wow! You have unlocked a new level! Go outside to get to the next level!");
                    NLU = true;
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
                }else if (MinStat == "Right" || MinStat == "right" || MinStat == "Left" || MinStat == "left" || MinStat == "Straight" || MinStat == "straight"){
                    DC = "";
                    MinDir = "Right";
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
        if (NLU == false){
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
        else{
            Console.WriteLine("Congratulations on making it to the next level! Let me show you around!");
            Console.WriteLine("");
            Console.WriteLine("in here there is also a shop with unlockable items ans different stores that may be unlocked later");
            Console.WriteLine("");
            Console.WriteLine("Here you will also have more than one mine to choose from and more mines will be unlocked along the way, and to earn money you will have to sell what you mine first! You will start with $300");
            game = 2;
            Pos = "";
            DC = "";
            MinDir = "";
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




//Level 2 variables------------------------------------------------------------------------
float gold = 0;
float diamond = 0;
float iron = 0;
float silver = 0;
float copper = 0;

float GWorth = 57.8f;
float DWorth = 120;
float IWorth = 0.000087f;
float SWorth = 0.74f;
float CWorth = 0.00822f;

float Cash = 300;

int Gdugup = 0;
int Ddugup = 0;
int Idugup = 0;
int Sdugup = 0;
int Cdugup = 0;

string poss = "Out";
string MC;

MineList mlist = new MineList();

while (game == 2){
    while (poss == "Out"){
        Console.WriteLine("You are now outside!");
            int cm = 0;
        foreach (LVL2Mines ml in mlist.mines){
            Console.WriteLine($"Would you like to enter '{mlist.mines[cm].name}'? Or..");
            cm++;
        }
        Console.WriteLine("Would you like to enter the shop?");
        MC = Console.ReadLine();
        if (MC == "shop" || MC == "Shop"){
            poss = MC;
        }else {
                cm = 0;
            foreach (LVL2Mines ml in mlist.mines){
                if (MC == mlist.mines[cm].name){
                    poss = MC;
                }
                cm++;
            }
        }
        if (!(poss == MC)){
            Console.WriteLine("Please enter a valid answer");
            poss = "Out";
        }
    }
   
   while (poss == "mine"){
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
        Console.WriteLine($"You are now in your 'mine' if you want to dig with your {owned[CuIt].name} that has {owned[CuIt].power} in power level and is enchanted with {ownedM[CuEn].desc}? if so, please write 'Dig'");
        DC = Console.ReadLine();
        while (DC == "Dig" || DC == "dig"){
             MFunc.MTime();//writes 'mining..' while mining
                if (owned[CuIt].power < 5) //if-statement to chose how much is possible for you to dig up based on the power of your item
                {
                    Idugup = gen.Next(16);
                }
                else if (owned[CuIt].power < 11 && owned[CuIt].power > 5)
                {
                    Idugup = gen.Next(21);
                    Cdugup = gen.Next(11);
                }
                else if (owned[CuIt].power > 10 && owned[CuIt].power < 20)
                {
                    Idugup = gen.Next(41);
                    Cdugup = gen.Next(21);
                }
                else if (owned[CuIt].power > 20 && owned[CuIt].power < 101)
                {
                    Idugup = gen.Next(61);
                    Cdugup = gen.Next(31);
                }
                if (eff > 1){
                Console.WriteLine($"You dug up {Idugup} iron and {Cdugup} copper but with your enchant you dug up {Idugup*eff} iron and {Cdugup*eff} copper!");
                    Idugup *= eff;//uses the enchantment effect to mine more
                    Cdugup *= eff;
                }else{
                System.Console.WriteLine($"You dug up {Idugup} iron and {Cdugup} copper!");
                }
                iron += Idugup; // adding what you dug up to your balance
                copper += Cdugup;
                System.Console.WriteLine($"You now have {iron} grams of iron and {copper} grams of copper!");
                Console.WriteLine("Would you like to dig again please wirte 'Dig' otherwise write 'Exit'");
                DC = Console.ReadLine();
                if (DC == "Exit" || DC == "exit"){
                    poss = "Out";
                }
        }
   }
   while (poss == "copper mine"){
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
        Console.WriteLine($"You are now in your 'copper mine' if you want to dig with your {owned[CuIt].name} that has {owned[CuIt].power} in power level and is enchanted with {ownedM[CuEn].desc}? if so, please write 'Dig'");
        DC = Console.ReadLine();
        while (DC == "Dig" || DC == "dig"){
             MFunc.MTime();//writes 'mining..' while mining
                if (owned[CuIt].power < 5) //if-statement to chose how much is possible for you to dig up based on the power of your item
                {
                    Idugup = gen.Next(26);
                    Cdugup = gen.Next(16);
                    Sdugup = gen.Next(6);
                }
                else if (owned[CuIt].power < 11 && owned[CuIt].power > 5)
                {
                    Idugup = gen.Next(31);
                    Cdugup = gen.Next(21);
                    Sdugup = gen.Next(11);
                }
                else if (owned[CuIt].power > 10 && owned[CuIt].power < 20)
                {
                    Idugup = gen.Next(41);
                    Cdugup = gen.Next(31);
                    Sdugup = gen.Next(21);
                }
                else if (owned[CuIt].power > 20)
                {
                    Idugup = gen.Next(61);
                    Cdugup = gen.Next(41);
                    Sdugup = gen.Next(26);
                }
                if (eff > 1){
                Console.WriteLine($"You dug up {Idugup} iron and {Cdugup} copper and {Sdugup} silver but with your enchant you dug up {Idugup*eff} iron and {Cdugup*eff} copper and {Sdugup*eff} silver!");
                    Idugup *= eff;//uses the enchantment effect to mine more
                    Cdugup *= eff;
                    Sdugup *= eff;
                }else{
                System.Console.WriteLine($"You dug up {Idugup} iron and {Cdugup} copper nad Sdugup silver!");
                }
                iron += Idugup; // adding what you dug up to your balance
                copper += Cdugup;
                silver += Sdugup;
                System.Console.WriteLine($"You now have {iron} grams of iron and {copper} grams of copper and {silver} grams of silver!");
                Console.WriteLine("Would you like to dig again please wirte 'Dig' otherwise write 'Exit'");
                DC = Console.ReadLine();
                if (DC == "Exit" || DC == "exit"){
                    poss = "Out";
                }
        }
   }
   while (poss == "silver mine"){
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
        Console.WriteLine($"You are now in your 'silver mine' if you want to dig with your {owned[CuIt].name} that has {owned[CuIt].power} in power level and is enchanted with {ownedM[CuEn].desc}? if so, please write 'Dig'");
        DC = Console.ReadLine();
        while (DC == "Dig" || DC == "dig"){
             MFunc.MTime();//writes 'mining..' while mining
                if (owned[CuIt].power < 5) //if-statement to chose how much is possible for you to dig up based on the power of your item
                {
                    Cdugup = gen.Next(26);
                    Sdugup = gen.Next(16);
                    Gdugup = gen.Next(6);
                }
                else if (owned[CuIt].power < 11 && owned[CuIt].power > 5)
                {
                  Cdugup = gen.Next(36);
                    Sdugup = gen.Next(26);
                    Gdugup = gen.Next(16);
                }
                else if (owned[CuIt].power > 10 && owned[CuIt].power < 20)
                {
                    Cdugup = gen.Next(46);
                    Sdugup = gen.Next(36);
                    Gdugup = gen.Next(26);
                }
                else if (owned[CuIt].power > 20)
                {
                   Cdugup = gen.Next(56);
                    Sdugup = gen.Next(36);
                    Gdugup = gen.Next(26);
                }
                if (eff > 1){
                Console.WriteLine($"You dug up {Cdugup} copper and {Sdugup} silver and {Gdugup} gold but with your enchant you dug up {Cdugup*eff} copper and {Sdugup*eff} silver and {Gdugup*eff} gold!");
                    Cdugup *= eff;//uses the enchantment effect to mine more
                    Sdugup *= eff;
                    Gdugup *= eff;
                }else{
                System.Console.WriteLine($"You dug up {Cdugup} copper and {Sdugup} silver and {Gdugup}!");
                }
                silver += Sdugup; // adding what you dug up to your balance
                copper += Cdugup;
                gold += Gdugup;
                System.Console.WriteLine($"You now have {copper} grams of copper and {silver} grams of silver and {gold} grams of gold!");
                Console.WriteLine("Would you like to dig again please wirte 'Dig' otherwise write 'Exit'");
                DC = Console.ReadLine();
                if (DC == "Exit" || DC == "exit"){
                    poss = "Out";
                }
        }
   }
   while (poss == "gold mine"){
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
        Console.WriteLine($"You are now in your 'gold mine' if you want to dig with your {owned[CuIt].name} that has {owned[CuIt].power} in power level and is enchanted with {ownedM[CuEn].desc}? if so, please write 'Dig'");
        DC = Console.ReadLine();
        while (DC == "Dig" || DC == "dig"){
             MFunc.MTime();//writes 'mining..' while mining
                if (owned[CuIt].power < 5) //if-statement to chose how much is possible for you to dig up based on the power of your item
                {
                     Sdugup = gen.Next(26);
                    Gdugup = gen.Next(16);
                    Ddugup = gen.Next(6);
                }
                else if (owned[CuIt].power < 11 && owned[CuIt].power > 5)
                {
                   Sdugup = gen.Next(36);
                    Gdugup = gen.Next(26);
                    Ddugup = gen.Next(16);
                }
                else if (owned[CuIt].power > 10 && owned[CuIt].power < 20)
                {
                    Sdugup = gen.Next(46);
                    Gdugup = gen.Next(36);
                    Ddugup = gen.Next(26);
                }
                else if (owned[CuIt].power > 20)
                {
                    Sdugup = gen.Next(56);
                    Gdugup = gen.Next(46);
                    Ddugup = gen.Next(36);
                }
                if (eff > 1){
                Console.WriteLine($"You dug up {Sdugup} silver and {Gdugup} gold and {Ddugup} diamond but with your enchant you dug up {Sdugup*eff} silver and {Gdugup*eff} gold and {Ddugup*eff} diamond!");
                    Sdugup *= eff;//uses the enchantment effect to mine more
                    Gdugup *= eff;
                    Ddugup *= eff;
                }else{
                System.Console.WriteLine($"You dug up {Sdugup} silver and {Gdugup} gold and {Ddugup} diamond!");
                }
                silver += Sdugup; // adding what you dug up to your balance
                gold += Gdugup;
                diamond += Ddugup;
                System.Console.WriteLine($"You now have {silver} grams of silver and {gold} grams of gold and {diamond} grams of diamond!");
                Console.WriteLine("Would you like to dig again please wirte 'Dig' otherwise write 'Exit'");
                DC = Console.ReadLine();
                if (DC == "Exit" || DC == "exit"){
                    poss = "Out";
                }
        }
   }
   while (poss == "diamond mine"){
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
        Console.WriteLine($"You are now in your 'diamond mine' if you want to dig with your {owned[CuIt].name} that has {owned[CuIt].power} in power level and is enchanted with {ownedM[CuEn].desc}? if so, please write 'Dig'");
        DC = Console.ReadLine();
        while (DC == "Dig" || DC == "dig"){
             MFunc.MTime();//writes 'mining..' while mining
                if (owned[CuIt].power < 5) //if-statement to chose how much is possible for you to dig up based on the power of your item
                {
                    Gdugup = gen.Next(26);
                    Ddugup = gen.Next(16);
                }
                else if (owned[CuIt].power < 11 && owned[CuIt].power > 5)
                {
                    Gdugup = gen.Next(36);
                    Ddugup = gen.Next(26);
                }
                else if (owned[CuIt].power > 10 && owned[CuIt].power < 20)
                {
                   Gdugup = gen.Next(46);
                    Ddugup = gen.Next(36);
                }
                else if (owned[CuIt].power > 20)
                {
                    Gdugup = gen.Next(56);
                    Ddugup = gen.Next(46);
                }
                if (eff > 1){
                Console.WriteLine($"You dug up {Gdugup} gold and {Ddugup} diamond but with your enchant you dug up {Gdugup*eff} gold and {Ddugup*eff} diamond!");
                    Gdugup *= eff;//uses the enchantment effect to mine more
                    Ddugup *= eff;
                }else{
                System.Console.WriteLine($"You dug up {Gdugup} gold and {Ddugup} diamond!");
                }
                gold += Gdugup; // adding what you dug up to your balance
                diamond += Ddugup;
                System.Console.WriteLine($"You now have {gold} grams of gold and {diamond} grams of diamond!");
                Console.WriteLine("Would you like to dig again please wirte 'Dig' otherwise write 'Exit'");
                DC = Console.ReadLine();
                if (DC == "Exit" || DC == "exit"){
                    poss = "Out";
                }
        }
   }

   while (poss == "shop" || poss == "Shop"){
    float Amo = 0;
    float AddAmo = 0;
    Console.WriteLine("Welcome to the store, where you can both sell and buy, what would you like to do? please write 'Sell' or 'Buy'");
    string BS = Console.ReadLine();


//                                              Sell                                                          //
    if(BS == "sell" || BS == "Sell"){
        Console.WriteLine($"Gold is worth: {GWorth} per gram");
        Console.WriteLine($"Iron is worth: {IWorth} per gram");
        Console.WriteLine($"Silver is worth: {SWorth} per gram");
        Console.WriteLine($"Diamond is worth: {DWorth} per gram");
        Console.WriteLine($"Copper is worth: {CWorth} per gram");
        Console.WriteLine("what would you like to sell? Or if you wish to leave please write 'Exit'");
        string SeI = Console.ReadLine();
        if (SeI == "Gold" || SeI == "gold"){
            Console.WriteLine("And how much? please answer in whole digits only! Or if you changed your mind, please write 'Exit'");
            string SeA = Console.ReadLine();
            if (SeA == "Exit" || SeA == "exit"){poss = "Out";}
            float.TryParse(SeA, out Amo);
            if (Amo > gold || Amo < 0){
                Console.WriteLine("please enter a valid amount!");
            }
            else if (Amo > 0 && Amo <= gold){
                AddAmo = Amo*GWorth;
                Console.WriteLine($"That will add up to ${AddAmo}");
                Cash += AddAmo;
                Console.WriteLine($"Your balance is now ${Cash}");
                poss = "Out";
            }
        }
        if (SeI == "Silver" || SeI == "silver"){
              Console.WriteLine("And how much? please answer in whole digits only! Or if you changed your mind, please write 'Exit'");
            string SeA = Console.ReadLine();
            if (SeA == "Exit" || SeA == "exit"){poss = "Out";}
            float.TryParse(SeA, out Amo);
            if (Amo > silver || Amo < 0){
                Console.WriteLine("please enter a valid amount!");
            }
            else if (Amo > 0 && Amo <= silver){
                AddAmo = Amo*SWorth;
                Console.WriteLine($"That will add up to ${AddAmo}");
                Cash += AddAmo;
                Console.WriteLine($"Your balance is now ${Cash}");
                poss = "Out";
            }
        }
        if (SeI == "Iron" || SeI == "iron"){
              Console.WriteLine("And how much? please answer in whole digits only! Or if you changed your mind, please write 'Exit'");
            string SeA = Console.ReadLine();//sell amount
            if (SeA == "Exit" || SeA == "exit"){poss = "Out";}
            float.TryParse(SeA, out Amo);//change sell amount to integer
            if (Amo > iron || Amo < 0){
                Console.WriteLine("please enter a valid amount!");
            }
            else if (Amo > 0 && Amo <= iron){
                AddAmo = Amo*IWorth;
                Console.WriteLine($"That will add up to ${AddAmo}");
                Cash += AddAmo;
                Console.WriteLine($"Your balance is now ${Cash}");
                poss = "Out";
            }
        }
        if (SeI == "Diamond" || SeI == "diamond"){
              Console.WriteLine("And how much? please answer in whole digits only! Or if you changed your mind, please write 'Exit'");
            string SeA = Console.ReadLine();
            if (SeA == "Exit" || SeA == "exit"){poss = "Out";}
            float.TryParse(SeA, out Amo);
            if (Amo > diamond || Amo < 0){
                Console.WriteLine("please enter a valid amount!");
            }
            else if (Amo > 0 && Amo <= diamond){
                AddAmo = Amo*DWorth;
                Console.WriteLine($"That will add up to ${AddAmo}");
                Cash += AddAmo;
                Console.WriteLine($"Your balance is now ${Cash}");
                poss = "Out";
            }
        }
        if (SeI == "Copper" || SeI == "copper"){
              Console.WriteLine("And how much? please answer in whole digits only! Or if you changed your mind, please write 'Exit'");
            string SeA = Console.ReadLine();
            if (SeA == "Exit" || SeA == "exit"){poss = "Out";}
            float.TryParse(SeA, out Amo);
            if (Amo > copper || Amo < 0){
                Console.WriteLine("please enter a valid amount!");
            }
            else if (Amo > 0 && Amo <= copper){
                AddAmo = Amo*CWorth;
                Console.WriteLine($"That will add up to ${AddAmo}");
                Cash += AddAmo;
                Console.WriteLine($"Your balance is now ${Cash}");
                poss = "Out";
            }
        }else if (SeI == "Exit" || SeI == "exit"){
            poss = "Out";
        }else{
            Console.WriteLine("Please write a valid answer!");
        }
    }

//                                          BUY                                             //
    if (BS == "Buy" || BS == "buy"){
        Console.WriteLine("You can buy:");
        Console.WriteLine();
        Console.WriteLine("Mines:");
        Console.WriteLine("copper mine, cost: $700");
        Console.WriteLine("silver mine, cost: $850");
        Console.WriteLine("gold mine, cost: $1000");
        Console.WriteLine("diamond mine, cost: $1500");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Items:");
        Console.WriteLine("magic drill, cost: $400");
        Console.WriteLine("danger tool, cost: $500");
        Console.WriteLine("dynamite, cost: $600");
        Console.WriteLine("write the name of what you want to buy! Or if you want to leave please wirte 'Exit'!");
        string BC = Console.ReadLine();
        if (BC == "copper mine" || BC == "Copper mine"){
            Cash -= 700;
            if (Cash >= 0){
            mlist.mines.Add(new LVL2Mines{name = "copper mine"});
            poss = "Out";
            }
            else{
                Cash += 700;
                Console.WriteLine("That is too expensive for you! Try again");
            }

        }
        if (BC == "Silver mine" || BC == "silver mine"){
            Cash -= 850;
            if (Cash >= 0){
            mlist.mines.Add(new LVL2Mines{name = "silver mine"});
            poss = "Out";
            } else{
                Cash += 850;
                Console.WriteLine("That is too expensive for you! Try again");
            }
        }
        if (BC == "Gold mine" || BC == "gold mine"){
            Cash -= 1000;
            if (Cash >= 0){
            mlist.mines.Add(new LVL2Mines{name = "gold mine"});
            poss = "Out";
            } else{
                Cash += 1000;
                Console.WriteLine("That is too expensive for you! Try again");
            }
        }
        if (BC == "Diamond mine" || BC == "diamond mine"){
            Cash -= 1500;
            if (Cash >= 0){
            mlist.mines.Add(new LVL2Mines{name = "diamond mine"});
            poss = "Out";
            } else{
                Cash += 1500;
                Console.WriteLine("That is too expensive for you! Try again");
            }
        }
        if (BC == "Magic drill" || BC == "magic drill"){
            Cash -= 400;
            if (Cash >= 0){
            owned.Add(new Item{name = "Magic drill", power = 150});
            poss = "Out";
            }
         else{
                Cash += 400;
                Console.WriteLine("That is too expensive for you! Try again");
            }
        }
        if (BC == "Danger tool" || BC == "danger tool"){
            Cash -= 500;
            if (Cash >= 0){
            owned.Add(new Item{name = "Danger tool", power = 250});
            poss = "Out";
            } else{
                Cash += 500;
                Console.WriteLine("That is too expensive for you! Try again");
            }
        }
        if (BC == "Dynamite" || BC == "dynamite"){
            Cash -= 600;
            if (Cash >= 0){
            owned.Add(new Item{name = "Dynamite", power = 500});
            poss = "Out";
            } else{
                Cash += 600;
                Console.WriteLine("That is too expensive for you! Try again");
            }
        }else if(BC == "Exit" || BC == "exit"){
            poss = "Out";
        }
       else{
        Console.WriteLine("please enter a valid option");
       }
    }
   }
}




Console.ReadLine();