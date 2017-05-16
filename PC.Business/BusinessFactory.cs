using PC.Data;
using PC.Data.Interface;
using PC.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Business
{
    public class BusinessFactory
    {
        public static Member getMember(PremiumRuleConfig config)
        {
            IMemberData memberData = new MemberData();
            return new Member(memberData, config);
        } 
    }
}
