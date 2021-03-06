﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using LIC.Tokenization;

namespace LIC_Compiler_test.TokenizationTests
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void TestNumber_0_Integer()
        {
            var code = "1234567890";
            TestNumber(code, TokenSubType.Integer);
        }

        [TestMethod]
        public void TestNumber_1_Decimal()
        {
            var code = "12345.67890";
            TestNumber(code, TokenSubType.Decimal);
        }

        private static void TestNumber(string code, TokenSubType targetType)
        {
            var tokenizer = new Tokenizer(code, new TokenizerOptions());

            Assert.IsTrue(
                TokenizationTestUtils.Match(
                    tokenizer.GetNextToken(),
                    new Token(
                        0, code, 0, 0,
                        Tokenizer.State.Context.Global,
                        TokenType.Number, targetType
                    )
                ),
                $"Should tokenize number '{code}' and classify it as '{targetType.ToString()}'"
            );
            TokenizationTestUtils.TestEOF(tokenizer);
        }
    }
}
