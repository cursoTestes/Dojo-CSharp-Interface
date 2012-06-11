using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DojoInterfaceApplication.Models
{

    #region Models
  

    public class VendaModel
    {
        [Required]
        [DisplayName("Id Vendedor")]
        public string Vendedor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data Venda")]
        public DateTime DataVenda { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Valor")]
        public  String Valor { get; set; }

        
    }

 
    #endregion

   

}
