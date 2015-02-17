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
            if (key == null) throw new ArgumentNullException("key");
            if (message == null) throw new ArgumentNullException("message");

            return transform(key, message, (msgGroup, keyGroup) => msgGroup.Add(keyGroup));
        }

        public string Decrypt(Deck key, string message)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (message == null) throw new ArgumentNullException("message");

            return transform(key, message, (msgGroup, keyGroup) => msgGroup.Subtract(keyGroup));
        }

        private CharacterGroup nextStreamGroup(DeckKeystream key)
        {
            return new CharacterGroup(key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext(), key.GetNext());
        }

        private string transform(Deck key, string message, Func<NumberGroup, NumberGroup, NumberGroup> combine)
        {
            var stream = new DeckKeystream(key);
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
