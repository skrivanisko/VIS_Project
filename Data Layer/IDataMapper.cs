using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.DataMapper
{
    public interface IDataMapper<T>
    {
        int Delete(int id);
        int Insert(T t);
        Collection<T> Select();
        int Update(T t);
    }
}
