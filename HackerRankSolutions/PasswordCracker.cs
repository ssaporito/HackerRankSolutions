using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.PasswordCracker
{
    public class PasswordCracker
    {
        private static readonly string _errorString = "WRONG PASSWORD";
        private static Dictionary<string, string> _memo;
        public static string CrackPassword(List<string> passwords, string loginAttempt)
        {
            _memo = new();
            var passwordsTrie = new Trie(passwords.ToArray());
            string result = CrackPasswordRecurse(passwordsTrie, loginAttempt);
            return result;
        }

        private static string CrackPasswordRecurse(Trie passwordsTrie, string loginAttempt)
        {
            if (_memo.ContainsKey(loginAttempt))
                return _memo[loginAttempt];

            if (passwordsTrie.Contains(loginAttempt))
                return _memo[loginAttempt] = loginAttempt;

            int smallestLength = passwordsTrie.SmallestWord.Length;
            if (loginAttempt.Length < smallestLength)
                return _memo[loginAttempt] = _errorString;

            string smallestPossibility = loginAttempt[..smallestLength];
            var replaceableWords = passwordsTrie.GetStartingWith(smallestPossibility, loginAttempt.Length);
            if (!replaceableWords.Any())
                return _memo[loginAttempt] = _errorString;

            foreach (var word in replaceableWords)
            {
                if (loginAttempt.StartsWith(word))
                {
                    string replacedLoginAttempt = loginAttempt[word.Length..];
                    string crackAttempt = CrackPasswordRecurse(passwordsTrie, replacedLoginAttempt);
                    if (crackAttempt != _errorString)
                    {
                        string result = word + " " + crackAttempt;
                        return _memo[loginAttempt] = result;
                    }
                }
            }

            return _memo[loginAttempt] = _errorString;
        }

        private class Trie
        {
            private class Node
            {
                public bool Terminal { get; set; }
                public Dictionary<char, Node> Nodes { get; private set; }
                public Node ParentNode { get; private set; }
                public char C { get; private set; }

                public string Word
                {
                    get
                    {
                        var b = new StringBuilder();
                        b.Insert(0, C.ToString(CultureInfo.InvariantCulture));
                        var selectedNode = ParentNode;
                        while (selectedNode != null)
                        {
                            b.Insert(0, selectedNode.C.ToString(CultureInfo.InvariantCulture));
                            selectedNode = selectedNode.ParentNode;
                        }
                        return b.ToString();
                    }
                }

                public Node(Node parent, char c)
                {
                    C = c;
                    ParentNode = parent;
                    Terminal = false;
                    Nodes = new Dictionary<char, Node>();
                }

                public IEnumerable<Node> TerminalNodes(char? ignoreChar = null)
                {
                    var r = new List<Node>();
                    if (Terminal) r.Add(this);
                    foreach (var node in Nodes.Values)
                    {
                        if (ignoreChar != null && node.C == ignoreChar) continue;
                        r = r.Concat(node.TerminalNodes()).ToList();
                    }
                    return r;
                }
            }

            private Node TopNode_ { get; set; }
            private Node TopNode
            {
                get
                {
                    if (TopNode_ == null) TopNode_ = new Node(null, ' ');
                    return TopNode_;
                }
            }

            public string SmallestWord { get; set; }

            public Trie(IEnumerable<string> words)
            {
                foreach (var word in words)
                {
                    AddWord(word);
                }
            }

            public void AddWord(string word)
            {
                word = NormaliseWord(word);
                var selectedNode = TopNode;

                for (var i = 0; i < word.Length; i++)
                {
                    var c = word[i];
                    if (!selectedNode.Nodes.ContainsKey(c))
                    {
                        selectedNode.Nodes.Add(c, new Node(selectedNode, c));
                    }
                    selectedNode = selectedNode.Nodes[c];
                }
                selectedNode.Terminal = true;
                if (SmallestWord == null || word.Length < SmallestWord.Length)
                    SmallestWord = word;

            }

            private string NormaliseWord(string word)
            {
                if (string.IsNullOrWhiteSpace(word)) word = string.Empty;
                word = word.Trim();
                return word;
            }

            public bool Contains(string word)
            {
                word = NormaliseWord(word);
                if (string.IsNullOrWhiteSpace(word)) return false;
                var selectedNode = TopNode;
                foreach (var c in word)
                {
                    if (!selectedNode.Nodes.ContainsKey(c)) return false;
                    selectedNode = selectedNode.Nodes[c];
                }
                return selectedNode.Terminal;
            }

            public List<string> GetStartingWith(string wordStart, int maxLength = int.MaxValue)
            {
                wordStart = NormaliseWord(wordStart);
                var selectedNode = TopNode;
                foreach (var c in wordStart)
                {
                    // Nothing starting with this word
                    if (!selectedNode.Nodes.ContainsKey(c)) return new List<string>();
                    selectedNode = selectedNode.Nodes[c];
                }

                var terminalWords = selectedNode.TerminalNodes().Select(n => NormaliseWord(n.Word)).Where(w => w.Length <= maxLength).ToList();
                return terminalWords;
            }
        }

        public static void SolveInput()
        {
            List<string> passwords = Console.ReadLine().TrimEnd().Split(' ').ToList();

            string loginAttempt = Console.ReadLine();

            string result = CrackPassword(passwords, loginAttempt);

            Console.WriteLine(result);
        }
    }   
}
