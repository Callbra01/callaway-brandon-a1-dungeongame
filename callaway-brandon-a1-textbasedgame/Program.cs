// Initialize and Declare player vars
string playerInput = "";
string playerName = "";
string playerClass = "";
int playerDMG;
int playerHP;
int opponentHP;
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

// If player chooses a valid class, set playerVars to corresponding classVars.
// Else if player types an invalid choice, set roomCount to 0 (resulting in ending the game)
if (playerInput == "warrior")
{
    playerDMG = warriorDMG;
    playerHP = warriorHP;

    roomCount = 1;
}
else if (playerInput == "wizard")
{
    playerDMG = wizardDMG;
    playerHP = wizardHP;

    roomCount = 1;
}
else if (playerInput == "wretch")
{
    playerDMG = wretchDMG;
    playerHP = wretchHP;

    roomCount = 1;
}
else
{
    roomCount = 666;
}

// First room/scene
if (roomCount == 1)
{
    //TODO: print intro, delve into first attack sequences
}


// Failure room, ends game
if (roomCount == 666)
{
    Console.WriteLine("failure");
    Console.ReadLine();
}