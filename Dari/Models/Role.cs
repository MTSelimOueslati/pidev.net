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

		public int id ;

		public Erole name;
		

		public Role() : base()
		{
		}

		public virtual int Id
		{
			get
			{
				return id;
			}
			set
			{
				this.id = value;
			}
		}





		public virtual Erole Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}

		
	}
}