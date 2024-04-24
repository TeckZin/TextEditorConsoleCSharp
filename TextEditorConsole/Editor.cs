using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace TextEditorConsole
{
    public class Editor
    {

        private Cursor cursor;
        
        private int row { get; set; }

        private List<Buffer> buffers;
        

        public Editor(bool newFile, string filePath)
        {
            cursor = new Cursor(0, 0);
            this.buffers = new List<Buffer>();
            if (newFile)
            {
                cursor.currX = 2;
                cursor.currY = 0;
                this.row = 5;
                for (int i = 0; i < this.row; i++)
                {
                    Buffer buffer = new Buffer(row,"");
                    buffers.Add(buffer);
                    Console.WriteLine("~");
                    
                }
                
               
                
                
                
            }
            // else
            // {
            //     
            // }
            cursor.Render();
            Run();


        }

        public void Run()
        {
            
            while (true)
            {
                ReadLine();
            }
        }

        public void ReadLine()
        {
            // Console.WriteLine(cursor.currY);
            Buffer currBuffer = buffers[cursor.currY];
            var key = Console.ReadKey();
            
            

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("~");
                    this.row++;
                    bool flag = cursor.moveCursorDown(row);
                    if (flag)
                    {
                        cursor.currX = buffers[cursor.currY].getCols()+1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    cursor.moveCursorUp(); 
                    
                    break;
                case ConsoleKey.DownArrow:
                    
                    bool flag2 = cursor.moveCursorDown(row);
                    if (flag2)
                    {
                        cursor.currX = buffers[cursor.currY].getCols()+1;
                    }
                    
                    break;
                case ConsoleKey.LeftArrow:
                    cursor.moveCursorLeft();
                    break;
                case ConsoleKey.RightArrow:
                    cursor.moveCursorRight(currBuffer);
                    break;
                default:
                    cursor.currX++;
                    currBuffer.insert(key.ToString(), cursor.currX);
                     
                    break;
            }
            cursor.Render();
            

        }

    }



}