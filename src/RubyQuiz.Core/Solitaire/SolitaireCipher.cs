using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RubyQuiz.Core.Solitaire
{
    public class SolitaireCipher
    {
        public string Encrypt(Deck key, string message)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (message == null) throw new ArgumentNullException(nameof(message));

            return Transform(key, message, (msgGroup, keyGroup) => msgGroup.Add(keyGroup));
        }

        public string Decrypt(Deck key, string message)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (message == null) throw new ArgumentNullException(nameof(message));

            return Transform(key, message, (msgGroup, keyGroup) => msgGroup.Subtract(keyGroup));
        }

        private static CharacterGroup NextStreamGroup(DeckKeystream key)
        {
            return new CharacterGroup(key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext());
        }

        private static string Transform(Deck key, string message, Func<NumberGroup, NumberGroup, NumberGroup> combine)
        {
            var stream = new DeckKeystream(key);
            var messageGroups = CharacterGroup.CreateSequence(MessageSanitizer.Sanitize(message));

            var buffer = new StringBuilder();
            foreach (var group in messageGroups)
            {
                var messageNumberGroup = group.ToNumberGroup();
                var keystreamNumberGroup = NextStreamGroup(stream).ToNumberGroup();
                var resultGroup = combine(messageNumberGroup, keystreamNumberGroup);
                buffer.Append(resultGroup.ToCharacterGroup());
            }

            return buffer.ToString();
        }
    }
}
