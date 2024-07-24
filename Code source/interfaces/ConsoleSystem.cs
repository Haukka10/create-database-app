using System;

namespace DATABASE_useing_CSharp.inst
{
    internal interface IConsoleSystem
    {
        void ColerConsole();
        void Write(string text);
        void ColorConsole(string text,ConsoleColor consoleColor);
    }
}
