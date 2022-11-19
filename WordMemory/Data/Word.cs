using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemory.Data
{
    public struct Word
    {
        public Word(string wordName, List<string> meanList)
        {
            WordName = wordName;
            MeanList = meanList;
        }
        string WordName;
        List<string> MeanList;
    }
}
