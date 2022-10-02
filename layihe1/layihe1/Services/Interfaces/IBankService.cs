using layihe1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace layihe1.Services.Interfaces
{
    public interface IBankService<T> where T : BaseModel
    {
        public void Create(T emplye);
        public T Update(T entity,string dataToUptdate);
        public bool Delete(string name);
        public T Get(string filter);
        public void GetAll();
    }
}
