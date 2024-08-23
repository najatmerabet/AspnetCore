using api.Dtos.Stock;
using api.Models;
namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto (this Stock stockModel)
        {
            return new StockDto
            {
                Id= stockModel.Id,
                Symbol= stockModel.Symbol,
                Company=stockModel.Company,
                LastDiv=stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap=stockModel.MarketCap,
            };
        }

       public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto )
       {
            return new Stock
            {
              Symbol=stockDto.Symbol,
              Company= stockDto.Company,
              LastDiv=stockDto.LastDiv,
              Industry=stockDto.Industry,
              MarketCap=stockDto.MarketCap
            };
       }

    }
}