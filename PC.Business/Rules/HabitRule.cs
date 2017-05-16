using PC.Objects;
using PC.Objects.RuleConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Business.Rules
{
    class HabitRule : IRule
    {
        private MemberObject member;
        private PremiumRuleConfig ruleConfig;

        public HabitRule(MemberObject member, PremiumRuleConfig ruleConfig)
        {
            this.member = member;
            this.ruleConfig = ruleConfig;
        }

        public double Execute()
        {
            double percentage = 0;
            List<HabitConfig> config = this.ruleConfig.HabitsRule.Where(validate).ToList();
            config.ForEach(x => percentage += x.Percentage);

            return percentage;
        }

        private bool validate(HabitConfig config)
        {
            return this.member.Habits.Any(x => x.ToLower() == config.Habit.ToLower());
        }
    }
}
