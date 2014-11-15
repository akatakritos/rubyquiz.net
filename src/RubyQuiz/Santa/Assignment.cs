using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Santa
{
    public struct Assignment : IEquatable<Assignment>
    {
        private readonly Person _santa;
        private readonly Person _receiver;

        public Assignment(Person santa, Person receiver)
        {
            if(santa == null) throw new ArgumentNullException("santa");
            if(receiver == null) throw new ArgumentNullException("receiver");

            _santa = santa;
            _receiver = receiver;
        }

        public Person Santa
        {
            get { return _santa; }
        }

        public Person Receiver
        {
            get { return _receiver; }
        }

        #region Resharper Generated Equality Tests
        public bool Equals(Assignment other)
        {
            return Equals(_santa, other._santa) && Equals(_receiver, other._receiver);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Assignment && Equals((Assignment)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_santa != null ? _santa.GetHashCode() : 0) * 397) ^ (_receiver != null ? _receiver.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Assignment left, Assignment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Assignment left, Assignment right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}