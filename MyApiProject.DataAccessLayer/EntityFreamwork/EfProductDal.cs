﻿using MyApiProject.DataAccessLayer.Abstract;
using MyApiProject.DataAccessLayer.Contect;
using MyApiProject.DataAccessLayer.Repositories;
using MyApiProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiProject.DataAccessLayer.EntityFreamwork
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(ApiContext context) : base(context)
		{
		}
	}
}
