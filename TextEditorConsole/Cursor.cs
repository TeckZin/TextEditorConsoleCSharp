using System;

namespace TextEditorConsole
{
    public class Cursor
    {
        public int currX { get; set; }
        public int currY { get; set; }
        
        

        private CursorMover cursorMover;
        public Cursor(int currX, int currY)
        {
            this.currX = currX;
            this.currY = currY;
            cursorMover = new CursorMover();

        }

        public void Render()
        {
            cursorMover.MoveCursor(currX, currY);
            
        }

        public bool moveCursorUp()

        {
            if (currY == 0) return false;
            currY--;
            return true;
        }

        public bool moveCursorDown(int row)
        {
            if (currY == row ) return false;
            currY++;
            return true;
        }

        public bool enterCursor()
        {
            currY ++;
            currX = 0;
            return true;
        }

          

        public bool moveCursorLeft()
        {
            if (currX <= 2) return false;
            currX--;
            return true;
        }
        public bool moveCursorRight(Buffer buffer)
        {
            if (currX > buffer.getCols()) return false;
            currX++;
            return true;
        }


    }



}