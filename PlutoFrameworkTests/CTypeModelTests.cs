using PlutoFramework.Model;

namespace PlutoFrameworkTests
{
    public class CTypeModelTests
    {
        [Test]
        public void ComputeCTypeId()
        {
            var schema = new FullCTypeSchema
            {
                Schema = "ipfs://bafybeiah66wbkhqbqn7idkostj2iqyan2tstc4tpqt65udlhimd7hcxjyq/",
                Title = "Drivers License by did:kilt:4t9FPVbcN42UMxt3Z2Y4Wx38qPL8bLduAB11gLZSwn5hVEfH",
                Type = "object",
                AdditionalProperties = false,
                Properties = new Dictionary<string, CTypeProperty>
                {
                    ["age"] = new CTypePrimitiveProperty { Type = "integer" },
                    ["id"] = new CTypePrimitiveProperty { Type = "string" },
                    ["name"] = new CTypePrimitiveProperty { Type = "string" },
                }
            };

            Assert.That(schema.Id, Is.EqualTo("kilt:ctype:0x4f1d68ac46daf4613181b33b16faaf10cf94879dc2246d7485dc2ccbb843641d"));
        }
    }
}
