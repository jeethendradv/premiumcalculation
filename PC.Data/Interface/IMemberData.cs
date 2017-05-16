using PC.Objects;
using System.Collections.Generic;

namespace PC.Data.Interface
{
    public interface IMemberData
    {
        void Insert(MemberObject member);
        List<MemberObject> GetAllMembers();
    }
}
