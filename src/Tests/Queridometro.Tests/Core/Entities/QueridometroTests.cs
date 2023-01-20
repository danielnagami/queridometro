using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Queridometro.Core.Entities;
using System.Linq;

using QueridometroEntity = Queridometro.Core.Entities.Queridometro;

namespace Queridometro.Tests.Core.Entities
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
            var queridometro = new QueridometroEntity("Lucas Penteado", "");

            queridometro.AddEmoji(Emoji.Cobra);
            queridometro.AddEmoji(Emoji.Nojo);
            queridometro.AddEmoji(Emoji.Feliz);
            queridometro.AddEmoji(Emoji.Triste);
            queridometro.AddEmoji(Emoji.Bomba);
            queridometro.AddEmoji(Emoji.Coração);
            queridometro.AddEmoji(Emoji.CoraçãoQuebrado);
            queridometro.AddEmoji(Emoji.Banana);
            queridometro.AddEmoji(Emoji.Planta);
            queridometro.AddEmoji(Emoji.Mala);
            queridometro.AddEmoji(Emoji.Flecha);
            queridometro.AddEmoji(Emoji.NarizDePinoquio);

            Assert.IsTrue(queridometro.Emojis.Count == 12);
        }

        [TestMethod]
        public void CreateAQueridometroWithEmojisRepeated()
        {
            var queridometro = new QueridometroEntity("Lucas Penteado", "");

            queridometro.AddEmoji(Emoji.Cobra);
            queridometro.AddEmoji(Emoji.Nojo);
            queridometro.AddEmoji(Emoji.Feliz);
            queridometro.AddEmoji(Emoji.Triste);
            queridometro.AddEmoji(Emoji.Bomba);
            queridometro.AddEmoji(Emoji.Coração);
            queridometro.AddEmoji(Emoji.Coração);
            queridometro.AddEmoji(Emoji.Coração);
            queridometro.AddEmoji(Emoji.Coração);
            queridometro.AddEmoji(Emoji.Coração);


            var tantosFaz = queridometro.Emojis.Where(x => x.HasFlag(Emoji.Coração)).ToList().Count();

            Assert.IsTrue(tantosFaz == 5);
        }
    }
}