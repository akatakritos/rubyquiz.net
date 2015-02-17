using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Santa
{
    public class Person : IEquatable<Person>
    {

        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _email;

        public Person(string firstName, string lastName, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string Email
        {
            get { return _email; }
        }

        public bool CanGiveTo(Person givee)
        {
            return !IsInSameFamily(givee);
        }

        public bool IsInSameFamily(Person other)
        {
            return other.LastName == this.LastName;
        }

        #region Resharper Equality Comparisons
        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(_firstName, other._firstName) && string.Equals(_lastName, other._lastName) && string.Equals(_email, other._email);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_firstName != null ? _firstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_lastName != null ? _lastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_email != null ? _email.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Person left, Person right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
