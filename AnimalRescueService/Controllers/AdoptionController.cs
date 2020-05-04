using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnimalRescueService.Models;
using AnimalRescueApp;

namespace AnimalRescueService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdoptionController : Controller
    {
        AnimalRescueRepo rep;
        public AdoptionController()
        {
            rep = new AnimalRescueRepo();
        }

        [HttpGet]
        public JsonResult GetAllForAdoption()
        {
            List<ForAdoption> forAdoptionList = new List<ForAdoption>();
            try
            {
                var adoptList = rep.GetAllForAdoption();
                if (adoptList != null)
                {
                    foreach (var item in adoptList)
                    {
                        forAdoptionList.Add(new ForAdoption()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Age = item.Age,
                            AnimalType = item.AnimalType,
                            Description=item.Description
                        });
                    }
                    return Json(forAdoptionList);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}