using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TextEditorConsole
{
    public class Buffer
    {
        private List<string> lines; 
        public int row; 
        public Buffer(int row, string lines)
        {
            this.row = row;
            this.lines = lines.Split().ToList();
                
        }


        public int getCols()
        {
            return lines.Count;
        }

        public void insert(string key, int idx)
        {
            if (idx >= getCols())
            {
                lines.Add(key);
            } else lines.Insert(idx, key);

        }
        
        

        
        

    }



}