using Dapper;
using PC.Data.DataObjects;
using PC.Data.Interface;
using PC.Objects;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PC.Data
{
    public class MemberData : IMemberData
    {
        public void Insert(MemberObject member)
        {
            string preConditions = member.PreConditions != null ? string.Join(",", member.PreConditions) : string.Empty;
            string habits = member.Habits != null ? string.Join(",", member.Habits) : string.Empty;
            Member memberData = new Member
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Age = member.Age,
                Gender = member.Gender,
                PreConditions = preConditions,
                Habits = habits
            };
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["pc"].ConnectionString))
            {
                string sql = "INSERT INTO Member(FirstName,LastName,Age,Gender,PreConditions,Habits) values(@FirstName,@LastName,@Age,@Gender,@PreConditions,@Habits)";

                db.Execute(sql, memberData);
            }
        }

        public List<MemberObject> GetAllMembers()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["pc"].ConnectionString))
            {
                string sql = "SELECT FirstName,LastName,Age,Gender,PreConditions,Habits FROM Member";
                List<Member> members = db.Query<Member>(sql).AsList<Member>();
                return this.convertMemberObject(members);
            }
        }

        private List<MemberObject> convertMemberObject(List<Member> members)
        {
            List<MemberObject> memberObjects = new List<MemberObject>();
            foreach (Member member in members)
            {
                MemberObject memberObject = new MemberObject
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Age = member.Age,
                    Gender = member.Gender,
                    Habits = string.IsNullOrEmpty(member.Habits) ? new List<string>() : member.Habits.Split(',').AsList<string>(),
                    PreConditions = string.IsNullOrEmpty(member.PreConditions) ? new List<string>() : member.PreConditions.Split(',').AsList<string>()
                };
                memberObjects.Add(memberObject);
            }
            return memberObjects;
        }
    }
}
