using PetShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service.Services
{
    public class AgeService:IAgeService
    {
        public string Age(DateTime? birthDate)
        {
            if (birthDate!=null)
            {
                DateTime now = DateTime.Today;
                int age = now.Year - birthDate.Value.Year;
                if (birthDate > now.AddYears(-age)&&age>1) age--;
                if (age==0)
                    return (now.Month-birthDate.Value.Month).ToString()+" Months";     
                return age.ToString()+" Years";
            }
            return "No Age";
        }

    }
}
