﻿namespace Algorithms;

public sealed class MurmurHash
{
    private const int DefaultSeed = 0;

    /// <summary>Initialize the hash using the default seed value.</summary>
    /// <remarks>Initialize the hash using the default seed value.</remarks>
    /// <returns>the intermediate hash value</returns>
    public static int Initialize()
    {
        return Initialize(DefaultSeed);
    }

    /// <summary>
    /// Initialize the hash using the specified
    /// <paramref name="seed"/>
    /// .
    /// </summary>
    /// <param name="seed">the seed</param>
    /// <returns>the intermediate hash value</returns>
    public static int Initialize(int seed)
    {
        return seed;
    }

    /// <summary>
    /// Update the intermediate hash value for the next input
    /// <paramref name="value"/>
    /// .
    /// </summary>
    /// <param name="hash">the intermediate hash value</param>
    /// <param name="value">the value to add to the current hash</param>
    /// <returns>the updated intermediate hash value</returns>
    public static int Update(int hash, int value)
    {
        int c1 = unchecked((int)(0xCC9E2D51));
        int c2 = unchecked((int)(0x1B873593));
        int r1 = 15;
        int r2 = 13;
        int m = 5;
        int n = unchecked((int)(0xE6546B64));
        int k = value;
        k *= c1;
        k = (k << r1) | ((int)(((uint)k) >> (32 - r1)));
        k *= c2;
        hash ^= k;
        hash = (hash << r2) | ((int)(((uint)hash) >> (32 - r2)));
        hash = hash * m + n;
        return hash;
    }

    /// <summary>
    /// Update the intermediate hash value for the next input
    /// <paramref name="value"/>
    /// .
    /// </summary>
    /// <param name="hash">the intermediate hash value</param>
    /// <param name="value">the value to add to the current hash</param>
    /// <returns>the updated intermediate hash value</returns>
    public static int Update(int hash, object value)
    {
        return Update(hash, value != null ? value.GetHashCode() : 0);
    }

    /// <summary>
    /// Apply the final computation steps to the intermediate value
    /// <paramref name="hash"/>
    /// to form the final result of the MurmurHash 3 hash function.
    /// </summary>
    /// <param name="hash">the intermediate hash value</param>
    /// <param name="numberOfWords">the number of integer values added to the hash</param>
    /// <returns>the final hash result</returns>
    public static int Finish(int hash, int numberOfWords)
    {
        hash ^= (numberOfWords * 4);
        hash ^= ((int)(((uint)hash) >> 16));
        hash *= unchecked((int)(0x85EBCA6B));
        hash ^= ((int)(((uint)hash) >> 13));
        hash *= unchecked((int)(0xC2B2AE35));
        hash ^= ((int)(((uint)hash) >> 16));
        return hash;
    }

    /// <summary>
    /// Utility function to compute the hash code of an array using the
    /// MurmurHash algorithm.
    /// </summary>
    /// <remarks>
    /// Utility function to compute the hash code of an array using the
    /// MurmurHash algorithm.
    /// </remarks>
    /// <param name="data">the array data</param>
    /// <param name="seed">the seed for the MurmurHash algorithm</param>
    /// <returns>the hash code of the data</returns>
    public static int HashCode<T>(T[] data, int seed)
    {
        int hash = Initialize(seed);
        foreach (T value in data)
        {
            hash = Update(hash, value);
        }

        hash = Finish(hash, data.Length);
        return hash;
    }

    private MurmurHash()
    {
    }
}
