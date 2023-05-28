﻿using HackerRankSolutions.ArithmeticExpressions;
using HackerRankSolutions.GameOfThrones2;

namespace HackerRankSolutionsTest
{
    public class ArithmeticExpressionsTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public static void TestSome(string s)
        {
            var param = ArithmeticExpressions.StringToParam(s);
            string actual = ArithmeticExpressions.arithmeticExpressions(param);
            var value = ArithmeticExpressions.Evaluate(actual);
            Assert.Equal(0, value % 101);
        }

        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { "22 79 21"},
                new object[] { "55 3 45 33 25" },
                new object[] { "100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100" },                
                new object[] { "58 72 69 58 98 85 69 88 61 57 40 11 88 32 44 65 14 69 74 49 14 84 40 19 42 93 8 80 14 63 52 28 66 89 66 78 65 28 78 58 4 7 91 77 99 83 25 37 93 17 27 27 34 71 44 77 2 12 92 61 45 6 30 59 82 88 49 82 21 75 90 65 19 50 67 2 70 73 54 22 81 42 65 93 87 90 96 91 74 20 47 82 2 48 74 80 71 38 89 44 90 18 21 53 6 85 13 55 92 78 9 18 24 15 11 75 8 90 61 77 86 41 27 60 54 60 88 9 19 2 46 9 83 20 21 34 73 35 15 57 31 98 94 73 27 24 93 45 15 15 18 17 98 51 85 25 93 30 44 70 90 90 9 88 92 37 63 3 100 56 77 38 45 96 10 54 90 77 97 24 47 68 97 36 62 89 19 49 69 39 78 36 75 65 30 51 2 81 81 21 44 67 3 69 71 43 97 91 29 6 93 20 91 79 51 91 50 36 76 30 54 19 77 88 94 20 19 89 21 34 98 61 78 40 83 78 99 89 30 76 79 68 44 81 38 51 12 47 72 90 54 45 96 14 10 19 8 8 82 50 12 9 55 67 54 99 73 50 46 65 57 86 48 81 84 18 57 13 58 5 99 65 51 67 27 3 52 57 84 32 45 96 18 26 56 10 36 98 13 75 3 26 78 94 41 45 59 12 87 64 16 67 36 30 8 77 6 45 51 95 85 97 32 98 53 43 40 41 42 80 7 22 31 2 16 15 82 13 78 63 75 58 53 83 64 88 78 38 41 56 76 20 83 9 74 27 1 32 80 8 16 74 35 5 41 24 55 11 43 20 81 5 47 53 8 28 19 49 93 72 56 87 73 52 68 5 28 7 36 17 75 52 47 9 41 27 35 75 100 35 20 21 31 99 38 38 59 58 6 18 42 32 31 57 38 68 84 65 64 96 83 14 35 64 28 20 81 89 20 74 83 67 68 40 73 85 63 89 31 41 7 17 50 48 59 16 40 3 4 88 92 56 100 36 20 64 78 28 32 70 32 30 65 12 52 17 35 77 15 31 58 41 67 12 25 19 87 39 21 86 13 62 87 14 59 2 40 12 15 49 67 46 53 58 75 98 25 99 39 32 45 40 90 39 89 89 99 74 87 54 7 76 98 77 66 68 81 24 23 16 59 76 50 33 8 56 100 4 39 69 97 6 71 62 94 62 55 6 54 55 95 72 66 83 73 67 1 78 25 77 1 49 88 23 73 54 92 9 77 56 75 55 71 51 64 61 25 39 22 15 7 58 56 49 16 33 84 22 5 75 67 65 99 93 43 72 27 70 37 22 67 1 50 96 50 81 82 18 94 4 61 100 79 83 98 5 99 86 11 89 42 39 77 76 31 16 48 15 86 24 78 91 24 64 76 14 77 5 83 40 95 50 46 43 20 23 82 30 65 35 3 99 30 96 62 78 94 32 35 83 2 85 18 27 72 74 34 41 56 4 30 80 57 76 47 59 20 53 66 1 88 39 100 42 69 34 29 23 67 83 91 90 100 8 96 98 7 45 20 92 82 97 64 4 15 15 23 19 30 46 86 80 38 20 92 64 85 24 87 98 97 4 58 7 92 17 10 59 88 83 97 60 34 19 35 24 89 31 87 76 8 54 60 61 44 20 20 88 39 76 60 39 43 22 41 34 62 57 81 73 35 26 16 1 16 23 70 100 57 12 78 40 33 51 69 88 67 62 66 67 21 15 73 53 7 33 43 4 89 69 80 1 10 25 35 71 85 97 32 14 58 68 35 6 12 10 14 78 68 51 95 12 59 47 3 98 98 12 18 37 16 57 21 47 12 6 18 2 27 57 85 47 70 77 1 43 54 81 18 41 20 12 13 41 74 70 41 23 9 21 14 98 37 77 26 34 8 6 44 45 41 80 35 89 95 83 85 29 16 32 56 28 84 54 19 31 36 27 2 63 93 45 71 74 42 82 79 66 2 74 63 62 26 22 44 63 67 45 51 82 66 48 36 67 37 12 38 28 8 75 36 14 52 90 89 8 87 24 19 77 91 13 38 94 28 30 70 40 63 48 69 17 63 43 41 40 7 21 31 51 80 96 56 75 47 45 28 49 75 75 6 3 32 54 70 39 60 83 72 90 31 54 73 48 74 70 67 92 12 67 89 93 67 72 74 92 33 10 72 91 19 20 90 63 15 31 92 11 94 30 27 33 52 13 63 33 51 22 53 15 31 68 49 26 78 20 93 75 53 17 1 49 75 53 80 40 83 17 91 86 86 30 36 68 38 86 15 13 68 32 42 52 22 29 96 93 11 22 4 38 83 79 49 92 8 25 34 45 44 23 94 47 31 19 75 12 86 1 88 11 76 81 45 94 90 60 55 59 65 59 34 34 55 86 23 87 86 65 51 38 94 8 11 97 79 99 75 45 48 91 75 64 1 65 71 4 16 36 22 63 92 6 85 27 57 29 37 74 30 40 27 92 7 4 8 80 27 13 54 30 61 88 6 97 65 27 67 65 99 16 55 1 48 52 30 21 41 17 95 76 18 29 12 2 90 67 6 97 95 32 13 1 30 55 17 9 75 78 44 47 4 54 63 48 99 52 42 57 87 77 15 19 73 12 95 65 15 12 63 55 96 76 84 98 93 19 75 84 54 85 69 74 98 18 92 84 93 21 36 63 100 67 34 90 1 71 65 92 18 2 39 60 16 84 82 43 23 10 8 7 52 69 22 67 46 6 64 55 99 36 45 24 8 1 99 40 66 22 9 65 10 37 34 86 66 79 91 88 98 25 40 59 27 100 98 5 72 41 58 58 14 52 80 76 97 77 3 12 81 31 92 87 8 38 8 80 89 38 5 5 30 68 22 13 14 77 26 59 55 64 58 95 54 73 64 53 22 13 41 30 63 32 94 43 99 49 72 30 46 65 83 45 5 36 75 57 95 16 92 9 89 11 63 65 82 68 12 21 19 98 64 78 63 74 1 68 27 28 7 59 94 58 61 53 28 40 91 15 11 69 19 87 13 10 99 87 34 43 71 70 96 88 58 87 33 37 60 82 82 48 89 92 55 37 32 8 90 17 23 75 98 55 87 35 32 25 71 99 87 77 8 59 54 84 88 95 72 35 86 32 1 49 51 17 79 62 8 16 70 13 20 34 17 99 64 75 2 89 75 21 25 2 64 58 72 43 26 13 37 7 41 14 80 69 2 60 3 83 9 38 96 68 23 68 91 80 36 36 26 66 4 27 58 30 38 8 9 100 82 58 85 29 38 91 83 75 92 7 27 16 10 79 59 42 25 50 47 16 27 59 66 14 79 76 5 84 20 53 15 1 15 62 81 37 4 92 21 75 91 95 3 6 30 8 87 75 24 95 45 2 76 26 66 11 14 42 14 15 80 69 37 68 28 30 80 96 23 55 10 40 21 86 23 81 29 74 12 63 48 1 7 56 74 67 74 70 93 20 77 50 76 3 28 4 12 23 56 1 45 25 49 98 99 60 9 61 11 58 25 61 7 2 57 76 75 55 68 53 72 65 10 6 25 69 51 36 45 87 43 60 85 22 36 70 16 45 61 80 48 27 78 96 8 60 45 82 62 4 28 43 85 28 50 59 70 89 83 2 26 74 11 58 93 26 60 65 10 16 61 1 97 7 68 21 60 55 96 59 53 86 7 58 71 2 61 78 7 65 77 17 70 98 8 46 63 78 27 84 82 1 73 85 49 57 54 100 49 49 28 9 79 41 86 54 98 40 47 21 32 84 9 19 68 55 82 14 73 79 56 80 54 28 24 54 13 37 34 25 50 75 78 43 4 74 90 60 80 77 64 23 22 23 15 59 29 5 96 47 1 62 13 65 87 83 13 28 86 64 24 29 70 97 49 49 4 70 84 56 44 37 14 57 17 27 41 44 35 55 17 54 79 34 89 25 95 1 29 7 16 41 80 2 2 65 1 40 87 48 10 43 66 97 38 4 6 38 73 71 13 25 24 15 15 79 10 49 14 11 33 70 60 35 22 74 85 14 36 49 80 24 49 55 90 9 57 53 53 77 98 74 10 77 14 49 55 15 54 51 91 27 94 73 54 19 70 69 26 49 74 5 70 91 40 79 4 28 7 55 44 62 16 18 25 93 4 69 85 47 56 27 100 46 11 67 3 38 44 67 2 2 76 72 47 39 74 17 12 76 12 11 29 23 75 3 92 62 69 12 21 28 5 72 87 63 98 49 6 48 46 69 41 93 77 66 96 67 80 1 97 65 41 88 10 25 85 55 13 51 1 11 8 37 82 56 24 40 7 41 22 59 31 41 21 59 71 76 68 21 79 28 12 90 24 11 29 71 28 66 90 60 17 58 91 34 11 98 79 44 46 51 7 44 39 59 31 59 21 26 13 12 96 65 12 52 8 70 91 30 69 24 99 69 92 56 17 47 58 14 1 82 22 48 11 60 83 60 93 48 91 5 75 97 83 76 24 67 3 91 46 35 60 3 9 9 16 47 50 22 41 81 64 1 59 32 63 15 23 43 36 90 31 34 70 51 12 73 68 18 39 83 82 80 100 47 1 1 47 50 9 54 64 66 52 13 48 42 5 57 50 82 9 96 12 100 42 60 56 94 92 76 75 15 24 51 66 54 37 65 97 18 52 14 34 68 45 18 40 63 17 25 63 58 60 45 90 73 59 55 86 29 59 24 68 71 17 40 32 75 1 23 98 97 13 97 38 9 55 28 38 64 74 67 68 87 75 46 15 4 17 56 25 53 8 39 53 97 40 32 63 49 66 27 48 63 68 82 68 12 25 20 89 75 93 7 44 87 98 94 22 68 74 19 56 21 61 21 69 91 8 74 7 76 46 72 12 14 36 41 96 100 29 16 16 79 22 94 40 98 31 94 98 15 72 70 20 11 80 6 21 14 75 48 61 66 39 21 52 100 99 99 34 87 92 37 23 93 69 83 56 46 33 64 93 68 83 36 94 8 10 75 81 32 64 71 7 82 53 30 29 97 85 87 95 98 85 100 72 71 28 50 26 86 55 52 73 80 61 30 56 21 90 83 100 52 45 68 57 67 72 14 96 35 79 32 88 30 72 5 10 96 55 79 1 72 89 40 56 25 41 44 99 56 10 63 52 45 73 73 31 5 94 43 87 49 75 45 59 78 25 19 89 29 21 35 35 59 51 83 83 40 45 13 11 57 92 53 56 22 77 62 14 30 83 85 64 84 55 33 72 81 61 81 73 47 90 89 47 77 79 48 96 97 7 1 87 23 61 7 59 23 30 44 10 14 73 1 22 68 12 7 62 94 53 78 6 70 71 29 19 64 25 5 13 4 97 53 83 28 83 7 52 71 34 95 64 85 16 41 24 57 16 58 94 90 22 87 35 12 32 4 83 21 30 10 93 30 55 38 21 17 72 45 65 21 13 68 43 5 77 1 7 58 11 93 25 24 95 21 84 99 42 47 67 60 19 76 99 88 61 12 2 41 90 75 89 64 95 29 68 80 33 54 69 85 64 77 29 5 70 21 26 51 48 13 25 65 80 91 86 97 42 66 15 73 70 94 70 76 42 39 19 44 86 27 3 43 7 51 32 37 10 5 95 54 66 1 95 27 100 85 70 7 68 4 2 41 42 9 88 99 24 71 87 82 55 81 45 17 64 57 28 26 88 89 38 17 30 47 24 65 43 16 2 82 73 38 2 69 67 40 67 91 76 99 61 7 85 18 47 33 62 42 73 55 96 62 12 88 38 14 18 49 2 76 9 52 95 22 71 87 21 89 44 54 49 15 27 1 81 74 100 36 97 88 16 95 83 22 31 15 8 67 93 90 9 32 18 56 3 64 29 85 76 71 23 65 74 73 18 6 75 56 48 41 26 70 25 40 19 71 51 10 97 55 4 48 61 53 9 30 15 71 32 1 14 55 9 66 12 90 23 46 61 19 49 92 38 7 44 95 13 27 3 34 83 83 97 31 16 64 29 92 95 58 49 11 38 38 9 30 82 79 53 29 73 90 79 81 32 45 14 10 88 28 53 88 59 48 84 94 100 2 4 22 44 88 18 96 77 77 49 34 17 29 92 48 50 92 71 13 19 64 55 32 29 42 21 38 63 69 33 37 52 71 44 63 98 37 64 94 18 97 68 38 34 25 75 8 30 85 50 97 44 90 35 31 76 50 31 68 71 86 17 59 93 85 75 44 28 45 74 68 62 16 92 75 30 15 62 29 61 53 14 70 97 95 64 88 89 38 39 40 31 65 11 2 32 39 78 55 51 81 92 93 77 33 39 58 51 61 71 56 95 6 1 96 96 34 8 48 71 16 20 26 97 1 53 91 12 86 41 70 82 38 91 31 1 16 58 25 82 32 10 88 42 57 34 58 25 35 97 13 41 79 4 70 44 81 87 73 7 93 22 86 50 65 62 17 33 90 52 78 52 43 70 26 40 33 92 50 35 49 19 6 87 54 46 6 85 27 23 30 31 15 26 73 19 98 100 44 89 17 78 18 54 75 14 29 65 61 53 9 90 59 59 71 71 74 66 73 26 28 79 63 92 66 70 93 9 26 35 95 45 63 60 47 15 70 83 53 61 19 35 72 80 57 42 58 83 94 9 7 35 80 92 48 58 97 14 19 70 32 14 37 31 41 56 8 91 99 91 92 55 20 65 79 35 29 39 70 27 72 10 43 6 47 67 42 100 39 48 92 73 88 14 6 62 62 21 45 37 93 86 41 91 33 43 87 19 32 32 29 57 52 52 87 98 17 21 31 23 89 3 5 16 79 85 30 57 77 52 61 34 95 30 15 91 12 35 55 57 58 14 56 45 65 75 37 77 55 61 34 33 46 30 17 63 17 78 63 10 73 70 25 86 97 59 17 33 6 83 86 61 48 12 91 43 65 7 93 55 99 67 99 48 99 16 83 38 73 18 61 8 28 99 5 71 65 79 6 39 34 5 7 97 48 65 92 91 57 64 35 52 64 34 72 83 12 88 93 26 66 2 86 74 97 75 16 7 23 25 24 21 84 80 33 98 18 23 17 78 15 97 42 32 27 69 100 81 72 38 44 37 17 12 18 84 26 19 52 61 7 50 77 93 46 87 41 73 83 84 22 32 36 4 58 93 15 72 37 28 86 36 27 92 32 17 48 50 86 78 50 23 79 71 8 95 55 37 81 36 89 59 35 30 71 99 2 50 58 65 45 69 84 8 69 48 5 98 22 9 63 59 23 96 77 13 55 60 5 40 19 4 79 31 4 58 71 20 4 57 73 48 57 93 74 22 23 81 74 74 13 32 12 37 31 83 53 7 98 7 3 84 28 19 46 1 16 62 57 76 81 77 85 29 79 23 45 21 99 61 63 62 6 82 96 40 83 95 99 60 93 91 80 73 2 52 67 85 37 81 11 19 52 62 69 62 59 14 24 16 26 1 76 46 18 77 5 23 54 58 25 44 53 5 65 20 100 75 11 50 38 99 60 44 38 26 18 86 62 12 36 21 10 80 73 50 86 60 98 74 42 90 82 3 80 18 7 22 41 98 18 69 42 90 99 31 43 70 72 88 98 59 16 57 44 48 4 76 63 84 59 32 50 90 35 57 99 52 73 40 5 43 51 58 97 84 2 82 21 51 84 44 64 77 48 64 60 87 96 19 74 32 9 5 69 89 70 51 61 24 74 9 100 13 1 41 14 17 58 16 56 9 55 74 82 20 98 24 84 94 91 10 79 6 24 69 5 48 3 48 44 75 80 84 14 56 95 69 1 75 10 74 72 42 66 15 14 88 89 15 34 55 48 14 13 20 94 88 75 36 85 32 20 44 60 84 89 13 14 45 21 68 16 92 46 71 90 74 9 5 5 49 58 31 25 45 58 62 93 60 22 36 17 15 94 53 98 58 45 8 23 49 12 36 70 3 49 97 83 19 57 41 67 74 85 21 84 56 64 93 83 19 3 91 36 45 94 56 5 7 91 94 87 36 17 10 78 1 41 28 21 23 12 23 94 17 58 38 45 36 39 90 47 84 17 1 6 92 89 23 67 2 19 67 26 29 82 45 54 19 70 64 12 70 64 21 36 11 30 35 76 59 81 72 89 39 47 84 25 40 100 88 10 79 4 40 7 46 93 82 23 4 48 61 80 12 58 100 6 57 34 89 99 17 66 96 44 96 89 24 16 83 18 87 3 69 21 19 25 41 82 83 54 44 7 12 85 80 30 30 11 35 44 76 35 42 49 18 28 82 53 3 63 45 46 13 8 8 67 89 14 88 93 85 57 68 81 23 70 10 87 66 97 99 21 84 86 24 87 6 93 70 82 9 19 59 62 58 60 7 42 44 94 25 41 40 8 20 22 65 21 26 53 52 28 80 9 37 74 76 61 33 3 2 70 24 84 68 63 8 81 5 16 82 83 25 53 25 66 27 91 81 83 65 65 74 5 3 87 50 37 44 84 85 96 45 2 62 18 47 85 29 66 27 100 64 30 59 66 77 36 14 15 66 61 55 62 94 71 36 58 31 100 19 44 23 23 45 39 14 21 92 77 94 74 90 35 50 50 72 27 43 37 75 16 27 85 78 95 85 19 13 62 56 20 37 29 80 17 42 32 57 66 59 9 61 28 54 62 46 78 68 3 7 56 22 24 10 87 12 21 73 24 18 9 38 18 98 46 25 17 92 48 100 23 48 99 17 43 92 90 85 38 34 23 45 67 69 54 4 87 32 71 84 47 92 50 86 27 95 18 12 14 27 14 18 40 79 65 8 57 39 80 90 51 42 79 49 99 74 42 42 6 100 11 81 8 86 80 27 42 60 95 18 92 98 18 62 9 12 3 96 84 56 4 6 57 28 26 5 64 59 51 58 61 27 25 13 65 84 39 36 43 60 52 22 57 31 6 69 65 36 91 7 15 17 51 61 80 50 88 36 52 62 69 47 100 69 66 6 79 62 56 78 75 28 82 83 22 42 69 67 34 24 73 31 75 77 45 41 29 89 60 79 31 22 47 100 51 64 96 36 68 41 93 96 68 23 78 45 1 9 21 42 93 14 33 98 30 17 22 19 75 2 45 74 94 74 97 17 99 38 36 8 31 58 61 97 39 83 9 97 19 41 36 66 50 83 13 15 38 79 17 8 70 60 71 13 2 24 87 87 43 93 77 6 8 7 23 13 6 2 20 55 2 63 73 93 53 53 9 20 70 24 17 24 39 65 84 82 76 84 46 63 9 89 81 91 66 20 78 17 39 5 47 18 22 60 37 23 85 29 85 58 48 91 78 36 25 30 99 99 92 90 71 48 68 83 46 16 33 55 82 26 97 60 6 17 55 55 14 38 2 50 1 99 65 48 69 21 90 42 37 70 30 37 55 99 68 39 88 45 62 49 89 57 36 31 67 35 10 43 96 17 10 53 71 14 49 31 89 4 29 15 84 1 22 94 10 80 5 35 59 66 32 83 42 17 5 97 19 47 46 33 11 29 52 45 67 5 25 54 23 58 65 9 30 5 42 90 24 86 78 14 20 67 9 71 31 45 84 94 6 81 39 72 92 21 70 99 59 1 62 21 7 66 80 54 92 91 47 6 51 99 91 12 64 50 19 47 54 35 66 78 83 99 10 15 1 54 68 50 16 87 46 82 64 46 92 61 49 46 83 67 87 74 92 96 87 32 19 59 7 69 68 96 72 36 67 68 35 39 47 80 23 41 34 66 18 42 84 47 12 75 93 64 13 66 48 46 73 96 50 76 1 11 12 11 30 71 73 72 1 76 99 42 25 86 19 80 42 3 89 86 47 94 51 76 23 50 78 9 56 92 33 33 27 100 66 73 92 86 12 4 94 33 15 48 77 74 87 100 95 3 49 84 25 76 83 10 38 69 91 22 69 38 95 24 3 40 45 40 40 91 48 31 87 80 29 81 69 96 22 6 68 57 82 90 80 37 13 66 57 51 13 60 49 70 80 69 42 43 35 27 84 90 79 23 66 45 28 64 24 85 12 6 81 79 72 79 13 49 59 69 67 63 77 49 20 98 55 39 60 67 51 16 21 14 52 27 25 91 19 70 69 88 28 78 51 6 5 90 75 69 62 28 97 67 35 65 33 72 15 78 40 96 61 58 45 45 59 78 79 45 25 21 26 97 92 95 53 3 86 87 53 44 50 2 24 40 65 4 17 10 19 27 96 19 68 15 27 42 59 28 16 4 6 22 53 21 32 34 27 67 19 4 31 50 86 82 8 96 24 100 6 67 71 22 10 51 15 19 70 97 92 57 44 100 10 80 92 59 33 53 91 6 90 82 1 67 14 10 45 45 86 42 16 18 7 95 3 79 76 33 85 55 54 100 47 95 15 49 14 24 20 15 14 45 18 42 85 35 76 35 66 11 10 85 92 49 32 69 37 77 62 62 76 90 96 18 46 4 55 51 52 74 89 71 86 70 28 48 17 89 41 93 52 67 27 43 15 4 36 55 12 81 51 35 8 56 74 58 80 71 67 16 36 16 97 64 78 45 13 27 53 50 32 37 4 23 30 64 22 21 29 71 7 12 90 65 99 70 3 71 33 29 42 11 19 4 93 1 9 73 59 2 88 60 51 33 94 6 62 62 82 4 53 4 39 91 42 4 44 17 75 56 71 34 80 9 17 76 12 45 82 46 40 45 1 54 70 55 34 13 25 38 28 95 14 80 62 7 88 3 65 98 66 50 23 33 45 82 49 10 7 14 2 93 19 33 62 17 78 74 10 85 2 44 9 61 52 34 86 30 56 84 21 78 11 1 87 94 95 6 15 4 6 81 40 48 44 46 36 17 90 1 2 41 12 2 1 99 44 91 15 35 55 18 43 38 34 60 33 77 32 96 9 89 17 37 33 14 59 39 95 81 1 17 93 67 27 85 70 53 25 61 70 89 47 69 7 90 76 89 67 46 32 62 50 60 34 57 88 1 66 56 29 64 76 43 100 44 88 47 37 85 18 76 73 69 84 43 84 79 42 23 4 28 55 56 23 70 11 24 60 97 80 68 5 24 75 81 50 69 21 31 23 62 81 58 73 65 98 18 50 39 63 79 55 66 14 60 45 31 27 34 60 46 79 77 75 6 78 80 91 13 78 20 12 29 20 91 27 70 42 73 18 94 41 4 36 40 11 82 36 18 91 39 30 22 78 10 63 90 11 25 53 59 73 59 43 36 95 36 60 31 92 88 52 97 90 99 31 22 61 73 71 82 59 18 79 8 77 97 13 44 45 48 5 52 60 91 4 94 82 79 94 26 47 31 38 26 51 18 58 72 9 6 35 24 86 30 76 88 21 17 55 92 76 100 44 18 33 60 20 68 55 57 37 99 83 85 13 29 58 75 79 99 32 1 76 82 84 32 18 22 89 34 30 69 48 2 36 47 56 98 94 69 23 63 22 63 7 10 81 25 42 89 60 13 41 97 56 74 35 15 25 86 88 31 71 70 48 54 60 5 100 49 15 97 18 21 66 70 10 88 43 42 65 48 39 26 43 15 5 63 39 23 87 61 51 97 70 39 79 19 35 63 64 25 68 95 9 51 71 51 7 32 47 3 55 31 2 51 39 72 3 42 83 93 22 50 96 99 13 69 51 46 25 77 61 48 79 13 74 29 87 5 20 25 42 95 91 80 78 9 85 54 98 96 2 100 9 29 95 80 34 22 83 36 57 34 67 21 1 56 89 54 71 80 13 31 83 15 41 17 34 60 2 30 41 18 71 63 80 92 38 29 6 9 17 17 33 73 33 54 12 14 9 92 8 76 64 67 26 37 70 55 71 56 7 18 30 49 77 40 71 68 6 97 8 85 90 24 10 49 85 8 21 26 31 35 65 75 91 71 83 1 1 70 3 80 91 62 58 5 76 99 83 55 92 12 80 88 38 71 75 80 25 10 63 20 47 21 4 63 47 67 19 36 34 61 90 99 47 31 54 43 35 9 47 49 92 94 75 67 71 33 20 9 6 46 46 93 38 15 100 79 11 37 40 4 11 76 46 19 47 67 23 14 19 67 19 10 90 3 21 69 91 23 31 12 27 46 69 27 79 31 86 90 78 49 99 41 2 52 57 16 14 54 54 5 8 13 95 54 42 63 84 42 43 62 96 72 74 2 95 97 87 80 31 74 99 38 7 49 2 49 87 49 66 24 69 79 83 76 21 27 28 56 79 8 65 33 73 47 65 84 15 58 36 98 25 80 33 57 13 14 51 98 38 89 23 70 21 86 74 52 5 39 74 2 55 57 94 68 15 45 60 98 46 46 29 35 33 75 9 77 73 76 77 32 79 55 60 13 28 90 52 60 64 63 24 6 19 85 89 79 88 82 44 38 57 55 37 45 68 83 19 6 79 67 12 53 84 40 58 88 15 37 70 22 100 73 78 44 72 39 42 97 44 51 72 19 93 35 2 70 74 38 60 62 75 89 29 11 52 76 48 71 84 36 43 100 38 49 87 13 5 92 63 45 65 16 14 62 30 40 87 56 72 24 24 15 55 84 12 52 59 55 9 61 28 49 79 76 50 27 6 36 88 31 62 70 55 27 56 32 71 58 74 71 46 20 64 92 2 88 16 77 67 94 89 67 73 90 36 29 21 16 98 6 14 88 33 24 71 19 53 94 24 29 89 60 55 69 12 49 7 29 37 43 31 16 41 6 5 7 17 46 25 97 72 60 61 63 54 75 11 72 61 81 33 17 96 36 19 4 21 37 17 52 11 15 3 56 86 30 63 24 4 43 62 36 9 93 88 46 7 93 18 74 10 78 75 45 7 1 42 31 22 71 94 61 34 63 12 78 6 19 16 5 40 100 45 46 7 38 28 51 99 19 12 26 66 14 17 17 98 100 16 6 86 8 89 97 35 99 85 90 94 53 58 66 58 99 99 39 22 62 61 87 68 9 76 89 60 53 83 26 63 42 12 21 90 85 57 45 65 97 61 21 98 74 14 46 46 76 82 72 98 16 28 87 23 63 60 59 79 32 22 48 47 52 33 84 20 11 93 4 58 52 42 33 46 59 40 13 43 30 56 77 87 69 92 1 51 70 20 100 39 45 3 93 54 22 69 41 88 40 15 53 90 80 85 68 42 53 3 62 83 42 64 35 60 79 20 34 10 12 15 36 40 85 91 93 66 66 65 21 46 68 46 74 74 27 48 9 94 43 92 100 63 7 63 15 79 21 89 30 95 59 57 13 83 50 85 37 84 27 12 94 88 5 8 64 74 16 100 10 60 93 98 20 10 10 59 92 21 71 10 4 79 47 17 20 28 68 70 42 16 78 52 8 72 82 67 15 3 7 31 75 80 82 74 34 70 57 27 33 57 69 94 57 58 18 54 47 36 20 75 76 42 57 3 4 43 83 73 10 23 22 12 54 18 7 2 97 57 18 17 76 80 3 54 43 88 62 80 96 17 51 50 91 98 45 96 89 20 67 58 87 64 91 16 67 5 90 62 42 93 30 31 34 8 88 83 100 19 11 99 29 65 83 79 94 32 5 6 7 15 87 18 35 36 55 16 51 19 43 55 71 13 80 64 92 35 93 84 31 55 22 58 29 29 99 57 69 4 50 92 59 25 91 82 89 23 10 89 45 19 71 40 64 73 66 26 90 49 4 86 91 80 96 3 88 15 88 23 80 39 10 10 49 12 83 10 73 45 24 6 92 51 7 6 29 48 50 11 37 61 36 56 81 79 4 96 54 55 86 74 47 10 100 11 44 98 91 79 70 73 25 56 83 20 26 1 72 59 35 61 71 38 8 96 36 22 18 34 36 11 54 95 74 44 27 65 51 81 48 24 73 16 58 76 19 57 20 47 31 55 71 21 29 92 83 34 41 52 2 20 38 27 63 79 9 48 38 94 45 28 98 89 89 58 11 90 13 100 36 51 88 16 3 1 39 40 28 9 47 79 33 78 77 91 97 12 56 65 86 100 3 11 48 57 67 33 85 60 80 51 74 53 12 57 20 48 99 89 50 92 67 22 59 10 87 34 1 31 19 44 6 100 23 7 12 37 2 11 60 59 6 28 12 91 53 76 25 48 30 2 55 44 46 31 4 55 77 38 32 44 34 87 83 2 78 31 32 63 86 47 50 40 69 31 63 75 67 60 57 37 49 22 81 36 96 76 23 40 24 16 91 71 26 97 73 78 100 95 2 59 80 80 84 26 89 22 70 90 62 45 70 63 70 69 41 18 43 43 84 58 89 93 37 29 25 9 40 33 11 14 72 14 68 10 57 35 22 76 24 74 76 8 4 81 82 18 12 99 50 24 37 88 37 88 5 83 86 72 96 25 37 71 53 12 41 32 40 3 63 80 4 38 16 64 11 37 44 84 30 61 77 36 7 84 43 26 22 96 50 33 11 29 22 85 13 7 74 93 49 78 58 39 23 82 76 32 32 16 21 4 29 22 60 4 99 21 37 89 84 6 88 17 16 47 94 92 87 64 10 81 9 7 22 6 44 64 73 93 53 50 23 43 67 96 94 12 56 33 95 79 38 41 77 12 66 64 67 31 95 48 74 94 66 46 39 89 22 7 41 7 74 89 63 82 19 96 92 41 61 30 47 44 90 93 25 13 51 48 78 27 77 24 92 28 57 68 55 4 4 2 7 24 3 7 40 24 18 45 2 14 31 43 98 4 73 9 48 89 80 33 62 59 43 12 75 5 19 83 99 83 21 10 73 44 39 39 68 84 57 97 73 79 36 14 53 78 46 22 80 97 39 94 43 27 82 32 96 94 81 6 79 20 31 100 15 25 94 77 82 49 90 20 9 98 12 55 16 35 88 75 65 97 74 86 43 89 93 16 61 25 43 13 44 4 89 3 84 15 81 46 83 3 16 1 34 62 77 35 59 53 79 27 36 38 81 41 34 1 48 65 37 87 36 26 96 5 42 71 71 98 91 19 91 74 61 72 71 41 58 100 68 52 63 94 96 74 82 53 10 29 21 98 44 17 18 13 54 14 14 84 20 94 7 10 45 91 54 23 74 32 58 27 47 16 89 56 76 48 99 50 84 39 99 80 51 90 41 2 18 47 36 21 94 76 82 45 90 31 3 73 41 15 96 85 35 66 96 13 35 5 47 1 80 92 15 46 12 73 79 26 22 58 31 29 12 29 30 11 97 47 19 93 44 79 43 26 47 58 95 26 85 79 69 85 26 81 11 90 76 52 29 38 46 83 99 14 36 39 80 65 16 22 66 70 3 25 99 100 20 95 24 37 70 29 55 30 43 30 35 21 45 17 4 87 97 39 41 14 62 62 44 9 20 92 56 76 43 83 54 12 59 57 93 38 82 19 60 44 59 38 94 88 13 25 97 11 42 70 23 9 66 9 54 54 90 87 59 43 73 18 82 78 51 64 55 51 39 46 65 76 63 22 9 45 47 65 36 38 63 66 21 44 2 38 93 65 58 56 69 4 2 82 40 37 9 72 15 65 85 6 85 45 58 92 22 2 81 95 4 70 16 64 68 1 94 97 56 87 84 64 75 26 20 65 59 18 32 91 45 29 81 74 12 93 61 62 73 84 50 35 63 34 23 65 72 26 46 23 34 65 52 80 4 2 56 51 48 23 21 53 46 27 43 11 45 1 66 30 32 90 62 30 78 89 73 65 12 3 33 25 27 59 93 65 94 88 69 91 71 16 94 94 72 100 82 96 44 69 50 84 87 99 16 32 1 24 90 80 84 48 10 48 40 8 81 66 75 26 84 59 36 95 81 15 67 50 8 94 74 68 39 31 20 5 98 88 92 42 96 85 35 100 10 56 16 36 80 45 14 66 76 21 55 44 9 18 22 16 50 75 29 79 73 100 75 12 45 62 6 78 73 68 74 35 64 1 66 60 5 99 28 17 53 50 28 49 1 11 79 74 75 8 35 53 19 94 88 10 79 52 61 13 11 23 11 65 97 97 65 23 39 72 44 91 56 99 62 63 11 100 43 75 7 58 70 11 65 84 68 44 93 64 93 12 2 24 65 20 70 54 14 89 37 16 87 14 11 4 36 32 66 82 43 8 95 3 54 23 35 7 77 65 68 98 97 31 5 30 11 31 15 81 56 96 34 19 59 31 95 26 33 27 50 10 90 71 38 41 68 66 27 11 66 15 29 43 89 80 39 20 69 96 77 59 74 10 3 60 7 69 97 7 81 10 13 48 87 54 68 90 41 23 68 84 55 7 98 48 55 53 36 5 37 33 60 43 11 20 4 84 6 26 57 35 98 89 42 85 33 14 70 91 1 49 7 97 65 55 75 25 94 89 59 79 68 61 40 9 31 23 51 40 14 96 56 68 91 88 76 26 3 92 10 4 52 23 45 91 32 94 22 85 32 10 79 57 88 13 76 40 63 35 54 65 56 20 14 36 2 58 60 12 25 41 17 9 82 96 68 73 9 28 88 26 17 78 72 15 25 69 1 64 35 3 68 62 100 72 57 85 85 16 13 48 8 79 50 56 48 63 60 78 41 70 35 86 6 90 78 18 84 2 51 10 83 49 98 71 45 48 4 10 100 52 34 75 15 18 41 39 46 96 18 73 39 50 24 27 65 45 45 31 94 36 4 91 51 67 78 86 18 4 32 16 92 4 72 9 83 8 77 99 48 87 38 93 97 27 75 95 87 3 39 93 15 36 52 23 75 47 84 60 82 86 38 65 76 87 30 54 82 61 77 91 93 9 44 42 49 71 26 42 74 94 59 100 19 56 9 40 46 82 9 57 53 41 99 49 32 80 73 19 36 25 1 62 64 27 17 95 100 93 36 70 74 97 84 35 58 28 74 75 26 66 61 49 16 28 44 76 56 13 45 46 53 96 86 100 83 83 20 59 27 24 57 92 34 100 4 52 31 76 87 42 18 2 97 25 9 19 60 83 60 75 75 65 40 69 13 66 91 85 1 64 31 11 65 44 42 86 93 24 10 64 68 45 5 74 34 22 60 81 6 36 10 51 52 55 61 15 68 13 98 51 66 79 3 74 67 45 5 84 16 9 16 32 91 59 99 34 59 23 68 36 94 10 82 70 22 4 84 37 67 51 4 73 37 18 54 3 43 23 94 99 8 31 43 66 1 70 8 99 10 8 67 37 81 87 7 39 32 17 24 27 12 24 23 31 13 90 16 100 79 87 5 4 100 32 42 23 83 82 6 41 15 47 17 91 47 89 65 12 35 73 80 42 64 85 88 2 91 50 5 2 18 92 10 19 48 94 38 31 60 21 53 81 56 25 40 87 61 65 75 56 49 6 35 59 89 4 8 44 64 1 69 16 37 35 47 71 93 22 32 76 59 79 38 49 62 2 13 47 76 59 85 65 67 55 37 71 84 59 99 47 5 15 79 56 42 85 57 65 52 37 32 15 8 8 17 97 42 92 40 67 40 36 80 40 86 89 97 100 41 35 68 75 95 37 94 100 53 63 52 92 47 87 82 26 6 67 66 4 39 13 46 33 17 55 12 43 18 35 39 57 71 2 95 82 84 87 79 72 15 54 35 83 23 79 27 92 62 58 6 24 95 2 6 67 73 34 24 1 1 90 32 9 78 12 75 85 85 75 93 6 23 10 82 74 65 69 58 65 19 72 75 97 61 54 31 15 34 82 67 86 92 10 67 87 11 35 72 70 65 7 38 99 23 65 43 98 19 21 73 43 50 80 68 89 49 22 21 46 5 72 96 85 53 83 57 98 47 55 76 35 88 2 32 60 43 3 57 36 9 90 29 68 82 53 97 73 15 19 93 12 20 98 53 8 100 15 22 32 47 53 69 22 51 54 14 82 21 59 76 42 90 77 46 87 29 95 41 35 23 1 46 19 95 42 3 44 92 92 16 12 86 67 43 86 99 93 32 10 43 37 57 36 19 47 46 65 74 14 76 98 66 44 75 40 24 28 84 12 77 90 13 97 68 22 59 62 76 28 70 20 96 37 67 17 70 60 41 62 39 42 15 100 61 47 56 98 24 82 33 97 80 15 78 31 88 85 28 33 15 1 34 68 8 11 43 98 15 68 3 68 59 58 15 85 57 3 56 93 3 25 37 97 24 8 56 92 66 44 8 79 67 96 55 5 58 68 42 20 72 56 18 71 30 99 63 69 61 68 77 44 40 64 58 13 53 57 7 67 76 31 28 17 11 95 23 11 93 62 72 57 64 67 38 44 88 65 76 100 29 48 44 79 96 33 42 12 35 54 96 57 23 72 14 80 96 14 89 47 76 96 42 55 9 48 86 72 61 84 49 76 36 64 29 95 84 24 81 29 93 57 45 17 63 91 100 44 90 50 52 43 63 13 53 82 26 69 56 44 41 43 11 95 15 79 5 93 21 71 96 27 49 68 56 72 44 23 50 98 65 27 43 69 78 36 52 50 68 22 71 40 73 8 61 57 28 77 1 62 72 48 86 9 23 87 1 26 11 25 9 56 36 25 88 54 95 56 30 79 64 7 65 7 47 79 31 64 52 79 80 65 33 54 20 90 30 63 79 63 34 40 96 67 100 52 59 23 35 27 77 75 20 48 23 34 78 50 64 55 21 34 61 16 81 69 27 8 35 29 60 18 90 87 70 48 77 8 27 96 77 63 11 94 63 47 98 5 77 48 59 67 20 86 22 50 60 65 84 48 74 58 52 19 46 9 62 53 80 93 1 5 16 47 12 46 85 53 68 28 45 77 99 56 42 75 91 90 77 4 67 46 65 1 60 61 49 69 83 21 66 48 91 71 89 83 21 11 76 65 61 95 17 47 82 100 82 84 74 22 71 72 27 31 75 45 52 85 79 31 31 20 5 92 15 68 97 41 53 6 36 12 10 1 22 61 24 45 61 89 35 19 27 15 62 91 37 93 11 90 43 12 10 55 12 27 37 9 85 44 38 56 94 49 94 27 6 45 8 48 60 87 57 23 38 12 5 64 47 96 60 19 56 12 41 100 18 94 61 35 49 90 28 29 66 80 70 15 23 36 19 24 50 12 97 64 66 31 28 21 8 46 62 10 65 73 36 89 70 54 86 28 84 38 45 73 96 94 3 71 49 94 26 97 44 86 4 79 23 42 15 98 6 84 50 70 48 38 61 46 73 75 43 48 49 45 1 99 53 80 57 18 74 41 30 80 84 51 50 45 27 36 60 16 95 7 93 100 59 29 85 76 35 22 66 46 48 52 66 49 87 100 44 74 31 24 32 73 28 38 98 14 2 87 21 26 32 5 40 80 7 3 14 14 72 96 1 37 49 81 28 44 69 19 48 78 20 12 56 92 72 59 57 55 16 15 58 42 25 90 75 9 76 48 3 31 30 92 20 35 72 58 12 32 40 84 59 17 19 11 64 49 55 61 10 73 66 58 8 66 44 68 28 25 19 20 59 89 26 2 49 9 51 70 52 93 79 20 78 52 63 89 69 72 92 95 38 63 53 32 38 3 27 94 32 48 31 47 36 21 20 5 75 51 48 63 94 3 6 44 61 5 60 57 90 25 11 36 34 7 78 89 62 56 86 89 93 80 45 23 84 57 75 14 81 43 82 95 97 2 87 51 11 79 60 22 64 11 42 60 92 60 31 5 62 76 6 1 15 31 31 94 60 32 8 44 36 22 21 98 72 91 22 6 30 12 87 39 6 4 70 77 67 45 77 13 54 89 76 18 17 13 41 35 18 83 75 77 97 99 82 34 65 100 58 22 93 47 20 68 69 70 32 76 63 60 93 69 41 14 38 6 91 30 28 87 6 39 55 41 98 23 100 51 1 95 29 65 6 31 97 35 56 96 3 47 22 9 93 71 39 48 67 87 91 85 17 66 12 6 11 70 42 2 81 100 25 87 10 91 94 91 57 50 1 79 78 32 71 15 5 58 3 75 25 69 9 76 27 75 22 66 7 17 97 90 74 86 55 85 6 32 68 86 4 15 89 81 34 95 81 50 94 5 68 63 78 20 81 49 30 66 89 86 55 44 73 41 42 46 79 72 82 4 28 22 56 47 12 65 24 39 47 65 65 97 36 72 1 77 81 93 11 40 57 32 9 20 99 54 72 22 38 31 32 36 3 12 56 23 64 85 46 63 75 78 3 99 23 9 17 6 80 75 95 39 52 83 41 47 16 31 63 40 36 72 55 93 58 59 37 88 68 91 27 21 11 76 2 59 17 25 48 40 79 58 35 15 79 22 51 40 100 18 95 84 28 51 53 25 6 11 81 14 65 62 22 89 87 29 12 99 31 28 31 19 15 55 83 84 54 47 19 96 14 96 4 65 58 3 62 80 100 9 74 36 38 62 27 80 4 71 62 66 50 62 84 50 43 3 96 15 87 9 17 11 80 76 70 82 70 10 24 97 74 99 35 36 80 28 15 96 81 58 35 29 68 88 76 37 7 77 67 73 77 91 7 70 93 25 81 8 43 14 63 52 18 19 6 25 82 8 89 64 27 78 16 34 93 79 5 57 58 50 83 13 91 9 6 91 28 49 42 88 94 33 44 16 97 14 99 85 62 77 12 99 70 10 52 36 61 9 74 79 39 71 21 78 81 9 3 34 26 76 61 71 94 10 24 97 4 75 92 12 72 87 35 83 24 56 77 10 69 29 87 52 59 62 42 68 14 16 49 94 14 15 81 80 74 8 59 93 21 9 48 55 38 78 16 84 96 63 70 90 51 61 71 97 40 41 1 78 77 98 19 24 81 84 33 30 8 41 33 65 64 34 79 14 55 13 35 54 89 92 32 30 50 86 33 86 34 24 42 59 22 64 80 60 86 31 77 91 82 17 86 78 67 46 76 75 38 95 29 82 96 70 18 91 10 9 59 89 58 30 15 14 64 2 20 59 61 92 77 94 24 76 4 4 81 2 30 61 60 66 56 22 94 91 35 20 95 34 28 46 35 58 21 32 49 98 74 84 52 84 22 94 27 88 13 14 96 32 31 25 70 97 8 98 68 48 31 50 34 7 45 39 43 79 50 76 12 98 50 57 75 11 51 73 59 42 35 14 50 58 28 96 14 41 11 79 78 32 41 36 3 30 53 52 47 74 71 60 33 22 43 34 67 99 91 56 20 67 23 48 60 60 73 25 35 53 44 67 100 76 56 80 48 60 68 2 12 82 60 78 74 96 47 32 16 65 82 79 77 5 100 29 61 24 29 79 34 80 92 95 18 13 89 81 89 21 93 42 55 66 59 50 60 58 79 72 52 81 3 46 89 76 58 78 97 87 2 59 100 8 65 3 51 1 57 26 88 73 22 44 78 30 93 92 57 3 85 7 13 56 67 14 64 99 21 17 61 31 45 9 12 17 78 57 36 28 1 90 67 32 7 27 21 47 56 85 31 6 99 49 97 7 99 49 61 30 71 29 29 72 68 75 1 38 56 12 80 1 82 64 86 24 47 76 44 8 71 14 45 100 50 65 80 35 7 12 3 42 81 69 34 68 77 58 25 91 61 52 5 18 51 54 30 61 56 81 9 52 18 29 53 56 76 13 53 72 37 92 58 23 78 85 80 75 81 63 41 52 97 87 32 22 77 20 91 17 11 55 95 67 8 6 81 42 85 16 66 33 9 73 88 54 18 9 6 32 67 67 47 36 64 94 78 32 30 35 37 62 67 1 7 55 25 30 50 61 89 67 65 26 6 64 10 80 46 44 37 62 96 39 24 18 93 65 37 62 46 54 2 22 54 3 82 36 54 90 92 52 59 17 88 31 40 84 87 89 42 47 37 45 34 6 28 8 58 8 49 61 27 15 92 70 2 77 44 23 31 78 59 31 70 43 58 19 18 58 79 19 33 20 50 74 97 80 6 74 33 57 98 82 90 9 59 85 85 53 95 8 49 29 88 69 84 27 5 60 21 17 59 28 83 50 28 4 65 69 50 63 75 11 42 10 36 10 22 77 38 92 94 97 76 30 75 43 57 95 71 92 40 37 78 50 55 82 54 53 16 49 31 5 48 19 88 77 28 40 95 94 2 22 41 4 6 75 88 52 26 15 8 86 96 46 12 56 44 76 65 71 85 3 69 63 90 89 95 81 49 93 99 4 50 38 79 33 88 16 75 98 82 61 76 64 81 97 77 39 67 66 94 90 54 49 51 72 29 14 91 88 33 47 6 91 67 17 39 14 58 38 51 58 34 56 24 55 84 11 65 91 15 28 37 96 43 95 48 23 52 67 57 63 31 85 34 33 22 6 51 45 44 6 7 60 40 79 17 32 70 55 89 35 6 46 63 13 18 44 98 10 77 35 64 62 59 30 64 16 18 63 45 58 21 16 86 45 88 75 72 64 57 36 58 88 50 27 22 92 16 53 92 55 46 26 46 92 65 11 8 42 19 52 20 50 90 71 9 97 75 50 66 77 30 43 90 99 74 56 2 61 37 5 59 44 76 93 59 69 25 66 87 4 22 42 4 70 37 2 62 87 73 59 7 14 50 14 70 30 6 14 90 45 3 39 45 16 3 29 37 78 39 37 51 93 76 65 4 63 4 36 82 57 72 31 77 87 11 46 18 15 32 64 63 55 41 99 21 97 31 65 71 31 9 88 96 19 3 5 73 61 8 76 72 36 19 54 67 28 72 24 71 11 42 88 43 4 44 38 46 85 88 60 68 38" },
            };
    }
}
