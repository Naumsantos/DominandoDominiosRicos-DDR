using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        { 
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("68046229000109")]
        [DataRow("12345678901234")]
        [DataRow("12345678905678")]
        public void ShouldReturnErrorWhenCNPJIsValid(string docNumber)
        {
            var doc = new Document(docNumber, EDocumentType.CNPJ) ;
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsValid()
        {
            var doc = new Document("68046229001", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
