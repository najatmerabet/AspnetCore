using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stock;
        public StockController(ApplicationDbContext context , IStockRepository StockRepo) 
        {
            _stock=StockRepo;
            _context=context;
        }

        [HttpGet]
    public async Task<IActionResult>  GetAll(){
        var stocks= await _stock.GetAllAsync();
       var stockDto =stocks .Select(s=> s.ToStockDto());
        return Ok(stocks);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id){
        var stock =await _stock.GetByIdAsync(id);
  if(stock== null){
       return NotFound();
    }
    return Ok (stock);
       
    }
      
      [HttpPost]
      public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
      {
        var stockModel=stockDto.ToStockFromCreateDTO();
       await _stock.CreateAsync(stockModel);
       await _context.SaveChangesAsync();
        return  CreatedAtAction(nameof(GetById), new {id=stockModel.Id},stockModel.ToStockDto());

      }

      [HttpPut]
      [Route("{id}")]
      public async Task< IActionResult> Update ([FromRoute] int id , [FromBody] UpdateStockRequestDto updateDto)
      {
        var stockModel = await _stock.UpdateAsync(id,updateDto);

        if(stockModel ==null)
        {
           return NotFound();
        }
        
       await _context.SaveChangesAsync();
        return Ok(stockModel.ToStockDto());
      }

      [HttpDelete ]
      [Route("{id}")]
      public async Task<IActionResult> Delete([FromRoute] int id )
      {
        var stockModel=await _stock.DeleteAsync(id);

        if(stockModel== null){
            return NotFound();
        }
      
        return NoContent();
      }
    }
}