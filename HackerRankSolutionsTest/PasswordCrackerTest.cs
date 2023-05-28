using HackerRankSolutions.PasswordCracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutionsTest
{
    public class PasswordCrackerTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(string passwordsString, string loginAttempt, string possibleResultsString)
        {
            var passwords  = passwordsString.Split(' ').ToList();
            var possibleResults = possibleResultsString.Split(",").ToList();
            string actualResult = PasswordCracker.CrackPassword(passwords, loginAttempt);
            Assert.Contains(actualResult, possibleResults);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "because can do must we what", "wedowhatwemustbecausewecan", "we do what we must because we can" },
                new object[] { "hello planet", "helloworld", "WRONG PASSWORD" },
                new object[] { "ab abcd cd", "abcd", "ab cd,abcd" },
                new object[] { "zsnpgbqh bktrpgdwbu qhuhzxfh mxrgmga omgtgnqomb dffttrwlfh", "nktrsgtwbuzsbptzahomgtgnaoma", "WRONG PASSWORD" },
                new object[] { "xkof medbc mhyewjzsdg vkuzym tbeqv xtbyhn", "xtbyhnmedbcmhyewjzsdgxtbyhn", "xtbyhn medbc mhyewjzsdg xtbyhn" },
                new object[] { "alutwfal kkhbqlrxnm qyyx lwdgpchwic rdtgzvw sduh", "sduhkkhbqlrxnmsduhsduhqyyx", "sduh kkhbqlrxnm sduh sduh qyyx" },
                new object[] { "a aa aaa aaaa aaaaa aaaaaa aaaaaaa aaaaaaaa aaaaaaaaa aaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", "WRONG PASSWORD" },
                new object[] { "the cake is a lie thec ak ei sal ie", "thecakeisaliethecakeisalieakthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieathecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethethecakeisaliethecakeisaliethecakeisaliethecakeisaliethethecakeisalieakthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliesalthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliesalthecakeisaliethecakeisalielieakthecakeisalieliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieakthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieeithecakeisaliethecakeisalieeithecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieiethecakeisaliethecakeisaliethecakeisaliethecakeisalieisthecakeisaliethecakeisalieiscakeakthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieakcakethecakeisaliethecieiethecthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieeithecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieathecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieeithecakeisaliethecakeisaliethecakeisaliethecakeisalieacakethecakeisaliethecakeisaliesalthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalieakthecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisaliethecakeisalie", "the cake is a lie thec ak ei sal ie ak the cake is a lie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie the cake is a lie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie the cake is a lie a thec ak ei sal ie the cake is a lie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie the thec ak ei sal ie the cake is a lie thec ak ei sal ie thec ak ei sal ie the thec ak ei sal ie ak thec ak ei sal ie the cake is a lie thec ak ei sal ie thec ak ei sal ie the cake is a lie sal the cake is a lie thec ak ei sal ie the cake is a lie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie the cake is a lie sal the cake is a lie the cake is a lie lie ak thec ak ei sal ie lie the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie the cake is a lie the cake is a lie thec ak ei sal ie the cake is a lie thec ak ei sal ie thec ak ei sal ie the cake is a lie ak the cake is a lie the cake is a lie the cake is a lie the cake is a lie the cake is a lie ei thec ak ei sal ie the cake is a lie ei thec ak ei sal ie thec ak ei sal ie the cake is a lie the cake is a lie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie the cake is a lie ie the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie is thec ak ei sal ie the cake is a lie is cake ak the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie ak cake the cake is a lie thec ie ie thec the cake is a lie the cake is a lie thec ak ei sal ie the cake is a lie the cake is a lie ei thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie a the cake is a lie thec ak ei sal ie thec ak ei sal ie the cake is a lie the cake is a lie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie the cake is a lie the cake is a lie ei the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie a cake the cake is a lie thec ak ei sal ie sal thec ak ei sal ie the cake is a lie thec ak ei sal ie thec ak ei sal ie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie ak thec ak ei sal ie the cake is a lie thec ak ei sal ie the cake is a lie the cake is a lie the cake is a lie thec ak ei sal ie the cake is a lie the cake is a lie thec ak ei sal ie" }
            };
    }
}
