using Common.Base;
using Common.Param;
using Common.Result;
using Common.Type;
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
    public class ActividadesController : ControllerBase
    {
        IModelService _modelservice;
        public ActividadesController(IModelService modelservice)
        {
            this._modelservice = modelservice;
        }

        [HttpPost("CreateActividad")]
        public async Task<CreateActividadResult> CreateActividad([FromBody] CreateActividadParam param)
        {
            return await _modelservice.Execute(async (dbcontext) =>
            {
                var ret = new CreateActividadResult();
                if (param.Actividad.Id == 0)
                {
                    await dbcontext.Actividads.AddAsync(new Model.Entities.Sql.DataBase.Actividad
                    {
                        ProspectoId = param.Actividad.ProspectoId,
                        Calificacion = param.Actividad.Calificacion,
                        Descripcion = param.Actividad.Descripcion,
                        Fecha = param.Actividad.Fecha,
                        Tipo = (int)param.Actividad.Tipo
                    });
                    await dbcontext.SaveChangesAsync();
                }
                else
                {
                    var actividad = await dbcontext.Actividads.FirstOrDefaultAsync(p => p.Id == param.Actividad.Id);
                    if (actividad != null)
                    {
                        actividad.Calificacion = param.Actividad.Calificacion;
                        actividad.Descripcion = param.Actividad.Descripcion;
                        actividad.Fecha = param.Actividad.Fecha;
                        actividad.Tipo = (int)param.Actividad.Tipo;

                        await dbcontext.SaveChangesAsync();
                    }
                    else
                    {
                        ret.Result = ResultType.Warning;
                        ret.Message = "Actividad no encontrada";
                    }
                }
                return ret;
            });
        }
        [HttpGet("GetActividades")]
        public async Task<GetActividadesResult> GetActividades([FromQuery] int page, [FromQuery] int size, [FromQuery] long prospectoId)
        {
            return await _modelservice.Execute(async (dbcontext, configuration) =>
            {
                var ret = new GetActividadesResult();
                var new_page = page;
                var groups = 1;
                var prospectos = await dbcontext.Actividads.Where(p => p.ProspectoId == prospectoId).PagedTo(size, ref new_page, ref groups).ToListAsync();
                if (prospectos is not null)
                {
                    ret.Actividades.AddRange(prospectos.Select(prospecto =>
                        new ActividadBase
                        {
                            Id = prospecto.Id,
                            ProspectoId = prospecto.ProspectoId,
                            Calificacion = prospecto.Calificacion,
                            Descripcion = prospecto.Descripcion,
                            Fecha = prospecto.Fecha,
                            Tipo = (ActividadType)prospecto.Tipo
                        }
                    ).ToList());
                }
                return ret;
            });
        }
        [HttpGet("GetActividad")]
        public async Task<GetActividadResult> GetActividad([FromQuery] int actividadId)
        {
            return await _modelservice.Execute(async (dbcontext, configuration) =>
            {
                var ret = new GetActividadResult();

                var actividad = await dbcontext.Actividads.FirstOrDefaultAsync(p => p.Id == actividadId);
                if (actividad is not null)
                {
                    ret.Actividad = new ActividadBase
                    {
                        Id = actividad.Id,
                        ProspectoId = actividad.ProspectoId,
                        Calificacion = actividad.Calificacion,
                        Descripcion = actividad.Descripcion,
                        Fecha = actividad.Fecha,
                        Tipo = (ActividadType)actividad.Tipo
                    };
                }
                else
                {
                    ret.Result = ResultType.Warning;
                    ret.Message = "Actividad no encontrada";
                }
                return ret;
            });
        }
        [HttpGet("DeleteActividad")]
        public async Task<DeleteActividadResult> DeleteActividad([FromQuery] int actividadId)
        {
            return await _modelservice.Execute(async (dbcontext, configuration) =>
            {
                var ret = new DeleteActividadResult();

                var actividad = await dbcontext.Actividads.FirstOrDefaultAsync(p => p.Id == actividadId);
                if (actividad is not null)
                {
                    dbcontext.Remove(actividad);
                    dbcontext.SaveChanges();
                }
                else
                {
                    ret.Result = ResultType.Warning;
                    ret.Message = "Actividad no encontrada";
                }
                return ret;
            });
        }
    }
}
