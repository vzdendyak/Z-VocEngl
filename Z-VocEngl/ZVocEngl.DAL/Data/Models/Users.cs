using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZVocEngl.DAL.Data.Models
{
    public class Users : IdentityUser
    {
        private string Info { get; set; }

        public virtual ICollection<Vocabularies> Vocabularies { get; set; }
    }
}