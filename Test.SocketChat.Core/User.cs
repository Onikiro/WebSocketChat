using System;

namespace Test.SocketChat.Core
{
    public class User : IEquatable<User>
    {
        public string Nickname { get; }

        public string Status { get; }

        public User(string nickname, string status)
        {
            Nickname = nickname;
            Status = status;
        }

        public bool Equals(User other)
        {
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other)) 
                return true;

            return string.Equals(Nickname, other.Nickname, StringComparison.InvariantCultureIgnoreCase) && string.Equals(Status, other.Status, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
                return false;
            
            if (ReferenceEquals(this, obj)) 
                return true;
            
            if (obj.GetType() != GetType()) 
                return false;
            
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Nickname, StringComparer.InvariantCulture);
            hashCode.Add(Status, StringComparer.InvariantCulture);
            return hashCode.ToHashCode();
        }
    }
}