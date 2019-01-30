using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models;
using BaseAPI.Models.Internal.Projects.CostEstimates;

namespace BaseAPI.Repository.Internal.Projects.CostsEstimates
{
    public class CostEstimateItemRepo : ICostEstimateItemRepo
    {
        private BaseApiContext _context;
        public CostEstimateItemRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<CostEstimateItem> getAll()
        {
            return _context.CostEstimateItems.ToList();
        }
        public CostEstimateItem getById(int id)
        {
            return _context.CostEstimateItems.Where(obj => obj.CostEstimateItemId == id).SingleOrDefault();
        }
        public bool add(CostEstimateItem costEstimateItem)
        {
            try
            {
                _context.CostEstimateItems.Add(costEstimateItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, CostEstimateItem costEstimateItem)
        {
            costEstimateItem.CostEstimateItemId = id;
            try
            {
                _context.CostEstimateItems.Update(costEstimateItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool delete(int id)
        {
            var tmp = getById(id);
            try
            {
                _context.CostEstimateItems.Remove(tmp);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
