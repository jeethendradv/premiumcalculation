using Newtonsoft.Json;
using PC.Business;
using PC.Models;
using PC.Objects;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace PC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(this.GetMembers());
        }

        private List<MemberModel> GetMembers()
        {
            PremiumRuleConfig config = null;
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Config/config.json")))
            {
                config = JsonConvert.DeserializeObject<PremiumRuleConfig>(sr.ReadToEnd());
            }
            Member memberBusiness = BusinessFactory.getMember(config);
            return this.convertMemberObject(memberBusiness.GetAllMembers());
        }

        private List<MemberModel> convertMemberObject(List<MemberObject> members)
        {
            List<MemberModel> membermodels = new List<MemberModel>();
            foreach (MemberObject member in members)
            {
                membermodels.Add(new MemberModel
                {
                    Id = member.ID,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Age = member.Age,
                    Gender = member.Gender,
                    Premium = member.Premium,
                    Habits = member.Habits,
                    PreConditions = member.PreConditions
                });
            }
            return membermodels;
        }
    }
}
