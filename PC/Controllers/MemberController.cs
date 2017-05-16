using Newtonsoft.Json;
using PC.Business;
using PC.Models;
using PC.Objects;
using System.IO;
using System.Web.Mvc;

namespace PC.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            PremiumRuleConfig config = this.getRuleConfig();
            return View(config);
        }

        public ActionResult Add(MemberModel member)
        {
            Member memberBusiness = BusinessFactory.getMember(this.getRuleConfig());
            MemberObject memberObject = new MemberObject
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Age = member.Age,
                Gender = member.Gender,
                Habits = member.Habits,
                PreConditions = member.PreConditions
            };
            memberBusiness.Add(memberObject);
            return Redirect("/Home/Index");
        }

        private PremiumRuleConfig getRuleConfig()
        {
            PremiumRuleConfig config = null;
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Config/config.json")))
            {
                config = JsonConvert.DeserializeObject<PremiumRuleConfig>(sr.ReadToEnd());
            }
            return config;
        }
    }
}