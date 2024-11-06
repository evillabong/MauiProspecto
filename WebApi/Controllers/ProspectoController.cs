using Common.Base;
using Common.Param;
using Common.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Extensions;
using WebApi.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectoController : ControllerBase
    {
        IModelService _modelservice;
        public ProspectoController(IModelService modelservice)
        {
            this._modelservice = modelservice;
        }

        [HttpPost("CreateProspecto")]
        public async Task<CreateProspectoResult> CreateProspecto([FromBody] CreateProspectoParam param)
        {
            return await _modelservice.Execute(async (dbcontext) =>
            {
                var ret = new CreateProspectoResult();

                var prospecto = await dbcontext.Prospectos.FirstOrDefaultAsync(p => p.Nombre == param.Prospecto.Nombre);
                if (prospecto is null)
                {
                    await dbcontext.Prospectos.AddAsync(new Model.Entities.Sql.DataBase.Prospecto
                    {
                        Nombre = param.Prospecto.Nombre,
                        Celular = param.Prospecto.Celular,
                        CorreoElectronico = param.Prospecto.CorreoElectronico
                    });
                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    ret.Result = Common.Type.ResultType.Warning;
                    ret.Message = "Existe un prospecto con el mismo nombre";
                }
                return ret;
            });
        }

        [HttpPost("EditProspecto")]
        public async Task<EditProspectoResult> EditProspecto([FromBody] EditProspectoParam param)
        {
            return await _modelservice.Execute(async (dbcontext) =>
            {
                var ret = new EditProspectoResult();

                var prospecto = await dbcontext.Prospectos.FirstOrDefaultAsync(p => p.Id == param.Prospecto.Id);
                if (prospecto is not null)
                {
                    prospecto.Nombre = param.Prospecto.Nombre;
                    prospecto.Celular = param.Prospecto.Celular;
                    prospecto.CorreoElectronico = param.Prospecto.CorreoElectronico;

                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    ret.Result = Common.Type.ResultType.Warning;
                    ret.Message = "Existe un prospecto con el mismo nombre";
                }
                return ret;
            });
        }

        [HttpGet("GetProspectos")]
        public async Task<GetProspectosResult> GetProspectos([FromQuery] int page, [FromQuery] int size)
        {
            return await _modelservice.Execute(async (dbcontext, configuration) =>
            {
                var ret = new GetProspectosResult();
                var new_page = page;
                var groups = 1;
                var prospectos = await dbcontext.Prospectos.PagedTo(size, ref new_page, ref groups).ToListAsync();
                if (prospectos is not null)
                {
                    ret.Prospectos.AddRange(prospectos.Select(prospecto =>
                        new ProspectoBase
                        {
                            Id = prospecto.Id,
                            Nombre = prospecto.Nombre,
                            Celular = prospecto.Celular,
                            CorreoElectronico = prospecto.CorreoElectronico
                        }
                    ).ToList());
                }
                return ret;
            });
        }

        [HttpGet("GetProspecto")]
        public async Task<GetProspectoResult> GetProspecto([FromQuery] long id)
        {
            return await _modelservice.Execute(async (dbcontext, configuration) =>
            {
                var ret = new GetProspectoResult();

                var prospecto = await dbcontext.Prospectos.FirstOrDefaultAsync(p => p.Id == id);
                if (prospecto is not null)
                {
                    ret.Prospecto = new ProspectoBase
                    {
                        Id = prospecto.Id,
                        Nombre = prospecto.Nombre,
                        Celular = prospecto.Celular,
                        CorreoElectronico = prospecto.CorreoElectronico
                    };
                }
                else
                {
                    ret.Result = Common.Type.ResultType.Warning;
                    ret.Message = "Prospecto no encotrado.";
                }
                return ret;
            });
        }

        [HttpGet("DeleteProspecto")]
        public async Task<DeleteProspectoResult> DeleteProspecto([FromQuery] long id)
        {
            return await _modelservice.Execute(async (dbcontext, configuration) =>
            {
                var ret = new DeleteProspectoResult();

                var actividades = dbcontext.Actividads.Where(p => p.ProspectoId == id);

                if (actividades.Any())
                {
                    dbcontext.Actividads.RemoveRange(actividades);
                    await dbcontext.SaveChangesAsync();
                }


                var prospectos = dbcontext.Prospectos.Where(p => p.Id == id);

                if (prospectos.Any())
                {
                    dbcontext.Prospectos.RemoveRange(prospectos);
                    await dbcontext.SaveChangesAsync();
                }

                return ret;
            });
        }
    }
}
