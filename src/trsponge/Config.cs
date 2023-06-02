using CommandLine;
using System.Collections.Generic;

namespace Trash
{
    public class Config
    {
        [Option('f', "file", Required = false, HelpText = "Read parse tree data from file instead of stdin.")]
        public string File { get; set; }

        [Option('c', "clobber", Required = false, Default = false)]
        public bool Clobber { get; set; }

        [Option('o', "output-directory", Required = false)]
        public string OutputDirectory { get; set; }

        [Option('v', "verbose", Required = false)]
        public bool Verbose { get; set; }
    }
}
