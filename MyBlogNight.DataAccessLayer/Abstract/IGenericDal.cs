﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.DataAccessLayer.Abstract
{
    /*Burada temel CRUD ve Listeleme işlemleri tanımlanır. Bu işlemlerin içeriği GenericRepository
     içerisinde detaylandırılır.
    */
    public interface IGenericDal<T> where T : class
    {
        void Insert (T entity);
        void Update (T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById (int id);
    }
}
