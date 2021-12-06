using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deserializtion;
using System;
using System.Collections.Generic;
using PlayerBase;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deserializtion.Tests
{
    [TestClass()]
    public class DeserializationTests
    {
        [TestMethod()]
        public void DeSerializePlayerObjectsTest()
        {
            // Arrange
            var playersSource = Serialization.Serialization.GenerateTestPlayers();
            Serialization.Serialization.SerializePlayerObjects(Serialization.Serialization.defaultFilePath, playersSource);
            var playersResult = new List<Player>();

            // Act
            var result = Deserialization.DeSerializePlayerObjects(Deserialization.defaultFilePath, out playersResult);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DoesCreatedFileContentsAreEqualToSerializedFile()
        {
            // Arrange
            var playersSource = Serialization.Serialization.GenerateTestPlayers();
            Serialization.Serialization.SerializePlayerObjects(Serialization.Serialization.defaultFilePath, playersSource);
            var playersResult = new List<Player>();

            // Act
            var result = Deserialization.DeSerializePlayerObjects(Deserialization.defaultFilePath, out playersResult);

            // Assert
            Assert.AreEqual(playersSource, playersResult);
        }
    }
}