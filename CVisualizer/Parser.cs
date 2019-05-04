using System.Linq;
using System.Text.RegularExpressions;

namespace CVisualizer
{
    public class Parser
    {
        public Parser()
        {
        }

        public Node ParseExpression(string s)
        {
            s = TranslateExpression(s);
            Regex r = new Regex("^[\\^.,()*/\\-+scel!nrpx0-9 ]*$");
            if (!r.IsMatch(s)) throw new InvalidCharacterException();
            int leftBracketsCount = s.Count(x => x == '(');
            int rightBracketsCount = s.Count(x => x == ')');
            if (leftBracketsCount != rightBracketsCount) throw new MissingBracketException();
            s = s.Replace(" ", string.Empty);
            if (s.Length > 0)
            {
                if (s.Length == 1)
                {
                    if (!char.IsNumber(s[0]) && s != "x") throw new InvalidExpressionException();
                }
                return Parse(ref s);
            }
            return null;
        }

        private string TranslateExpression(string s)
        {
            s = s.ToLower();
            s = s.Replace("sin", "s");
            s = s.Replace("cos", "c");
            s = s.Replace("tg", "t");
            s = s.Replace("tan", "t");
            s = s.Replace("ctg", "ct");
            s = s.Replace("cotg", "ct");
            s = s.Replace("ln", "l");
            s = s.Replace("exp", "e");
            s = s.Replace("pi", "p");
            return s;
        }

        private Node Parse(ref string s)
        {
            Node a;
            Node b;
            char op = ' ';
            if (s[0] == '+' || s[0] == '-' || s[0] == '*' || s[0] == '/' || s[0] == '^')
            {
                op = s[0];
                s = s.Substring(1);
                SkipCharacter(ref s, '(');
                a = Parse(ref s);
                SkipCharacter(ref s, ',');
                b = Parse(ref s);
                SkipCharacter(ref s, ')');
                if (op == '+') return new PlusSign(a, b);
                else if (op == '-') return new MinusSign(a, b);
                else if (op == '*') return new MultiplicationSign(a, b);
                else if (op == '/') return new DivisionSign(a, b);
                else return new CaretSign(a, b);
            }
            else if (s[0] == 's' || s[0] == 'c' || s[0] == 'e' || s[0] == 'l' || s[0] == '!')
            {
                op = s[0];
                s = s.Substring(1);
                SkipCharacter(ref s, '(');
                a = Parse(ref s);
                SkipCharacter(ref s, ')');
                if (op == 's') return new SineFunction(a);
                else if (op == 'c') return new CosineFunction(a);
                else if (op == 'e') return new ExponentialFunction(a);
                else if (op == 'l') return new LogarithmFunction(a);
                else return new FactorialFunction(a);
            }
            else if (s[0] == 'n' || s[0] == 'r')
            {
                op = s[0];
                s = s.Substring(1);
                SkipCharacter(ref s, '(');
                string tempS = s.Split(')')[0];
                tempS = tempS.Replace(',', '.');
                if (op == 'n')
                {
                    if (tempS.Contains('.') || tempS.Contains('-')) throw new IsNotValidNaturalNumberException();
                }
                s = s.Substring(s.IndexOf(')') + 1);
                if (op == 'n') return new NaturalNumberNode(int.Parse(tempS));
                else return new RationalNumberNode(float.Parse(tempS));
            }
            else if (s[0] == 'p')
            {
                s = s.Substring(1);
                return new PiNode();
            }
            else if (s[0] == 'x')
            {
                s = s.Substring(1);
                return new VariableNode();
            }
            else if (char.IsDigit(s[0]))
            {
                string number = s[0].ToString();
                s = s.Substring(1);
                while (s.Length > 0)
                {
                    if (!char.IsDigit(s[0])) break;
                    number += s[0];
                    s = s.Substring(1);
                }
                a = new NaturalNumberNode(int.Parse(number));
                return a;
            }
            throw new InvalidExpressionException();
        }

        private void SkipCharacter(ref string s, char c)
        {
            if (s[0] != c)
            {
                switch (c)
                {
                    case '(':
                        //throw new LeftBracketExpectedException();
                        break;
                    case ',':
                        throw new SeparatorExpectedException();
                    case ')':
                        //throw new RightBracketExpectedException();
                        break;
                }
            }
            s = s.Substring(1);
        }

