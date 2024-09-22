// Declare and initialize player vars
string playerInput = "";
string playerName = "";
string playerClass = "";
int playerDMG = 0;
int playerHP = 100;
int playerGold = 0;
bool playerCanFlee = false;
bool playerSelectionInvalid = false;

// Declare and initialize opponent vars
string opponentName = "";
int opponentHP = 0;
int opponentDMG = 0;

// Declare and initialize class-specific vars
int warriorDMG = 35;
int warriorHP = 150;
int wizardDMG = warriorDMG;
int wizardHP = 120;
int wretchDMG = 65;
int wretchHP = 85;

// Declare and initialize room tracking var
int roomCount = 0;

// Ask player for name and get input
Console.WriteLine("Speak your name stranger...");
playerName = Console.ReadLine();

// Tell player class information and ask player to choose
Console.Clear();
Console.WriteLine($"{playerName}, choose your class,\n\nwarriors: brutal soldiers of Hermak'ul\nwizards: mystical mages under the following of Azou'laz" +
    "\nwretchs: miserable draugrs, followers of no god");
Console.WriteLine("\ntype \"warrior\", \"wizard\", or \"wretch\" to select a class");
playerInput = Console.ReadLine();

// If player chooses a valid class, set playerVars to corresponding classVars, and roomCount++
// Else if player types an invalid choice, set roomCount to 666 (resulting in ending the game)
if (playerInput == "warrior")
{
    playerClass = playerInput;
    playerDMG = warriorDMG;
    playerHP = warriorHP;

    roomCount = 1;
}
else if (playerInput == "wizard")
{
    playerClass = playerInput;
    playerDMG = wizardDMG;
    playerHP = wizardHP;

    roomCount = 1;
}
else if (playerInput == "wretch")
{
    playerClass = playerInput;
    playerDMG = wretchDMG;
    playerHP = wretchHP;
    playerCanFlee = true;

    roomCount = 1;
}
else
{
    playerSelectionInvalid = true;
    roomCount = 666;
}

// First room/scene
if (roomCount == 1 && playerSelectionInvalid == false)
{
    // Give opponent hp value, damage value, and name, inform player of playername and class choice
    opponentHP = 60;
    opponentDMG = 25;
    opponentName = "ghoul";
    
    Console.WriteLine($"{playerName}, the {playerClass}...\ntype anything to continue...");
    Console.ReadLine();
    Console.Clear();

    // Print game intro, along with first attack sequence
    Console.WriteLine("TODO PRINT INTRO to dungeon of cupidity");
    Console.WriteLine("A ghoul blocks the way, what will you do: attack, flee, or sacrifice?");
    playerInput = Console.ReadLine();

    // if player attacks, inform player of relevant information
    // If opponent is still alive, opponent attacks, followed by player attacking
    if (playerInput == "attack")
    {
        opponentHP -= playerDMG;
        Console.WriteLine($"{playerName} the {playerClass} attacks the {opponentName}, dealing {playerDMG} damage!");
        if (opponentHP > 0)
        {
            Console.WriteLine($"{opponentName} has {opponentHP}hp left!");
            playerHP -= opponentDMG;
            Console.WriteLine($"\n{opponentName} strikes, dealing {opponentDMG} damage!!!");
            opponentHP -= playerDMG;
            Console.WriteLine($"{playerName} the {playerClass} attacks the {opponentName}, dealing {playerDMG} damage!");
            if ( opponentHP <= 0)
            {
                roomCount = 2;
                playerGold += 25;
                Console.WriteLine($"\n{playerName} the {playerClass} defeated the {opponentName}!!");
                Console.WriteLine($"\n{playerName} now has {playerGold} gold, and {playerHP}hp!");
                Console.WriteLine("type anything to continue");
                Console.ReadLine();
            }
        }
        else
        {
            // This line is for wretches, as their damage one shots enemies
            if (opponentHP <= 0)
            {
                roomCount = 2;
                playerGold += 25;
                Console.WriteLine($"{playerName} the {playerClass} defeated the {opponentName}!!");
                Console.WriteLine($"\n{playerName} now has {playerGold} gold, and {playerHP}hp...");
                Console.WriteLine("type anything to continue");
                Console.ReadLine();
            }
        }
    }
    // If player selects flee, and canFlee is true, allow the player to continue with no gold gain
    // Else if player cannot flee, inform them and fail (no loops!!)
    else if (playerInput == "flee")
    {
        if (playerCanFlee)
        {
            Console.WriteLine("You successfully flee the room, the ghoul is no longer concerned with you...");
            Console.WriteLine("You failed to retrieve any gold...");
            roomCount = 2;
        }
        else
        {
            Console.WriteLine($"{playerClass}'s can not flee.");
            roomCount = 666;
        }
    }
    // If player gives up, player response is thus valid, prompt different text based off class
    else if (playerInput == "sacrifice")
    {
        roomCount = 666;
    }
    // If player input is invalid, end the game
    else
    {
        roomCount = 666;
        playerSelectionInvalid = true;
    }
}

