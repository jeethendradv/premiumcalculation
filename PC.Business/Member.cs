using PC.Data.Interface;
using PC.Objects;
using System.Collections.Generic;

namespace PC.Business
{
    public class Member
    {
        private IMemberData memberData;
        private PremiumRuleConfig ruleConfig;

        public Member(IMemberData memberData, PremiumRuleConfig config)
        {
            this.memberData = memberData;
            this.ruleConfig = config;
        }

        public void Add(MemberObject member)
        {
            this.memberData.Insert(member);
        }

        public List<MemberObject> GetAllMembers()
        {
            PremiumCalculation premiumCalculation = new PremiumCalculation(this.ruleConfig);
            List<MemberObject> members = this.memberData.GetAllMembers();
            foreach (MemberObject member in members)
            {
                member.Premium = premiumCalculation.Calculate(member);
            }
            return members;
        }
    }
}
