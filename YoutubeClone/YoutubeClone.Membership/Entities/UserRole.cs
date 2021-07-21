using Microsoft.AspNetCore.Identity;

namespace YoutubeClone.Membership.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        protected bool Equals(UserRole other)
        {
            return RoleId == other.RoleId
                && UserId == other.UserId;
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
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((UserRole)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 0;
                hashCode = RoleId.GetHashCode();
                hashCode = (hashCode * 397) ^ UserId.GetHashCode();
                return hashCode;
            }
        }
    }
}
