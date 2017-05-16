using PC.Objects;
using PC.Objects.RuleConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Business.Rules
{
    public class GenderRule : IRule
    {
        private MemberObject member;
        private PremiumRuleConfig ruleConfig;

        public GenderRule(MemberObject member, PremiumRuleConfig ruleConfig)
        {
            this.member = member;
            this.ruleConfig = ruleConfig;
        }

        public double Execute()
        {
            GenderConfig config = ruleConfig.GenderRule.Where(gender => gender.Gender.ToLower() == this.member.Gender.ToLower()).SingleOrDefault();
            return config != null ? config.Percent : 0;
        }
    }
}
