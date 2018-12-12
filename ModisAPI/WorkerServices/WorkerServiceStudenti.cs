using Microsoft.EntityFrameworkCore;
using ModisAPI.Models;
using ModisAPI.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.WorkerServices
{
    public class WorkerServiceSQLServerDb : IWorkerServiceStudenti
    {
        private ModisContext db;
        public WorkerServiceSQLServerDb() {
            db = new ModisContext();
        }

        public void CancellaStudente(int id)
        {
            var studente = db.Studenti.Find(id);
            if(studente !=null)
            {
                db.Entry(studente).State =
                    Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void CreaStudente(Studente studente)
        {
            db.Studenti.Add(studente);
            db.SaveChanges();
        }

        public void ModificaStudente(Studente studenteModificato)
        {
           /* var studente = db.Studenti.Find(studenteModificato.Id);
            studente.Cognome = studenteModificato.Cognome;
            studente.Nome = studenteModificato.Nome;
            studente.Indirizzo = studenteModificato.Indirizzo;*/

            db.Entry(studenteModificato).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public List<ViewModelStudente> RestituisciListaStudenti()
        {
            return db.Studenti.Include("Corsi").
                Select(y => new ViewModelStudente
                {
                    Id = y.Id,
                    NomeCompleto = y.Nome + " " + y.Cognome,
                    Corsi = y.StudenteCorsi.Select(
                    z => new Corso
                    {  CorsoId = z.Corso.CorsoId,
                        DataInizio = z.Corso.DataInizio,
                        Nome=z.Corso.Nome,
                        DurataInOre=z.Corso.DurataInOre,
                        NumeroMassimoPerPartecipanti=z.Corso.NumeroMassimoPerPartecipanti,
                        Livello = z.Corso.Livello
                    }).ToList()
                }).ToList();
                     }

        public Studente RestituisciStudente(int id)
        {
            throw new NotImplementedException();
        }
    }
    }
    public class WorkerServiceOracleDb : IWorkerServiceStudenti
    {
        public void CancellaStudente(int id)
        {
            throw new NotImplementedException();
        }

        public void CreaStudente(Studente studente)
        {
            throw new NotImplementedException();
        }

        public void ModificaStudente(Studente studenteModificato)
        {
            throw new NotImplementedException();
        }

        public List<Studente> RestituisciListaStudenti()
        {
            throw new NotImplementedException();
        }

        public Studente RestituisciStudente(int id)
        {
            throw new NotImplementedException();
        }

    List<ViewModelStudente> IWorkerServiceStudenti.RestituisciListaStudenti()
    {
        throw new NotImplementedException();
    }
}

    public class WorkerServiceStudenti : IWorkerServiceStudenti
    {
        public void CancellaStudente(int id)
        {
            throw new NotImplementedException();
        }

        public void CreaStudente(Studente studente)
        {
            throw new NotImplementedException();
        }

        public void ModificaStudente(Studente studenteModificato)
        {
            throw new NotImplementedException();
        }

        public List<Studente> RestituisciListaStudenti()
        {
            var studente1 = new Studente { Id = 1, Cognome = "Mario", Nome = "Rossi" };
            var studente2 = new Studente { Id = 2, Cognome = "MastroCesare", Nome = "Francesco" };
            return new List<Studente> { studente1, studente2 };
        }

        public Studente RestituisciStudente(int id)
        {
            return RestituisciListaStudenti().Where(x => x.Id == id).FirstOrDefault();
        }

    List<ViewModelStudente> IWorkerServiceStudenti.RestituisciListaStudenti()
    {
        throw new NotImplementedException();
    }
}

