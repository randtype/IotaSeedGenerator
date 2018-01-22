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
using System;
using System.Collections.Generic;

namespace CryptoRng
{
    /// <summary>
    /// Source: https://crypto.stackexchange.com/a/5721
    /// </summary>
    public class RangeFitRandomNumber
    {
        private readonly int inputBound;
        private readonly int targetBound;
        private readonly IEnumerable<int> generator;

        public RangeFitRandomNumber(int inputBound, int targetBound, IEnumerable<int> generator)
        {
            this.inputBound = inputBound;
            this.targetBound = targetBound;
            this.generator = generator;
        }

        private int SelectNext()
        {
            var unboundCandidate = 0;
            var targetFactor = 1;

            foreach (var next in generator)
            {
                unboundCandidate = unboundCandidate * inputBound + next;
                targetFactor *= inputBound;

                var inputFactor = (int)Math.Floor((double)targetFactor / (double)inputBound) * inputBound;

                if (unboundCandidate < inputFactor)
                {
                    var value = unboundCandidate % targetBound;
                    return value;
                }

                unboundCandidate -= inputFactor;
                targetFactor -= inputFactor;
            }

            throw new InvalidOperationException("Generator was emptied.");
        }

        public IEnumerable<int> Project()
        {
            while (true)
            {
                yield return SelectNext();
            }
        }
    }
}