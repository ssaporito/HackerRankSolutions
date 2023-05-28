using HackerRankSolutions.BiggerIsGreater;
using HackerRankSolutions.ClimbingTheLeaderboard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutionsTest
{
    public class BiggerIsGreaterTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(string input, string expectedString)
        {
            var cases = ReadInput(input);
            var expectedResults = StringToResult(expectedString);
            Assert.Multiple(() =>
            {
                for(int i = 0; i < cases.Count; i++)
                {
                    string w = cases[i];
                    var actualResult = BiggerIsGreater.FindNextBiggestString(w);
                    Assert.Equal(expectedResults[i], actualResult);
                }
            });
        }

        public static List<string> ReadInput(string input)
        {
            var lines = input.Split("\r\n");
            return lines.Skip(1).ToList();
        }

        public static List<string> StringToResult(string resultString)
        {
            return resultString.Split("\r\n").ToList();
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "5\r\nab\r\nbb\r\nhefg\r\ndhck\r\ndkhc", "ba\r\nno answer\r\nhegf\r\ndhkc\r\nhcdk" },
                new object[] { "48\r\nzedawdvyyfumwpupuinbdbfndyehircmylbaowuptgmw\r\nzyyxwwtrrnmlggfeb\r\nocsmerkgidvddsazqxjbqlrrxcotrnfvtnlutlfcafdlwiismslaytqdbvlmcpapfbmzxmftrkkqvkpflxpezzapllerxyzlcf\r\nbiehzcmjckznhwrfgglverxsezxuqpj\r\nrebjvsszebhehuojrkkhszxltyqfdvayusylgmgkdivzlpmmtvbsavxvydldmsym\r\nunpzhmbgrrs\r\njprfovzkdlmdcesdcpdchcwoedjchcovklhrhlzfeeptoewcqpxg\r\nywsfmynmiylcjgrfrrmtyeeykffzkuphpajndwxjteyjba\r\ndkuashjzsdq\r\ngwakhcpkolybihkmxyecrdhsvycjrljajlmlqgpcnmvvkjlkvdowzdfikh\r\nnebsajjbbuifimjpdcqfygeitief\r\nqetpicxagjkydehfnvfxrtigljlheulcsfidjjozbsnomygqbcmpffwswptbgkzrbgqwnczrcfynjmhebfbgseuhckbtuynvbo\r\nxuqfobndhsnsztifmqpnencxkllnpmbfqihtgdgxjhsvitlgtodhcydfb\r\nxqdwkjpkmrvkfnztozzlqtuxzxyxwowf\r\nyewluyxiwiprnajrtkeilolkmqidazhiar\r\nzzyyxxxxxwwwwwvvvvutttttsssssrrrrqqqppponnnnmmmmllkkjjjjiiggffffffeedddddbbbbbba\r\nhlvpzsfwnzsazeyaxaczkkrstiilkldupsqmzjnnsyoao\r\nzxvuutttrrrpoookiihhgggfdca\r\nzzyxxxxwwwvvuuuutsrrrrrqppppoooonnnnnnmmmlllllkkkjjjihgeeedddddcbaaa\r\njnmvvaybncmoazujefictednlyjuhonfchvpqfelbwc\r\nmqyvczrlabtesyeiteblqklfhkchcryggkewpsfxsumvsjerssbltntydzwrjvf\r\npzxgfnsapnchz\r\nerwidqokyjfpctpfxuojyloafghxgifdvhcmzjogoqoikjhjngbhfetvtraaojkfqvyujbhdizrkvqmfpzbidysbkhvuebtr\r\nxywhpljspfeiznzisvukwcaizeqwgavokqwxkrotsgchxdupsumgcynfrpcjsylnrzgxdfkctcrkcnvkxgtmiabghcorgnxak\r\nywghcadvjurpjgwgfyis\r\npqommldkafmnwzidydgjghxcbnwyjdxpvmkztdfmcxlkargafjzeye\r\nvictjarfqkynoavgmhtpzbpcrblzyrzyxjrjlwjxmxdslsubyqdcqcdoenufzxqlty\r\ntlxqigvjmfuxku\r\ncryrpwccrnspwnruubekqkjmrkvwoohzvkctejwvkqfarqgbjzbggyxmecpshgccclykjd\r\njhrmxpdfhjjubrycaurjjwvkasfyxjkf\r\nacs\r\naeukmuqpwyrrdkoptlawlpxknjhdnzlzrgfzliojgopwvwafzxyiwevsxwmwlxycppmjlpxafdnpioezfdkyafryx\r\nzvtronmlkkihc\r\nzzzyyyyxxxxwwwwwvvuuuuuuuttttsssrrrqqqqpppooooonnnnmmmllkjjjjiiiiihhhgggfeeeddcccbbbaa\r\nzzyyxxxwwwwvvvvuuuutrrqqqqppoooonnmmllkkkjjjiihhhggfffeeebbbbbbbbb\r\ndinodxkbrsipxfznzevrpbgtrrfbbfdaksagnus\r\nsykgwoyzypukuditxxltlunmbznk\r\nzzyyyxxxxxwwwwvuuuuttttssrrrrpppponnnmmmmlllllkkkkjjjiiiiiiggfffffeeeddccbbba\r\nspceooivwyzjfbejljaizdvrdkeipvetcxvzmkmwuuqdndwuhxdmrmitzsgjcipanobhxphdactouymkyo\r\niekgvftshvqkkbbxrhhgypngmekykkshhmphfjhcflfknwcxqrearjzsfpryvtahsjawpdufwuqroyckgnph\r\njwzgvwcljudksghspryqrbjaylokhccptiligqndzswxqtafrunwflkgfrhgkadp\r\njvbodrobnjihwpnvlyxlixtmska\r\nmllfsvfzllbloukxtonftmlmioqdsdxstdzmyamnut\r\nmexyunrrcglszqwzatguscgvukuyenogubuwwiavudhvzbpgwjwxazvdzfgumudbgtaubmxyqrzbeagjrthedvvmrngxlilczov\r\nshsdzboibebzlfluhgkypbppkxvtgfm\r\nwvokkqbmgbnwrbdlzwqfanzxtwiqasxgqnwvrlhwnhlhbkxx\r\nnennccrmeeflwmpqfvgtiapirdbjjqozvtbrmixnonbhddgxtxp\r\nwffbownokzqkxgobgxclscwbsgeaxbozfcftxiugiahpufilwuhdmugsotdzatvdvuhqum", "zedawdvyyfumwpupuinbdbfndyehircmylbaowuptgwm\r\nno answer\r\nocsmerkgidvddsazqxjbqlrrxcotrnfvtnlutlfcafdlwiismslaytqdbvlmcpapfbmzxmftrkkqvkpflxpezzapllerxyzlfc\r\nbiehzcmjckznhwrfgglverxsjepquxz\r\nrebjvsszebhehuojrkkhszxltyqfdvayusylgmgkdivzlpmmtvbsavxvydldmyms\r\nunpzhmbgrsr\r\njprfovzkdlmdcesdcpdchcwoedjchcovklhrhlzfeeptoewcqxgp\r\nywsfmynmiylcjgrfrrmtyeeykffzkuphpajndwxjtjabey\r\ndkuashjzsqd\r\ngwakhcpkolybihkmxyecrdhsvycjrljajlmlqgpcnmvvkjlkvdowzdfkhi\r\nnebsajjbbuifimjpdcqfygeitife\r\nqetpicxagjkydehfnvfxrtigljlheulcsfidjjozbsnomygqbcmpffwswptbgkzrbgqwnczrcfynjmhebfbgseuhckbtuynvob\r\nxuqfobndhsnsztifmqpnencxkllnpmbfqihtgdgxjhsvitlgtodhcyfbd\r\nxqdwkjpkmrvkfnztozzlqtuxzxyxwwfo\r\nyewluyxiwiprnajrtkeilolkmqidazhira\r\nno answer\r\nhlvpzsfwnzsazeyaxaczkkrstiilkldupsqmzjnnsyooa\r\nno answer\r\nno answer\r\njnmvvaybncmoazujefictednlyjuhonfchvpqfelcbw\r\nmqyvczrlabtesyeiteblqklfhkchcryggkewpsfxsumvsjerssbltntydzwrvfj\r\npzxgfnsapnczh\r\nerwidqokyjfpctpfxuojyloafghxgifdvhcmzjogoqoikjhjngbhfetvtraaojkfqvyujbhdizrkvqmfpzbidysbkhvuerbt\r\nxywhpljspfeiznzisvukwcaizeqwgavokqwxkrotsgchxdupsumgcynfrpcjsylnrzgxdfkctcrkcnvkxgtmiabghcorgnxka\r\nywghcadvjurpjgwgfysi\r\npqommldkafmnwzidydgjghxcbnwyjdxpvmkztdfmcxlkargafjzyee\r\nvictjarfqkynoavgmhtpzbpcrblzyrzyxjrjlwjxmxdslsubyqdcqcdoenufzxqlyt\r\ntlxqigvjmfuxuk\r\ncryrpwccrnspwnruubekqkjmrkvwoohzvkctejwvkqfarqgbjzbggyxmecpshgcccydjkl\r\njhrmxpdfhjjubrycaurjjwvkasfyxkfj\r\nasc\r\naeukmuqpwyrrdkoptlawlpxknjhdnzlzrgfzliojgopwvwafzxyiwevsxwmwlxycppmjlpxafdnpioezfdkyafxry\r\nno answer\r\nno answer\r\nno answer\r\ndinodxkbrsipxfznzevrpbgtrrfbbfdaksagsnu\r\nsykgwoyzypukuditxxltlunmkbnz\r\nno answer\r\nspceooivwyzjfbejljaizdvrdkeipvetcxvzmkmwuuqdndwuhxdmrmitzsgjcipanobhxphdactouymoky\r\niekgvftshvqkkbbxrhhgypngmekykkshhmphfjhcflfknwcxqrearjzsfpryvtahsjawpdufwuqroyckgphn\r\njwzgvwcljudksghspryqrbjaylokhccptiligqndzswxqtafrunwflkgfrhgkapd\r\njvbodrobnjihwpnvlyxlixtsakm\r\nmllfsvfzllbloukxtonftmlmioqdsdxstdzmyamtnu\r\nmexyunrrcglszqwzatguscgvukuyenogubuwwiavudhvzbpgwjwxazvdzfgumudbgtaubmxyqrzbeagjrthedvvmrngxlilczvo\r\nshsdzboibebzlfluhgkypbppkxvtgmf\r\nwvokkqbmgbnwrbdlzwqfanzxtwiqasxgqnwvrlhwnhlhbxkx\r\nnennccrmeeflwmpqfvgtiapirdbjjqozvtbrmixnonbhddgxxpt\r\nwffbownokzqkxgobgxclscwbsgeaxbozfcftxiugiahpufilwuhdmugsotdzatvdvuhumq" },
            };
    }
}
