﻿namespace LIC.Parsing.ContextParsers
{
    public static class ExpressionParser
    {
        public static Node Parse(Parser.State state)
        {
            state.GetNextNEToken();
            return null;
        }
    }
}