        //public string Validate(string s)
        //{
        //    char[] whiteList = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '(', ')', ',', '^', '.', 'n', 'r', 's', 'c', 'e', 'l', '!', 'p', 'x' };
        //    if (!whiteList.Contains(s[0])) throw new InvalidCharacterException();
        //    else if ((s[0] == '+' || s[0] == '-') && !char.IsNumber(s[1]) && s[1] != '(') throw new LeftBracketExpectedException();
        //    else if (((s[0] == '*' || s[0] == '/' || s[0] == '^' || s[0] == 'n' || s[0] == 'r' || s[0] == 's' || s[0] == 'c' || s[0] == 'e' || s[0] == 'l' || s[0] == '!')
        //        && s[1] != '(')) throw new LeftBracketExpectedException();
        //    else if (s[0] == ',' || s[0] == '(' || s[0] == ')')
        //    {
        //        if (s[0] == '(' && (s[1] == ',' || s[1] == ')')) throw new OperandExpectedException();
        //        if (s[1] == '(') throw new OperandExpectedException();
        //    }
        //    else if (char.IsNumber(s[0]) || s[0] == 'x')
        //    {
        //        if (s[0] == 'x' && s[1] != ')' && s[1] != ',') throw new InvalidExpressionException();
        //        if (s[1] == '(' || s[1] == '+' || s[1] == '-' || s[1] == '*' || s[1] == '/' || s[1] == '^'
        //            || s[1] == 's' || s[1] == 'c' || s[1] == 'e' || s[1] == 'l' || s[0] == '!') throw new UnexpectedEndOfNumberException();
        //    }
        //    else if (s[0] == '.' && !char.IsNumber(s[1])) throw new UnexpectedEndOfNumberException();
        //    else if (s[0] == 'n' || s[0] == 'r' || s[0] == 's' || s[0] == 'c' || s[0] == 'e' || s[0] == 'l' || s[0] == '!')
        //    {
        //        if (s[0] == 'n')
        //        {
        //            string tempS = s.Split('(', ')')[1];
        //            if (tempS.Contains('.')) throw new IsNotValidNaturalNumberException();
        //        }
        //        string temp = s.Split('(', ')')[1];
        //        if (temp.Contains(',')) throw new OnlyOneParameterExpectedException();
        //    }
        //    return Validate(s.Substring(1));
        //}

        //public void Parse(string s)
        //{
        //    int leftBracketsCount = s.Count(x => x == '(');
        //    int rightBracketsCount = s.Count(x => x == ')');
        //    if (leftBracketsCount != rightBracketsCount) throw new MissingBracketException();
        //    s = s.Replace(" ", string.Empty);
        //    if(s.Length > 0)
        //    {
        //        if (s.Length == 1)
        //        {
        //            if (!char.IsNumber(s[0]) && s != "x") throw new InvalidExpressionException();
        //        }
        //        else ParseByChar(s);
        //    }
        //}
        //private void ParseByChar(string s)
        //{
        //    while (s.Length > 1)
        //    {
        //        s = SkipCharacter(ref s);
        //    }
        //}
        //private string SkipCharacter(ref string s)
        //{
        //    char[] whiteList = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '(', ')', ',', '^', '.', 'n', 'r', 's', 'c', 'e', 'l', '!', 'p', 'x' };
        //    if (!whiteList.Contains(s[0])) throw new InvalidCharacterException();
        //    else if ((s[0] == '+' || s[0] == '-') && !char.IsNumber(s[1]) && s[1] != '(') throw new LeftBracketExpectedException();
        //    else if (((s[0] == '*' || s[0] == '/' || s[0] == '^' || s[0] == 'n' || s[0] == 'r' || s[0] == 's' || s[0] == 'c' || s[0] == 'e' || s[0] == 'l' || s[0] == '!')
        //        && s[1] != '(')) throw new LeftBracketExpectedException();
        //    else if (s[0] == ',' || s[0] == '(' || s[0] == ')')
        //    {
        //        if (s[0] == '(' && (s[1] == ',' || s[1] == ')')) throw new OperandExpectedException();
        //        if (s[1] == '(') throw new OperandExpectedException();
        //    }
        //    else if (char.IsNumber(s[0]) || s[0] == 'x')
        //    {
        //        if (s[0] == 'x' && s[1] != ')' && s[1] != ',') throw new InvalidExpressionException();
        //        if (s[1] == '(' || s[1] == '+' || s[1] == '-' || s[1] == '*' || s[1] == '/' || s[1] == '^'
        //            || s[1] == 's' || s[1] == 'c' || s[1] == 'e' || s[1] == 'l' || s[0] == '!') throw new UnexpectedEndOfNumberException();
        //    }
        //    else if (s[0] == '.' && !char.IsNumber(s[1])) throw new UnexpectedEndOfNumberException();
        //    else if (s[0] == 'n' || s[0] == 'r' || s[0] == 's' || s[0] == 'c' || s[0] == 'e' || s[0] == 'l' || s[0] == '!')
        //    {
        //        if (s[0] == 'n')
        //        {
        //            string tempS = s.Split('(', ')')[1];
        //            if (tempS.Contains('.')) throw new IsNotValidNaturalNumberException();
        //        }
        //        string temp = s.Split('(', ')')[1];
        //        if (temp.Contains(',')) throw new OnlyOneParameterExpectedException();
        //    }
        //    return s.Substring(1);
        //}
    }
}
