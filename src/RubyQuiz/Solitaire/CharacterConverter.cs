namespace RubyQuiz.Solitaire
{
    public static class CharacterConverter
    {
        public static byte EncodeChar(char c)
        {
            return (byte) (c - 64);
        }

        public static char DecodeChar(byte b)
        {
            return (char) (b + 64);
        }
    }
}
