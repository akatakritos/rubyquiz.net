using System;
using System.Text;

namespace RubyQuiz.Solitaire
{
    public class SolitaireCipher
    {
        public string Encrypt(Deck key, string message)
        {
            var stream = new DeckKeystream(key.Clone());
            var messageGroups = CharacterGroup.CreateSequence(MessageSanitizer.Sanitize(message));

            StringBuilder buffer = new StringBuilder();
            foreach (var group in messageGroups)
            {
                var messageNumberGroup = group.ToNumberGroup();
                var keystreamNumberGroup = nextStreamGroup(stream).ToNumberGroup();
                var resultGroup = messageNumberGroup.Add(keystreamNumberGroup);
                buffer.Append(resultGroup.ToCharacterGroup());
            }

            return buffer.ToString();

        }

        private CharacterGroup nextStreamGroup(DeckKeystream key)
        {
            return new CharacterGroup(key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext());
        }

        public string Decrypt(Deck key, string encryptedMessage)
        {
            throw new NotImplementedException();
        }
    }
}
