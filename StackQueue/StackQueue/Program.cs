namespace StackQueue;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    public static string ConvertToPostfix(string infix)
    {
        if (string.IsNullOrEmpty(infix))
            throw new ArgumentException("Infix expression cannot be null or empty.");

        Stack<char> operators = new Stack<char>();
        List<string> postfix = new List<string>();

        for (int i = 0; i < infix.Length; i++)
        {
            char c = infix[i];

            // Skip whitespace
            if (char.IsWhiteSpace(c))
                continue;

            // If the character is an operand (number or letter), add it to the output
            if (char.IsLetterOrDigit(c))
            {
                string operand = c.ToString();
                // Handle multi-digit numbers or variables
                while (i + 1 < infix.Length && char.IsLetterOrDigit(infix[i + 1]))
                {
                    operand += infix[++i];
                }
                postfix.Add(operand);
            }
            // If the character is '(', push it onto the stack
            else if (c == '(')
            {
                operators.Push(c);
            }
            // If the character is ')', pop from the stack to output until '(' is encountered
            else if (c == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    postfix.Add(operators.Pop().ToString());
                }
                if (operators.Count == 0 || operators.Peek() != '(')
                    throw new ArgumentException("Mismatched parentheses in the infix expression.");
                operators.Pop(); // Remove '('
            }
            // If the character is an operator
            else if (IsOperator(c))
            {
                while (operators.Count > 0 && Precedence(c) <= Precedence(operators.Peek()))
                {
                    postfix.Add(operators.Pop().ToString());
                }
                operators.Push(c);
            }
            else
            {
                throw new ArgumentException($"Invalid character '{c}' in the infix expression.");
            }
        }

        // Pop any remaining operators onto the output
        while (operators.Count > 0)
        {
            if (operators.Peek() == '(' || operators.Peek() == ')')
                throw new ArgumentException("Mismatched parentheses in the infix expression.");
            postfix.Add(operators.Pop().ToString());
        }

        return string.Join(" ", postfix);
    }

    private static bool IsOperator(char c)
    {
        return c == '+' || c == '-' || c == '*' || c == '/';
    }

    private static int Precedence(char op)
    {
        return op == '+' || op == '-' ? 1 : (op == '*' || op == '/' ? 2 : 0);
    }

    private static int EvaluatePostfix(string postfix)
    {
        Stack<int> operands = new();

        for (int i = 0; i < postfix.Length; i++) 
        {
            if (char.IsWhiteSpace(postfix[i])) continue;

            if (char.IsDigit(postfix[i]))
            {
                string operand = "";
                while (i < postfix.Length && char.IsDigit(postfix[i]))
                {
                    operand += postfix[i++];
                }
                i--; // Step back to adjust for the loop's increment
                operands.Push(int.Parse(operand));
            }

            if (i < postfix.Length && IsOperator(postfix[i]))
            {
                int right = operands.Pop();
                int left = operands.Pop();
                int res = postfix[i] switch
                {
                    '+' => left + right,
                    '-' => left - right,
                    '*' => left * right,
                    '/' => left / right,
                    _ => throw new ArgumentException("Invalid expression")
                };
                operands.Push(res);
            }
        }

        return operands.Pop();
    }

    public static bool CheckHtmlFile(string htmlContent)
    {
        if (string.IsNullOrEmpty(htmlContent))
            throw new ArgumentException("HTML content cannot be null or empty.");

        Stack<string> tagStack = new Stack<string>();

        // Regular expression to find HTML tags
        Regex tagRegex = new Regex("<(/?\\w+)[^>]*>");

        MatchCollection matches = tagRegex.Matches(htmlContent);

        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;

            if (tag.StartsWith("/")) // Closing tag
            {
                string expectedTag = tag.TrimStart('/');
                if (tagStack.Count == 0 || tagStack.Pop() != expectedTag)
                {
                    Console.WriteLine($"Mismatched or unclosed tag: {tag}");
                    return false;
                }
            }
            else // Opening tag
            {
                tagStack.Push(tag);
            }
        }

        // Check if there are unclosed tags remaining
        if (tagStack.Count > 0)
        {
            Console.WriteLine("Unclosed tags: " + string.Join(", ", tagStack));
            return false;
        }

        Console.WriteLine("HTML is valid.");
        return true;
    }


    public static void Main(string[] args)
    {
        Console.WriteLine("Enter an infix expression:");
        string infix = Console.ReadLine();

        try
        {
            string postfix = ConvertToPostfix(infix);
            int res = EvaluatePostfix(postfix);
            Console.WriteLine($"Postfix Expression: {postfix}");
            Console.WriteLine(res);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Enter HTML content:");
        string htmlContent = Console.ReadLine();

        try
        {
            bool isValid = CheckHtmlFile(htmlContent);
            Console.WriteLine(isValid ? "No errors found in HTML." : "Errors found in HTML.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}