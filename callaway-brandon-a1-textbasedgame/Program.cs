// Declare and initialize player vars
string playerInput;
string playerName;
string playerClass = "";
int playerDMG = 0;
int playerHP = 100;
int playerGold = 0;
bool playerCanFlee = false;
bool playerSelectionInvalid = false;

// Declare and initialize opponent vars
string opponentName;
int opponentHP;
int opponentDMG;

// Declare and initialize class-specific vars, wizards and warriors have the same hp
int warriorDMG = 35;
int warriorHP = 110;
int wizardDMG = warriorDMG;
int wizardHP = 100;
int wretchDMG = 65;
int wretchHP = 65;
string classBoss = "";

// Declare and initialize room tracking var
int roomCount;

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
    classBoss = "Azou\'laz, God of the ethereal";

    roomCount = 1;
}
else if (playerInput == "wizard")
{
    playerClass = playerInput;
    playerDMG = wizardDMG;
    playerHP = wizardHP;
    classBoss = "Hermak'ul, God of fury";

    roomCount = 1;
}
else if (playerInput == "wretch")
{
    playerClass = playerInput;
    playerDMG = wretchDMG;
    playerHP = wretchHP;
    playerCanFlee = true;
    classBoss = "Ul'yaakir, God of puppets";
    roomCount = 1;
}
else
{
    playerSelectionInvalid = true;
    roomCount = 666;
}

