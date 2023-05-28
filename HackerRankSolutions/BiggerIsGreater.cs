using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.BiggerIsGreater
{
    public class BiggerIsGreater
    {
       public static string FindNextBiggestString(string w)
        {            
            for (int i = w.Length - 2; i >= 0; i--)
            {
                if (w[i + 1] > w[i])
                {  
                    string orderedPost = new(w[i..].OrderBy(c => c).ToArray());                                       
                    char chosenChar = orderedPost.First(c => c > w[i]);
                    int chosenIndex = orderedPost.LastIndexOf(chosenChar);
                    string finalPost = orderedPost.Remove(chosenIndex, 1);
                    string s = w[..i] + chosenChar + finalPost;
                    return s;
                }
            }
            return "no answer";
        }
    }
}
