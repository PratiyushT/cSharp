//VARIABLE INITIALIZATION OR DECLARATION

var date = DateTime.UtcNow;
int score;
string gameType;
string roundNum;
var gamesList = new List<string>();
bool endGame = false;
//METHOD INVOCATION
string name = GetUserName();
Menu(date, name);

//Ask username.
string GetUserName()
{
  Console.Write("Please enter your username: ");
  var username = Console.ReadLine()!;
  return username;
}

//Display initial menu after asking name.
void Menu(DateTime dateTime, string userName)
{
  while (!endGame)
  {
    Console.Clear();
    Console.WriteLine($"Time: {dateTime}");
    Console.WriteLine($"Welcome {userName}\n");
    Console.WriteLine(@"Choose ""M"" for Multiplication ");
    Console.WriteLine(@"Choose ""D"" for Division ");
    Console.WriteLine(@"Choose ""A"" for Addition ");
    Console.WriteLine(@"Choose ""S"" for Subtraction ");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine(@"Press ""H"" to view game history");

    string choice = Console.ReadLine()!;

    Console.Clear();
    Console.Clear();
    switch (choice.ToLower())
    {
      case "m":
      {
        score = 0;
        gameType = "Multiplication";
        Console.WriteLine("\nHow many rounds do you want to play?");
        roundNum = Console.ReadLine()!;
        MultiplicationGame(roundNum);
        break;
      }
      case "d":
      {
        score = 0;
        gameType = "Division";
        Console.WriteLine("\nHow many rounds do you want to play?");
        roundNum = Console.ReadLine()!;
        DivisionGame(roundNum);
        break;
      }
      case "a":
      {
        score = 0;
        gameType = "Addition";
        Console.WriteLine("\nHow many rounds do you want to play?");
        roundNum = Console.ReadLine()!;
        AdditionGame(roundNum);
        break;
      }
      case "s":
      {
        score = 0;
        gameType = "Subtraction";
        Console.WriteLine("\nHow many rounds do you want to play?");
        roundNum = Console.ReadLine()!;
        SubtractionGame(roundNum);
        break;
      }
      case "h":
      {
        ShowGameHistory();
        break;
      }
    }
  }
}

//OPERATIONS
void MultiplicationGame(string numberOfRounds)
{
  int totalRounds = int.Parse(numberOfRounds);
  var random = new Random();
  Console.WriteLine("Selected Multiplication");
  for (int i = 1; i <= totalRounds; i++)
  {
    int firstNumber = random.Next(0, 9);
    int secondNumber = random.Next(0, 9);

    Console.WriteLine($"Score is: {score}");
    Console.Write($"{i}) {firstNumber} X {secondNumber} = ?\nAns: ");
    var answer = Console.ReadLine();

    if (int.Parse(answer!) == firstNumber * secondNumber)
      CorrectAnswer();
    else
      Console.WriteLine($"You have entered the wrong answer.\nCorrect Answer:{firstNumber * secondNumber}");

    if (i == totalRounds)
    {
      DisplayResult();
      break;
    }
  }
}

void DivisionGame(string numberOfRounds)
{
  int i = 0;
  int totalRounds = int.Parse(numberOfRounds);
  var random = new Random();
  Console.WriteLine("Selected Division");
  while (i <= totalRounds)
  {
    {
      int firstNumber = random.Next(0, 99);
      int secondNumber = random.Next(0, 99);


      if ((secondNumber == 0) || (firstNumber % secondNumber != 0)) continue;

      i++;
      Console.WriteLine($"Score is: {score}");
      Console.Write($"{i}) {firstNumber} / {secondNumber} = ?\nAns: ");
      var answer = Console.ReadLine();

      if (int.Parse(answer!) == firstNumber / secondNumber)
        CorrectAnswer();
      else
        Console.WriteLine($"You have entered the wrong answer.\nCorrect Answer:{firstNumber / secondNumber}");

      if (i == totalRounds)
      {
        DisplayResult();
        break;
      }
    }
  }
}

void AdditionGame(string numberOfRounds)
{
  int totalRounds = int.Parse(numberOfRounds);
  var random = new Random();
  Console.WriteLine("Selected Addition");
  for (int i = 1; i <= totalRounds; i++)
  {
    int firstNumber = random.Next(0, 9);
    int secondNumber = random.Next(0, 9);

    Console.WriteLine($"Score is: {score}");
    Console.Write($"{i}) {firstNumber} + {secondNumber} = ?\nAns: ");
    var answer = Console.ReadLine();

    if (int.Parse(answer!) == firstNumber + secondNumber)
      CorrectAnswer();
    else
      Console.WriteLine($"You have entered the wrong answer.\nCorrect Answer:{firstNumber + secondNumber}");

    if (i == totalRounds)
    {
      DisplayResult();
      break;
    }
  }
}

void SubtractionGame(string numberOfRounds)
{
  int totalRounds = int.Parse(numberOfRounds);
  var random = new Random();
  Console.WriteLine("Selected Subtraction");
  for (int i = 1; i <= totalRounds; i++)
  {
    int firstNumber = random.Next(0, 9);
    int secondNumber = random.Next(0, 9);

    Console.WriteLine($"Score is: {score}");
    Console.Write($"{i}) {firstNumber} - {secondNumber} = ?\nAns: ");
    var answer = Console.ReadLine();

    if (int.Parse(answer!) == firstNumber - secondNumber)
      CorrectAnswer();
    else
      Console.WriteLine($"You have entered the wrong answer.\nCorrect Answer:{firstNumber - secondNumber}");

    if (i == totalRounds)
    {
      DisplayResult();
      break;
    }
  }
}

void CorrectAnswer()
{
  Console.WriteLine("Your answer was correct.");
  score++;
}

void DisplayResult()
{
  Console.Clear();
  Console.WriteLine($"Username: {name}");
  Console.WriteLine($"Total rounds played: {roundNum}");
  Console.WriteLine($"Your final score is {score}");
  Console.Write(@"Press ""Q"" to quit the game(Anything else to continue): ");
  var continueGame = Console.ReadLine()!;
  gamesList.Add($"{DateTime.Now} - {gameType} - Rounds: {roundNum} Score: {score} "); //Adding to list
  if (continueGame.ToLower() == "q") endGame = true;
}

void ShowGameHistory()
{
  Console.Clear();
  Console.WriteLine("---------------------------------------------------------");
  Console.WriteLine($"Username: {name}");
  foreach (string gameLog in gamesList)
  {
    Console.WriteLine(gameLog);
  }


  Console.WriteLine("---------------------------------------------------------");

  Console.Write(@"Press ""Q"" to quit the game(Anything else to continue): ");
  var continueGame = Console.ReadLine()!;
  if (continueGame.ToLower() == "q") endGame = true;
}