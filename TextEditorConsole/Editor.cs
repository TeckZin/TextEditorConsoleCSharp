using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;

namespace TextEditorConsole
{
    public class Editor
    {

        private Cursor cursor;
        
        private int row { get; set; }

        private List<Buffer> buffers;
        
        private int bufferHeight { get; set; }
        private int bufferWidth { get; set; }
        

        public Editor(bool newFile, string filePath)
        {
            cursor = new Cursor(0, 0);
            this.buffers = new List<Buffer>();
            if (newFile)
            {
                cursor.currX = 2;
                cursor.currY = 0;
                this.row = 5;
                for (int i = 0; i <= this.row; i++)
                {
                    
                    Buffer buffer = new Buffer(row,"~" + i);
                    buffers.Add(buffer);
                    Console.WriteLine(buffer.Render());
                    
                }
                
               
                
                
                
            }


            bufferHeight = Console.BufferHeight;
            bufferWidth = Console.BufferWidth;
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
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {

                this.row++;
                cursor.enterCursor();
                // Console.Write(this.row + ": " + cursor.currY);
                Buffer buffer = new Buffer(cursor.currY, "~" + cursor.currY);
                bufferHeight += 2;
                Console.SetBufferSize(bufferWidth, bufferHeight);
                Console.BufferHeight = bufferHeight;
                
                cursor.Render();
                if (cursor.currY == row)
                {
                    buffers.Add(buffer);
                    Console.WriteLine(buffers[cursor.currY].Render());
                    // Console.Write("Test");
                }
                else
                {
                    // printBuffer();
                    buffers.Insert(cursor.currY, buffer);
                    // printBuffer();
                    
                    
                    RenderBuffers(cursor.currY+1, row);
                    
                    
                }

                cursor.currX = 2;
                
                

                cursor.Render();
            }
            else
            {
                Buffer currBuffer = buffers[cursor.currY];
                
                Console.Write(cursor.currY);
                switch (key.Key)
                {
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


        public void RenderBuffers(int l, int h)
        {
            int currYPos = cursor.currY;
            // Console.Write("l: " + l +"//h: " + h);
            for (int i = l; i < h; i++)
            {
                cursor.currY++;
                cursor.Render();
                buffers[i].lines = ("~" + i).Split().ToList();
                Console.WriteLine(buffers[i].Render());
            }

            cursor.currY = currYPos;
            cursor.Render();





        }

        public void printBuffer()
        {
            foreach (Buffer buffer in buffers)
            {
                Console.Write(buffer.Render());
                
            }
            
        }
    }



}