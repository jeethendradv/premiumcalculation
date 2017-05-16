using PC.Objects;
using PC.Objects.RuleConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Business.Rules
{
    public class AgeRule : IRule
    {
        private MemberObject member;
        private PremiumRuleConfig ruleConfig;

        public AgeRule(MemberObject member, PremiumRuleConfig ruleConfig)
        {
            this.member = member;
            this.ruleConfig = ruleConfig;
        }

        public double Execute()
        {
            AgeConfig config = ruleConfig.AgeRule.Where(validate).SingleOrDefault();
            return config != null ? config.Percent : 0;
        }

        private bool validate(AgeConfig ageconfig)
        {
            return (member.Age >= ageconfig.Min && member.Age <= ageconfig.Max) ||
                (member.Age >= ageconfig.Min && ageconfig.Max == 0);
        }
    }
}
