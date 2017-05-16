using PC.Objects.RuleConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Objects
{
    public class PremiumRuleConfig
    {
        public List<BasePremium> BasePremiumRule { get; set; }
        public List<AgeConfig> AgeRule { get; set; }
        public List<GenderConfig> GenderRule { get; set; }
        public List<PreconditionConfig> PreconditionsRule { get; set; }
        public List<HabitConfig> HabitsRule { get; set; }
    }
}
