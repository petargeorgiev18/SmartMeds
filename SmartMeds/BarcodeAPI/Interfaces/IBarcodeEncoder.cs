using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeAPI.Implementation;

namespace BarcodeAPI.Interfaces
{
    internal interface IBarcodeEncoder
    {
        Task<BarcodeResponseFormat> GetTitleByBarcode(string imageUrl);

        Task<bool> CheckHealth();
    }
}
