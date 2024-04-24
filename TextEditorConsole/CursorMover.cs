using System;

namespace TextEditorConsole
{
    public class CursorMover
    {


        public void MoveCursor(int x, int y)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
        }

    }



}