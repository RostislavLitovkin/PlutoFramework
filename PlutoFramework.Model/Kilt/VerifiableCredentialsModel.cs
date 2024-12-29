using Substrate.NetApi.Model.Types.Primitive;
using System.Text.RegularExpressions;

namespace PlutoFramework.Model.Kilt
{
    public class VerifiableCredentialsModel
    {
        /// <summary>
        /// https://github.com/KILTprotocol/sdk-js/blob/ec335d7086fa6673d2da45cd89f54ed02a09a287/packages/credentials/src/V1/KiltAttestationProofV1.ts#L727
        /// </summary>
        public void InitializeProof(
          UnissuedCredential credential
        )
        {
            if (credential.NonTransferable != true)
            {
                throw new Exception("nonTransferable must be set to true");
            }

            var type = credential.Type.Where(str => str.StartsWith("kilt:ctype:"));

            if (type.Count() == 0)
            {
                throw new Exception("A CType id is required in the set of credential types");
            }

            if ($"{type.First()}#" != credential.CredentialSubject.ContextVocab) {
                throw new Exception(
                    $"The credential type { type.First()} does not match credentialSubject vocabulary {credential.CredentialSubject.ContextVocab}"
                );
            }

        // 1. json-ld expand credentialSubject
        const expandedContents = jsonLdExpandCredentialSubject(credentialSubject)
  // 2. Transform to normalized statments and hash
  const { digests
    } = normalizeClaims(expandedContents)

  // 3. Produce entropy & commitments
  const entropy = new Array(digests.length)
    .fill(undefined)
    .map(() => randomAsU8a(36))
  const commitments = makeCommitments(digests, entropy)

  // 4. Create proof object
  const salt = entropy.map((e) => base58Encode(e))
  const proof: KiltAttestationProofV1 = {
    type: PROOF_TYPE,
    block: '',
    commitments: commitments.sort(u8aCmp).map((i) => base58Encode(i)),
    salt,
  }
// 5. Prepare call
const rootHash = calculateRootHash(credential, proof)
  const delegationId = getDelegationNodeIdForCredential(credential)

  return [
    proof,
    [
      rootHash,
      CType.idToHash(type),
      delegationId && { Delegation: delegationId },
    ],
  ]
}/**
 * Initialize a new, prelimiary {@link KiltAttestationProofV1}, which is the first step in issuing a new credential.
 *
 * @example
 * // start with initializing proof
 * const [proof, args] = initializeProof(credential)
 * const tx = api.tx.attestation.add(...args)
 * // after DID-authorizing and submitting transaction (taking note of the block hash and timestamp where the transaction was included)
 * const verifiableCredential = finalizeProof(credential, proof, {blockHash, timestamp})
 *
 * @param credential A KiltCredentialV1 for which a proof shall be created.
 * @returns A tuple where the first entry is the (partial) proof object and the second entry are the arguments required to create an extrinsic that anchors the proof on the KILT blockchain.
 */
export function initializeProof(
  credential: UnissuedCredential
): [
  KiltAttestationProofV1,
  Parameters<ApiPromise['tx']['attestation']['add']>
]
{
    const { credentialSubject, nonTransferable } = credential

  if (nonTransferable !== true)
    {
        throw new Error('nonTransferable must be set to true')
  }

    const type = credential.type.find((str): str is ICType['$id'] =>
    str.startsWith('kilt:ctype:')
  )
  if (!type)
    {
        throw new Error('A CType id is required in the set of credential types')
  }
    if (`${ type}#` !== credentialSubject['@context']['@vocab']) {
    throw new Error(
      `The credential type ${ type } does not match credentialSubject vocabulary ${ credentialSubject['@context']['@vocab']}`
    )
  }

// 1. json-ld expand credentialSubject
const expandedContents = jsonLdExpandCredentialSubject(credentialSubject)
  // 2. Transform to normalized statments and hash
  const { digests } = normalizeClaims(expandedContents)

  // 3. Produce entropy & commitments
  const entropy = new Array(digests.length)
    .fill(undefined)
    .map(() => randomAsU8a(36))
  const commitments = makeCommitments(digests, entropy)

  // 4. Create proof object
  const salt = entropy.map((e) => base58Encode(e))
  const proof: KiltAttestationProofV1 = {
type: PROOF_TYPE,
    block: '',
    commitments: commitments.sort(u8aCmp).map((i) => base58Encode(i)),
    salt,
  }
// 5. Prepare call
const rootHash = calculateRootHash(credential, proof)
  const delegationId = getDelegationNodeIdForCredential(credential)

  return [
    proof,
    [
      rootHash,
      CType.idToHash(type),
      delegationId && { Delegation: delegationId },
    ],
  ]
}
    }
}
