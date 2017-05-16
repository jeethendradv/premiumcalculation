using PC.Objects;
using PC.Objects.RuleConfigs;
using System.Collections.Generic;
using System.Linq;

namespace PC.Business.Rules
{
    public class PreConditionRule : IRule
    {
        private MemberObject member;
        private PremiumRuleConfig ruleConfig;

        public PreConditionRule(MemberObject member, PremiumRuleConfig ruleConfig)
        {
            this.member = member;
            this.ruleConfig = ruleConfig;
        }

        public double Execute()
        {
            double percentage = 0;
            List<PreconditionConfig> config = this.ruleConfig.PreconditionsRule.Where(validate).ToList();
            config.ForEach(x => percentage += x.Percentage);

            return percentage;
        }

        private bool validate(PreconditionConfig config)
        {
            return this.member.PreConditions.Any(x => x.ToLower() == config.Precondition.ToLower());
        }
    }
}
