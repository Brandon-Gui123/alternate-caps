using System.Diagnostics;

namespace AlternateCapsTests
{
    public class AlternateCapsCLITests
    {
        public class RunningWithouArguments
        {
            [Test, Timeout(10_000)]
            public void ProcessFromStandardInput_OutputFormattedText()
            {
                ProcessStartInfo startInfo = new()
                {
                    FileName = "AlternateCaps.exe",
                    Arguments = null,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };

                using Process? programProcess = Process.Start(startInfo);

                // make sure that the process does exist
                // else, something is very wrong
                Assert.That(programProcess, Is.Not.Null);

                programProcess.StandardInput.WriteLine("abcdefg");
                string expected = "aBcDeFg";
                string? output = programProcess.StandardOutput.ReadLine();

                // we're done sending inputs
                programProcess.StandardInput.Close();

                Assert.That(output, Is.Not.Null.And.EqualTo(expected));
            }

            [Test, Timeout(10_000)]
            public void CapsFirstOption_ProcessFromStandardInput_OutputFormattedText()
            {
                ProcessStartInfo startInfo = new()
                {
                    FileName = "AlternateCaps.exe",
                    Arguments = "--caps-first",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                };

                using Process? programProcess = Process.Start(startInfo);

                // make sure that the process does exist
                // else, something is very wrong
                Assert.That(programProcess, Is.Not.Null);

                programProcess.StandardInput.WriteLine("abcdefg");
                string expected = "AbCdEfG";
                string? output = programProcess.StandardOutput.ReadLine();

                // we're done sending inputs
                programProcess.StandardInput.Close();

                Assert.That(output, Is.Not.Null.And.EqualTo(expected));
            }
        }
    }
}