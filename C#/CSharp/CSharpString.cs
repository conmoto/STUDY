using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class CSharpString
    {
        public static void Run()
        {
            string name = "Harry Potter";

            //찾기
            bool found = name.Contains("Harry");
            int index = name.IndexOf("P");

            //변형
            name += "Junior";
            string lowercaseString = name.ToLower();
            string uppercaseString = name.ToUpper();
            string newName = name.Replace('P', 'C');

            //분할
            string[] names = name.Split(new char[] {' '});
            string substringName = name.Substring(6);
        }
    }
}
