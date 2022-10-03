using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AP1_P1_Wandy.DAL;
using  AP1_P1_Wandy.Models;

namespace AP1_P1_Wandy.BLL
{
       public class RegistroBLL
     {
          private Contexto _contexto;

          public RegistroBLL(Contexto contexto)
          {
               _contexto = contexto;
          }

          public bool Existe(int RegistroId)
          {
               return _contexto.Aportes.Any(o => o.AportesId == RegistroId);
          }

          private bool Insertar(Aportes registro)
          {
               _contexto.Aportes.Add(registro);
               return _contexto.SaveChanges() > 0;
          }

          private bool Modificar(Aportes registro)
          {
               _contexto.Entry(registro).State = EntityState.Modified;
               return _contexto.SaveChanges() > 0;
          }

          public bool Guardar(Aportes registro)
          {
               if (!Existe(registro.AportesId))
                    return this.Insertar(registro);
               else
                    return this.Modificar(registro);
          }

          public bool Eliminar(Aportes registro)
          {
               _contexto.Entry(registro).State = EntityState.Deleted;
               return _contexto.SaveChanges() > 0;
          }

          public Aportes? Buscar(int registroId)
          {
               return _contexto.Aportes
                       .Where(o => o.AportesId == registroId)
                       .AsNoTracking()
                       .SingleOrDefault();
          }

          public List<Aportes> GetList(Expression<Func<Aportes, bool>> Criterio)
          {
               return _contexto.Aportes
                   .AsNoTracking()
                   .Where(Criterio)
                   .ToList();
          }
     }

}