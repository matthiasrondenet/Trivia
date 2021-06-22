namespace Trivia
{
    using System;
    using System.IO;

    public class ConsoleOutput : IDisposable
    {
        private readonly TextWriter   original;
        private readonly MemoryStream stream;
        private readonly StreamWriter writer;

        public ConsoleOutput()
        {
            this.original = Console.Out;
            this.stream   = new MemoryStream();
            this.writer   = new StreamWriter(this.stream);
            Console.SetOut(this.writer);
        }

        public void Dispose()
        {
            Console.SetOut(this.original);
            this.writer.Dispose();
            this.stream.Dispose();
        }

        public string Capture(Action action)
        {
            action();

            Console.Out.Flush();
            this.stream.Position = 0;

            return new StreamReader(this.stream).ReadToEnd();
        }
    }
}
