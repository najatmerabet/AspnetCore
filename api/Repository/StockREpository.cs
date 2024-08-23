using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockREpository:IStockRepository
    {
        private readonly ApplicationDbContext _context;

        //dependency injection
        public StockREpository (ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
           await _context.Stock.AddAsync(stockModel);
           await _context.SaveChangesAsync();
           return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockkModel=await _context.Stock.FirstOrDefaultAsync(x=>x.Id ==id);

            if(stockkModel ==null){
                return null;
            }
            _context.Stock.Remove(stockkModel);
            await _context.SaveChangesAsync();
            return stockkModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {

          return await _context.Stock.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockdto)
        {
           var existingStoc=await  _context.Stock.FirstOrDefaultAsync(x=>x.Id==id);
           if(existingStoc==null)
           {
            return null;
           }
        existingStoc.Symbol=stockdto.Symbol;
        existingStoc.Company=stockdto.Company;
        existingStoc.LastDiv=stockdto.LastDiv;
        existingStoc.Industry=stockdto.Industry;
        existingStoc.MarketCap=stockdto.MarketCap;
        await _context.SaveChangesAsync();
        return existingStoc;

        }
    }
}