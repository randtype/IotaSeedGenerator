// Copyright 2018 Alexander Myar
// This file is part of Iota Seed Generator.
// Iota Seed Generator is free software: you can redistribute it and/or modify 
// it under the terms of the GNU General Public License as published by the 
// Free Software Foundation, either version 3 of the License, or(at your 
// option) any later version.
// Iota Seed Generator is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for 
// more details.
// You should have received a copy of the GNU General Public License along with 
// Iota Seed Generator. If not, see http://www.gnu.org/licenses/.
using System.Linq;
using System.Text;

namespace CryptoRng
{
    public class IotaSeed
    {
        private const string SeedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ9";
        private readonly RNGCryptoGenerator generator;

        public IotaSeed()
        {
            generator = new RNGCryptoGenerator();
        }

        public string Generate(int length)
        {
            var intGenerator = generator.Next().Select(e => (int)e);
            var rangeFitter = new RangeFitRandomNumber(byte.MaxValue + 1, SeedChars.Length, intGenerator);
            var randIndices = rangeFitter.Project().Take(length);

            var stringBuilder = new StringBuilder(randIndices.Count());
            if (true)
            {
                var targetChars = randIndices.Select(i => SeedChars[i]);
                foreach(var e in targetChars)
                {
                    stringBuilder.Append(e);
                }

                var value = stringBuilder.ToString();
                foreach (var e in value)
                {
                    if (!SeedChars.Contains(e))
                    {
                        return $"Invalid char detected '{(int)e}'.";
                    }
                }
            }
            else
            { // output for dieharder
                foreach (var e in randIndices)
                {
                    stringBuilder.Append($"{e.ToString()} ");
                }
            }

            return stringBuilder.ToString();
        }
    }
}