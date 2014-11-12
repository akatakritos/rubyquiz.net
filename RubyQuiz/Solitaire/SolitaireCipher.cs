using System;
using System.Text;

namespace RubyQuiz.Solitaire
{
    public class SolitaireCipher
    {
        public string Encrypt(Deck key, string message)
        {
            return transform(key, message, (msgGroup, keyGroup) => msgGroup.Add(keyGroup));
        }

        private CharacterGroup nextStreamGroup(DeckKeystream key)
        {
            return new CharacterGroup(key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext());
        }

        public string Decrypt(Deck key, string message)
        {
            return transform(key, message, (msgGroup, keyGroup) => msgGroup.Subtract(keyGroup));
        }

        private string transform(Deck key, string message, Func<NumberGroup, NumberGroup, NumberGroup> combine)
        {
            var stream = new DeckKeystream(key.Clone());
            var messageGroups = CharacterGroup.CreateSequence(MessageSanitizer.Sanitize(message));

            var buffer = new StringBuilder();
            foreach (var group in messageGroups)
            {
                var messageNumberGroup = group.ToNumberGroup();
                var keystreamNumberGroup = nextStreamGroup(stream).ToNumberGroup();
                var resultGroup = combine(messageNumberGroup, keystreamNumberGroup);
                buffer.Append(resultGroup.ToCharacterGroup());
            }

            return buffer.ToString();
        }
    }
}
