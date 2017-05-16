using PC.Business.Rules;
using PC.Objects;
using PC.Objects.RuleConfigs;
using System.Collections.Generic;
using System.Linq;

namespace PC.Business
{
    public class PremiumCalculation
    {
        private PremiumRuleConfig config;
        public PremiumCalculation(PremiumRuleConfig config)
        {
            this.config = config;
        }

        public double Calculate(MemberObject member)
        {
            double percent = 1;
            foreach(IRule rule in this.getRules(member))
            {
                percent += rule.Execute();
            }
            return this.getBasePremium(member) + (this.getBasePremium(member) * (percent/100));
        }

        private List<IRule> getRules(MemberObject member)
        {
            List<IRule> rules = new List<IRule>
            {
                new AgeRule(member, this.config),
                new GenderRule(member, this.config),
                new HabitRule(member, this.config),
                new PreConditionRule(member, this.config)
            };
            return rules;
        }

        private double getBasePremium(MemberObject member)
        {
            BasePremium bpConfig = this.config.BasePremiumRule.Where(r => this.validate(r, member)).FirstOrDefault();
            return bpConfig.Premium;
        }

        private bool validate(BasePremium bpConfig, MemberObject member)
        {
            return (member.Age >= bpConfig.MinAge && (member.Age <= bpConfig.MaxAge || bpConfig.MaxAge == 0));
        }
    }
}
