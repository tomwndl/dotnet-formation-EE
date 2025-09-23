// NO NEED TO CHANGE THIS FILE

using System.Runtime.CompilerServices;

namespace AsyncProgramming;

public class DatabaseClient
{
  private readonly TimeSpan oneSecond = new TimeSpan(0, 0, 1);

  /// <summary>
  /// Long-running process returning the name of users.
  /// Takes <see cref="oneSecond"/> time for each user returned.
  /// </summary>
  /// <remarks>Implementation is not important, this is only to fake a long-running database call</remarks>
  public async Task<IReadOnlySet<string>> GetUsers(CancellationToken cancellationToken = default)
  {
    await Task.Delay(oneSecond * users.Count(), cancellationToken);
    return users.ToHashSet();
  }

  /// <summary>
  /// Waits <see cref="oneSecond"/> before throwing a TimeoutException
  /// </summary>
  /// <exception cref="TimeoutException"></exception>
  public async Task BuggyDatabaseCall()
  {
    await Task.Delay(oneSecond);
    throw new TimeoutException("Query was too long and timed out");
  }

  /// <summary>
  /// Long-running process returning user names one by one as soon as they are availabe.
  /// Taês <see cref="oneSecond"/> before a user is availabe
  /// </summary>
  /// <remarks>Implementation is not important, this is only to fake a long-running database call</remarks>
  public async IAsyncEnumerable<string> GetUsersOneByOne([EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    foreach (var user in users)
    {
      cancellationToken.ThrowIfCancellationRequested();

      await Task.Delay(oneSecond, cancellationToken);
      yield return user;
    }
  }

  private IEnumerable<string> users =
  [
    "Antoine",
    "Brigitte",
    "Charles",
    "Delphine",
  ];
}
