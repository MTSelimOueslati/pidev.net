using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dari.Models
{
	[Serializable]
	public class Role
	{

		private const long serialVersionUID = 1L;

		public int idRole;

		public Erole roleType;
		

		public Role() : base()
		{
		}

		public virtual int IdRole
		{
			get
			{
				return idRole;
			}
			set
			{
				this.idRole = value;
			}
		}





		public virtual Erole RoleType
		{
			get
			{
				return roleType;
			}
			set
			{
				this.roleType = value;
			}
		}


	}
}