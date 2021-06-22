namespace Trivia
{
    using System;
    using Xunit;
    using ApprovalTests.Reporters;

    //[UseReporter(typeof(QuietReporter))]
    [UseReporter(typeof(RiderReporter))]
    public class GameTests
    {
        [Fact]
        public void Should_plays_whole_game()
        {
            // Arrange
            var rand = new Random(1);

            // Act
            using var consoleOutput = new ConsoleOutput();
            var output = consoleOutput.Capture(() => GameRunner.Run(rand));

            // Assert
            ApprovalTests.Approvals.Verify(output + Environment.NewLine);
        }
    }
}
