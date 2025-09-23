namespace AsyncProgramming;

public class Code(DatabaseClient dbClient)
{
  //TODO-1: Console.WriteLine the names of the users retrieved from the Database
  public async Task WriteUserNames()
  {
    // throw new NotImplementedException();
  }

  //TODO-2: Go to the Program.cs file and see what happens when you forget to use await on a Task ?

  //TODO-3: Try/Catch the dbCLient.BuggyDatabaseCall() and Console.WriteLine the ex.Message
  public async Task HandleBuggyDatabaseCall()
  {
    throw new NotImplementedException();
  }

  //TODO-4: Same as TODO-3, You can copy/paste. Run the app again an see the difference with TODO-3
  public async void BadAsyncVoid()
  {
    throw new NotImplementedException();
  }

  //TODO-5: Console.WriteLine the user names one by one as soon as they are available
  public async Task WriteUserNamesOneByOne(CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
    //hint: use `
    //await foreach(var user in dbClient.GetUsersOneByOne())
  }

  //TODO-6: pass the cancellationToken. Run the app and try to cancel in the middle of execution
}