if (roomCount == 2)
{
    Console.Clear();
    Console.WriteLine("You have managed to make it to the next room");
    Console.WriteLine("You see a door to your left and a hole in the wall to your right.");
    Console.WriteLine("Which direction do you choose? \"left\" or \"right\"");
    playerInput = Console.ReadLine();

    if (playerInput == "left")
    {
        roomCount = 4;
    }
    else if (playerInput == "right")
    {
        roomCount = 3;
    }
    else
    {
        playerSelectionInvalid = true;
        roomCount = 666;
    }
}

// Player chose the hole in the wall to their right in the last room
// This room contains a chest
if (roomCount == 3)
{
    Console.Clear();
    Console.WriteLine($"{playerName} stumbles through the rubble... you find a decrepit chest...");
    Console.WriteLine("Do you choose to open it? type \"yes\" or \"no\"");
    playerInput = Console.ReadLine();
    if (playerInput == "yes")
    {
        playerGold += 100;
        playerHP += 75;
        roomCount = 4;
        Console.WriteLine("You feel refreshed... and your pockets feel heavier!");
        Console.WriteLine($"{playerName} now has {playerHP}hp and {playerGold} gold!");
        Console.WriteLine($"{playerName} heads back through the hole in the wall\ntype anything to continue");
        Console.ReadLine();
    }
    else
    {
        roomCount = 4;
        Console.WriteLine($"{playerName} the {playerClass} takes no risks... \ntype anything to head back");
        Console.ReadLine();
    }
}

// Player chose the door to their left in the last room / found the chest in room 3
// This is the store room
// Player requires the sword to beat boss
if (roomCount == 4)
{
    Console.Clear();
    Console.WriteLine($"{playerName} stumble upon an old blind man, he begs you trade him 120 gold for his sword...");
    Console.WriteLine($"you currently have {playerGold} gold\n you can attempt to haggle only once");
    Console.WriteLine("\ntype the amount you would like to haggle for. \"100\", for example");
    playerInput = Console.ReadLine();

    if (int.Parse(playerInput) >= 90 && playerGold >= 90)
    {
        Console.WriteLine("You have acquired: \"Blind Mans Folley, Greatsword\"");
        playerDMG = 1337;
        roomCount = 5;
    }
    else
    {
        Console.WriteLine("The old man suffers a heart attack, and upon falling, shatters the brittle sword");
        roomCount = 5;
    }
}

if (roomCount == 5)
{

}

// Failure room, ends game
if (roomCount == 666)
{
    Console.Clear();
    if(playerSelectionInvalid)
    {
        Console.WriteLine("As you stumble your words, you fall dead on the spot");
        Console.ReadLine();
    }
    else
    {
        if (playerClass == "wretch")
        {
            Console.WriteLine("You sacrifice your life for no god...");
        }
        else
        {
            Console.WriteLine("You sacrifice your life for your god...");
        }
    }
}