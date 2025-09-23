// NO NEED TO CHANGE THIS FILE

using AsyncProgramming;

var dbClient = new DatabaseClient();
var code = new Code(dbClient);

//1
Console.WriteLine("Showing user names...");
await code.WriteUserNames();
Console.WriteLine("Continue execution after showing user names");

//2
Console.WriteLine("\nShowing the users (forgot to await)...");
code.WriteUserNames();
Console.WriteLine("Continue execution after showing user names (forgot to await)");

Console.WriteLine("\nWaiting 5 seconds");
await Task.Delay(TimeSpan.FromSeconds(5));

// 3
Console.WriteLine("\nBuggy database call...");
await code.HandleBuggyDatabaseCall();
Console.WriteLine("Continue execution after Buggy database call");

// 4
Console.WriteLine("\nBad async void example...");
code.BadAsyncVoid();
Console.WriteLine("Continue execution after bad async void example");

// 5
Console.WriteLine("\nWrite users one by one");
await code.WriteUserNamesOneByOne();
Console.WriteLine("Continue execution after WriteUserNamesOneByOne");

// 6
Console.WriteLine("\nWrite users one by one - Try cancel in the middle pressing E");
try
{
  var cancellationTokenSource = new CancellationTokenSource();
  //The following line is a bit ugly
  Task.Run(() => { TriggerCancelOnPressingE(cancellationTokenSource); });

  await code.WriteUserNamesOneByOne(cancellationTokenSource.Token);
}
catch (OperationCanceledException ex)
{
  Console.WriteLine($"Cancelled Write User one by one: {ex.Message}");
}

Console.WriteLine("Continue execution after WriteUserNamesOneByOne(cancellable)");
return;

void TriggerCancelOnPressingE(CancellationTokenSource? cts)
{
  while (true)
  {
    if (Console.KeyAvailable)
    {
      var keyInfo = Console.ReadKey(true);
      if (keyInfo.Key == ConsoleKey.E)
      {
        cts?.Cancel();
      }

      Thread.Sleep(100);
    }
  }
}
