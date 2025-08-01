//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Mythos.NetApi.Generated.Model.sp_runtime.proving_trie
{
    
    
    /// <summary>
    /// >> TrieError
    /// </summary>
    public enum TrieError
    {
        
        /// <summary>
        /// >> InvalidStateRoot
        /// </summary>
        InvalidStateRoot = 0,
        
        /// <summary>
        /// >> IncompleteDatabase
        /// </summary>
        IncompleteDatabase = 1,
        
        /// <summary>
        /// >> ValueAtIncompleteKey
        /// </summary>
        ValueAtIncompleteKey = 2,
        
        /// <summary>
        /// >> DecoderError
        /// </summary>
        DecoderError = 3,
        
        /// <summary>
        /// >> InvalidHash
        /// </summary>
        InvalidHash = 4,
        
        /// <summary>
        /// >> DuplicateKey
        /// </summary>
        DuplicateKey = 5,
        
        /// <summary>
        /// >> ExtraneousNode
        /// </summary>
        ExtraneousNode = 6,
        
        /// <summary>
        /// >> ExtraneousValue
        /// </summary>
        ExtraneousValue = 7,
        
        /// <summary>
        /// >> ExtraneousHashReference
        /// </summary>
        ExtraneousHashReference = 8,
        
        /// <summary>
        /// >> InvalidChildReference
        /// </summary>
        InvalidChildReference = 9,
        
        /// <summary>
        /// >> ValueMismatch
        /// </summary>
        ValueMismatch = 10,
        
        /// <summary>
        /// >> IncompleteProof
        /// </summary>
        IncompleteProof = 11,
        
        /// <summary>
        /// >> RootMismatch
        /// </summary>
        RootMismatch = 12,
        
        /// <summary>
        /// >> DecodeError
        /// </summary>
        DecodeError = 13,
    }
    
    /// <summary>
    /// >> 32 - Variant[sp_runtime.proving_trie.TrieError]
    /// </summary>
    public sealed class EnumTrieError : BaseEnum<TrieError>
    {
    }
}
