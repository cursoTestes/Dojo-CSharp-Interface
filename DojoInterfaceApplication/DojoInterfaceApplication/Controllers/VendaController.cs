using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoInterfaceApplication.Models;

namespace DojoInterfaceApplication
{
    public class VendaController : Controller
    {
        //
        // GET: /Venda/Add

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(VendaModel model)
        {
            bool vendaOk = true;

            if (String.IsNullOrEmpty(model.Valor)) vendaOk = false;
            if (String.IsNullOrEmpty(model.Vendedor)) vendaOk = false;
            if (DateTime.Compare(model.DataVenda, DateTime.Now) > 0 ) vendaOk = false;

            if (vendaOk)
            {
                  ViewData["Message"] = "Venda Salva com sucesso!";
                  return  RedirectToAction("Index", "Home");
            }

            ViewData["Message"] = "Algumas condições para o cadastro na venda nao sao satisfatorias!";
            return View();
        }

    }


   
}
