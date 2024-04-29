using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_Problems___29._04._2024
{
    public  class ExcelSheetColumn
    {
        public async Task<string> GetExcelColumnTitle(int columnNumber)
        {
            string columnTitle = "";

            while (columnNumber > 0)
            {
                int remainder = (columnNumber - 1) % 26; // Get the remainder
                columnTitle = (char)('A' + remainder) + columnTitle; // Convert remainder to corresponding character
                columnNumber = (columnNumber - 1) / 26; // Update column number
            }

            return columnTitle;
        }
    }
}
