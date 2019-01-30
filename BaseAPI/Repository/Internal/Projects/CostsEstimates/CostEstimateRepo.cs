using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Projects.CostEstimates;
using BaseAPI.Models;

namespace BaseAPI.Repository.Internal.Projects.CostsEstimates
{
    public class CostEstimateRepo : ICostEstimateRepo
    {
        private BaseApiContext _context;
        public CostEstimateRepo(BaseApiContext context)
        {
            _context = context;
        }

        public IEnumerable<CostEstimate> getAll()
        {
            return _context.CostEstimates.ToList();
        }
        public CostEstimate getById(int id)
        {
            return _context.CostEstimates.Where(obj => obj.CostEstimateId == id).SingleOrDefault();
        }
        public bool add(CostEstimate costEstimate)
        {
            try
            {
                _context.CostEstimates.Add(costEstimate);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool update(int id, CostEstimate costEstimate)
        {
            costEstimate.CostEstimateId = id;
            try
            {
                _context.CostEstimates.Update(costEstimate);
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
                _context.CostEstimates.Remove(tmp);
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
