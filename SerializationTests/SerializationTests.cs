using Deserializtion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using PlayerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization.Tests
{
    [TestClass()]
    public class SerializationTests
    {
        [TestMethod()]
        public void SerializePlayerObjectsTest()
        {
            // Arrange
            var players = Serialization.GenerateTestPlayers();

            // Act
            var result = Serialization.SerializePlayerObjects(Serialization.defaultFilePath, players);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void DoesCreatedFileExistsTest()
        {
            // Arrange
            var players = Serialization.GenerateTestPlayers();

            // Act
            Serialization.SerializePlayerObjects(Serialization.defaultFilePath, players);

            // Assert
            Assert.IsTrue(File.Exists(Serialization.defaultFilePath));
        }
    }
}