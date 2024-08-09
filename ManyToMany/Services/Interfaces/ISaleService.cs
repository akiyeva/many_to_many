using ManyToMany.DTOs.SaleDtos;
using ManyToMany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.Services.Interfaces;

public interface ISaleService
{
    Task AddSaleAsync(SaleDto saleDto);
    Task<List<Sale>> GetAllSalesAsync();
}
