// Initialize and Declare player vars
string playerInput = "";
string playerName = "";
string playerClass = "";
int playerDMG = 0;
int playerHP = 100;
int playerGold = 0;
bool playerCanFlee = false;

// Initialize and Declare opponent vars
string opponentName = "";
int opponentHP = 0;
int opponentDMG = 0;

// Initialize and Declare class-specific vars
int warriorDMG = 35;
int warriorHP = 150;
int wizardDMG = warriorDMG;
int wizardHP = 120;
int wretchDMG = 65;
int wretchHP = 85;

// Initialize and Declare room tracking var
int roomCount = 0;

// Ask player for name and get input
Console.WriteLine("enter name:");
playerName = Console.ReadLine();

// Tell player class information and ask to choose
Console.WriteLine("in this land, warriors: wizards: wretchs");
Console.WriteLine("pick");
playerInput = Console.ReadLine();

// If player chooses a valid class, set playerVars to corresponding classVars, and roomCount++
// Else if player types an invalid choice, set roomCount to 0 (resulting in ending the game)
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
    roomCount = 666;
}

// First room/scene
if (roomCount == 1)
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
    // If opponent is still alive, attack the player again
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
    // If player input is invalid, end the game
    else
    {
        Console.WriteLine($"{playerName}'s foolishness has rendered their life forfiet.");
        roomCount = 666;
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
    Console.WriteLine("you stumble upon an old blind man, he begs you trade him 120 gold for his sword...");
    Console.WriteLine($"you currently have {playerGold} gold, you can attempt to haggle only once");
    Console.WriteLine("type \"haggle amount\"");
    playerInput = Console.ReadLine();
    // TODO PARSE HAGGLE STRING AND IF OVER A CERTAIN AMOUNT GIVE PLAYER ITEM
    
}

// Failure room, ends game
if (roomCount == 666)
{
    Console.WriteLine("failure");
    Console.ReadLine();
}