// First room/scene
if (roomCount == 1)
{
    // Give opponent hp value, damage value, and name, inform player of playername and class choice
    opponentHP = 60;
    opponentDMG = 25;
    opponentName = "ghoul";

    Console.Clear();
    Console.WriteLine($"{playerName}, the {playerClass}...\npress ENTER to continue...");
    Console.ReadLine();
    Console.Clear();

    // Print game intro, along with first attack sequence
    Console.WriteLine($"{playerName} the {playerClass}, after a long and arduous journey, has found themselves at the entrance of the Dungeon of Cupidity...");
    Console.WriteLine($"A {opponentName} blocks the way, what will you do? \"attack\", \"flee\", or \"sacrifice?\"");
    playerInput = Console.ReadLine();

    // if player attacks, inform player of relevant information
    // If opponent is still alive, opponent attacks, followed by player attacking
    if (playerInput == "attack")
    {
        Console.Clear();
        opponentHP -= playerDMG;
        Console.WriteLine($"{playerName} the {playerClass} attacks the {opponentName}, dealing {playerDMG} damage!");
        if (opponentHP > 0)
        {
            Console.WriteLine($"{opponentName} has {opponentHP}hp left!");
            playerHP -= opponentDMG;
            Console.WriteLine($"\n{opponentName} strikes, dealing {opponentDMG} damage!!!");
            opponentHP -= playerDMG;
            Console.WriteLine($"{playerName} the {playerClass} attacks the {opponentName}, dealing {playerDMG} damage!");
            if (opponentHP <= 0)
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
            Console.Clear();
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
        Console.Clear();
        if (playerCanFlee)
        {
            Console.WriteLine("You successfully flee the room, the ghoul is no longer concerned with you...");
            Console.WriteLine("You failed to retrieve any gold...");
            roomCount = 2;
        }
        else
        {
            Console.WriteLine($"{playerClass}'s can not flee.");
            Console.WriteLine();
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

// Hallway room with chest to the right, and store to the left
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
        Console.Clear();
        playerGold += 100;
        playerHP += 75;
        roomCount = 4;
        Console.WriteLine("You feel refreshed... and your pockets feel heavier!");
        Console.WriteLine($"{playerName} now has {playerHP}hp and {playerGold} gold!");
        Console.WriteLine($"{playerName} heads back through the hole in the wall\npress ENTER to continue...");
        Console.ReadLine();
    }
    else
    {
        roomCount = 4;
        Console.WriteLine($"{playerName} the {playerClass} takes no risks... \n{playerName} heads back through the hole in the wall\npress ENTER to continue...");
        Console.ReadLine();
    }
}

// Player chose the door to their left  in the last room or left the room to their right
// This is the store room
// Player requires the sword to beat boss
if (roomCount == 4)
{
    Console.Clear();
    Console.WriteLine($"{playerName} stumble upon an old blind man, he begs you trade him 120 gold for his sword...");
    Console.WriteLine($"you currently have {playerGold} gold\nyou can attempt to haggle only once");
    Console.WriteLine("\ntype the amount you would like to haggle for. \"100\", for example");
    playerInput = Console.ReadLine();

    if (int.Parse(playerInput) >= 90 && playerGold >= 90)
    {
        Console.WriteLine($"{playerName} has acquired: \"Blind Mans Folley, Greatsword\"");
        playerDMG = 1337;
        roomCount = 5;
    }
    else
    {
        Console.WriteLine("The old man suffers a heart attack, and upon falling, shatters the brittle sword");
        roomCount = 5;
    }
    Console.WriteLine("press ENTER to continue...");
    Console.ReadLine();
}

// Final room, contains a boss
if (roomCount == 5)
{
    Console.Clear();
    opponentDMG = 100;
    opponentHP = 1000;

    Console.WriteLine($"{playerName} the {playerClass} discovers {classBoss}... The door shuts behind them.");
    Console.WriteLine($"{classBoss} blocks the way, what will you do? \"attack\", or \"sacrifice?\"");
    playerInput = Console.ReadLine();

    // if player attacks, inform player of relevant information
    // If opponent is still alive, opponent attacks, followed by player attacking
    if (playerInput == "attack")
    {
        Console.Clear();
        opponentHP -= playerDMG;
        Console.WriteLine($"{playerName} the {playerClass} attacks the {classBoss}, dealing {playerDMG} damage!");

        if (opponentHP > 0)
        {
            Console.WriteLine($"{classBoss} has {opponentHP}hp left!");
            playerHP -= opponentDMG;
            Console.WriteLine($"\n{classBoss} strikes, dealing {opponentDMG} damage!!!");
            if (playerHP > 0)
            {
                opponentHP -= playerDMG;
                Console.WriteLine($"\n{playerName} the {playerClass} attacks the {classBoss}, dealing {playerDMG} damage!");
                if (opponentHP <= 0)
                {
                    playerGold += 250;
                    Console.WriteLine($"\n{playerName} the {playerClass} defeated {classBoss}!!");
                    Console.WriteLine($"\n{playerName} now has {playerGold} gold, and {playerHP}hp!");
                    Console.WriteLine($"{playerName} is free to leave the dungeon...");
                }
            }
            else
            {
                Console.WriteLine($"{classBoss} has delt a fatal blow...\n{playerName} the {playerClass} has been vanquished");
            }
        }
        else
        {
            // This line is for when opponent has been one-shot
            Console.Clear();
            if (opponentHP <= 0)
            {
                playerGold += 250;
                Console.WriteLine($"{playerName} the {playerClass} defeated the {classBoss}!!");
                Console.WriteLine($"\n{playerName} now has {playerGold} gold, and {playerHP}hp...");
                Console.WriteLine($"{playerName} is free to leave the dungeon...");
            }
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

// Failure room, can be directed to from any other room, ends game
if (roomCount == 666)
{
    Console.Clear();
    if (playerSelectionInvalid)
    {
        Console.WriteLine("As you stumble your words, you fall dead on the spot");
    }
    else
    {
        // Wretch's follow no god, and no god will lay claim to their soul
        // Warriors and Wizards, when sacrificing themselves, do not have their soul claimed by their own god.
        if (playerClass == "wretch")
        {
            Console.WriteLine("You sacrifice your life for no god...");
        }
        else
        {
            Console.WriteLine($"You sacrifice your life, but your god is not pleased...\n{classBoss} claims your soul instead...");
        }
    }
}