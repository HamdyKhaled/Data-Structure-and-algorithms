using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTables
{
    class Program
    {
        public static int LengthOfLongestSubstring(string s)
        {
            HashSet<char> chars = new HashSet<char>();
            int right = 0, left = 0, max = 0;
            while(right < s.Length)
            {
                if(!chars.Contains(s[right]))
                {
                    chars.Add(s[right]);
                    max = Math.Max(max, chars.Count);
                    right++;
                }
                else
                {
                    chars.Remove(s[left]);
                    left++;
                }
            }

            return max;

        }

        public static bool checkInclusion(String s1, String s2)
        {
            if (s1.Length > s2.Length)
                return false;
            int[] s1map = new int[26];
            int[] s2map = new int[26];
            int right = 0, left = 0;

            while(right < s1.Length)
            {
                s1map[s1[right] - 'a']++;
                s2map[s2[right] - 'a']++;
                right++;
            }

            right--;

            while (right < s2.Length)
            {
                if (matches(s1map, s2map))
                    return true;

                right++;
                if(right != s2.Length)
                    s2map[s2[right] - 'a']++;
                    
                s2map[s2[left] - 'a']--;
                left++;
            }
            return false;
        }

        public static bool matches(int[] s1map, int[] s2map)
        {
            for (int i = 0; i < 26; i++)
            {
                if (s1map[i] != s2map[i])
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string s1 = "afl";
            string s2 = "abcablfa";
            //var maxLength = LengthOfLongestSubstring(s);

            var IsIncluded = checkInclusion(s1, s2);

            Console.ReadLine();
        }
    }
}
