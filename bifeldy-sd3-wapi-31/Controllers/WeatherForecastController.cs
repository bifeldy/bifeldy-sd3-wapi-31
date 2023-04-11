using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using bifeldy_sd3_lib_31.Utilities;

using bifeldy_sd3_wapi_31.Models;
using bifeldy_sd3_wapi_31.Handlers;
using System.Data;
using System.Net;

namespace bifeldy_sd3_wapi_31.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger _logger;
        private readonly IDb _db;

        public WeatherForecastController(ILogger logger, IDb db) {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<ObjectResult> Get() {
            int rnd = new Random().Next();
            DataTable dt = new DataTable();
            DateTime d = await _db.OraPg_GetCurrentDate();

            //
            // return Ok(new {
            //     info = $"😅 200 - ${this.GetType()} :: List All 🤣",
            //     results = dt.AsEnumerable().Select(d => d.ItemArray)
            // });
            //

            try {
                throw new Exception("ahahah");
            }
            catch (Exception ex) {
                return BadRequest(new {
                    info = $"🙄 400 - {GetType().Name} :: List All 😪",
                    result = new {
                        random_number = rnd,
                        message = "Data Tidak Lengkap",
                        current_date = d
                    },
                    results = dt.AsEnumerable().Select(d => d.ItemArray)
                });
            }

        }

    }

}
