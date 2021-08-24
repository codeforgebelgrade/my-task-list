using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toDoAPP.Models;

namespace toDoAPP.Service
{
    public interface IObavezeService
    {
        IEnumerable<Obaveze> GetAll();
        void napraviObavezu(Obaveze novaObaveza);
        ContentResult proveriPodatke(Obaveze novaObaveza);
    }
}
