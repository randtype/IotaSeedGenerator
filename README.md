# Iota Seed Generator

In the last days there are some seed generators which are just to steal IOTA. 
This seed generator for Windows should a free and easy tool which does not steal any IOTA.

It is open source under GPLv3 Licence.

# Random generator
- Internally it is based on the .Net's `System.Security.Cryptography.RandomNumberGenerator.Create()` method. This should be an cryptographic random number generator according to [MSDN](https://msdn.microsoft.com/en-us/library/2ae535c8(v=vs.110).aspx)

- The random bytes are then mapped to appropriate IOTA seed characters, i.e. `A-Z` and the number `9`. The method is used from [Stackoverflow](https://crypto.stackexchange.com/a/5721).

# Randomness test
The outcoming numbers in the appropriate range are tested with the random number test suite "Dieharder" [Link](https://webhome.phy.duke.edu/~rgb/General/dieharder.php). 

There are 500 numbers and the test results are in the `IotaSeedGenerator/seedtest` directory.


