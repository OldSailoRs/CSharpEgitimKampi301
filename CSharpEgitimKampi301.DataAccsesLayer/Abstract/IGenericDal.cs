using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharpEgitimKampi301.DataAccsesLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        CodeIdentifier Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);

    }
}
