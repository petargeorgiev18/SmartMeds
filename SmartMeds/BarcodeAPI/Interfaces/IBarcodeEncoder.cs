using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeAPI.Interfaces
{
    internal interface IBarcodeEncoder
    {
        Task<String> GetTitleByBarcode(string imageUrl);

        Task<Boolean> CheckHealth();
    }
}
