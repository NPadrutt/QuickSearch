using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuickSearch.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void QuickSearch_PatternMatch()
        {
            var pattern = "abac";
            var text = "asfdasdföjnaögnabacwiwerölewanrö";
            int expected = text.IndexOf(pattern);

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_PatternMatchStart()
        {
            var pattern = "abac";
            var text = "abacasfdasdföjnaögnaacwiwerölewanrö";
            int expected = text.IndexOf(pattern);

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_PatternMatchEnd()
        {
            var pattern = "abac";
            var text = "asfdasdföjnaögnabawiwerölewanröabac";
            int expected = text.IndexOf(pattern);

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_PatternNotMatch()
        {
            var pattern = "abac";
            var text = "asfdasdföjnaögnaacwiwerölewanrö";
            int expected = text.IndexOf(pattern);

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_PatternLargerText()
        {
            var pattern = "asfdasdföjnaögnaacwiwerölewanrö";
            var text = "abac";
            int expected = text.IndexOf(pattern);

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_EmptyText()
        {
            var pattern = "abac";
            var text = String.Empty;
            int expected = text.IndexOf(pattern);

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_EmptyPattern()
        {
            var pattern = String.Empty;
            var text = "asfdasdföjnaögnaacwiwerölewanrö";
            int expected = -1;

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_EmptyPatternAndText()
        {
            var pattern = String.Empty;
            var text = String.Empty;
            int expected = -1;

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QuickSearch_PatternMatch_SpecialChars()
        {
            var pattern = "ﻈﻲﻧﺫ﴿";
            var text = "ﺝﺝﷴﺠ꞉■ﻈﻲﻧﺫ﴿ﺳﺷﺱﯯﻋ₽─∞";
            int expected = text.IndexOf(pattern);

            int actual = Program.DoQuickSearch(pattern, text);
            Assert.AreEqual(expected, actual);
        }
    }
}
