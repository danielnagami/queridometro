using Microsoft.VisualStudio.TestTools.UnitTesting;
using Queridometro.Core.Entities;
using System.Linq;

namespace Queridometro.Tests
{
    [TestClass]
    public class QueridometroTests
    {
        public QueridometroTests()
        {
            
        }

        [TestMethod]
        public void CreateAQueridometroWithAllTypesOfEmojis()
        {
            var queridometro = new Core.Entities.Queridometro("Lucas Penteado", "");

            queridometro.AddEmoji(Emoji.Amo);
            queridometro.AddEmoji(Emoji.Deboche);
            queridometro.AddEmoji(Emoji.Falsiane);
            queridometro.AddEmoji(Emoji.Nojo);
            queridometro.AddEmoji(Emoji.Odeio);
            queridometro.AddEmoji(Emoji.TantoFaz);

            Assert.IsTrue(queridometro.Emojis.Count == 6);
        }

        [TestMethod]
        public void CreateAQueridometroWithEmojisRepeated()
        {
            var queridometro = new Core.Entities.Queridometro("Lucas Penteado", "");

            queridometro.AddEmoji(Emoji.Amo);
            queridometro.AddEmoji(Emoji.Deboche);
            queridometro.AddEmoji(Emoji.Falsiane);
            queridometro.AddEmoji(Emoji.Nojo);
            queridometro.AddEmoji(Emoji.Odeio);
            queridometro.AddEmoji(Emoji.TantoFaz);
            queridometro.AddEmoji(Emoji.TantoFaz);
            queridometro.AddEmoji(Emoji.TantoFaz);
            queridometro.AddEmoji(Emoji.TantoFaz);
            queridometro.AddEmoji(Emoji.TantoFaz);
            queridometro.AddEmoji(Emoji.TantoFaz);

            var tantosFaz = queridometro.Emojis.Where(x => x.HasFlag(Emoji.TantoFaz)).ToList().Count();

            Assert.IsTrue(tantosFaz == 6);
        }
    }
}