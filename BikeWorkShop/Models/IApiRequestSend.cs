using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeWorkShop.Models
{
    public interface IApiRequestSend<T>
    {
        IEnumerable<T> GetAllData();
        decimal GetRepairCost(string item);
        void AddEntity(string item, decimal cost);
        void ModifyEntity(int id, T item);
        void DeleteEntity(T item);
    }
}
