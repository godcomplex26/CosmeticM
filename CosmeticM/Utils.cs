using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CosmeticM
{
    public class Utils
    {
        public static string sqlQueryConverter(string text)
        {
            string query = "";
            string pattern = @"BETWEEN\((.+?),(.+?)\)";

            char[] separators = { ';' };

            List<string> resultList = text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                                  .ToList();

            for (int i = 0; i < resultList.Count; i++)
            {
                Match match = Regex.Match(resultList[i], pattern);
                string tempQ;

                if (match.Success)
                {
                    string value1 = match.Groups[1].Value;
                    string value2 = match.Groups[2].Value;
                    string value3 = match.Groups[3].Value;
                    tempQ = Between(value1, value2, value3);
                }
                else
                {
                    tempQ = resultList[i].ToString();
                }

                if (i == resultList.Count - 1)
                {
                    // 마지막 항목에 대한 처리
                    query += tempQ;
                }
                else
                {
                    // 마지막 항목이 아닌 경우에 대한 처리
                    query += tempQ + " AND ";
                }
            }
            return query;
        }

        delegate int Operation(int a, int b);

        static string Between(string q, string a, string b)
        {
            return $"{q} BETWEEN {a} AND {b}";
        }
    }
}
