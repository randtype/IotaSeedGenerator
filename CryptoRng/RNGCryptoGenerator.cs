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
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CryptoRng
{
    public class RNGCryptoGenerator
    {
        private readonly int bufferLength;
        private readonly RandomNumberGenerator rand;

        public RNGCryptoGenerator(int bufferLength = 128)
        {
            this.bufferLength = bufferLength;
            rand = RandomNumberGenerator.Create();
        }

        public IEnumerable<byte> Next()
        {
            var consumed = bufferLength;
            var randomNumber = new byte[bufferLength];

            while (true)
            {
                if (consumed == bufferLength)
                {
                    rand.GetBytes(randomNumber);
                    consumed = 0;
                }

                var next = randomNumber[consumed];
                consumed++;
                yield return next;
            }
        }
    }
}