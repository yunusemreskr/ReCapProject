﻿using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager ( IBrandDal brandDal) 
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var addedEntity = context.Entry(brand);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deletedEntity = context.Entry(brand);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetCarsByBrandId(int id)
        {
            return _brandDal.Get(b=>b.BrandId == id);
        }

        public void Update(Brand brand)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updatedEntity = context.Entry(brand);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
