using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        public IList<Auto> GetAutos()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Autos.AsNoTracking().ToList();
            }
        }

        public Auto GetAuto(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Autos.AsNoTracking().SingleOrDefault(a => a.Id == id);
            }
        }

        public void UpdateAuto(Auto modified, Auto original)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Attach(auto);
                    context.Autos.Remove(auto);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, auto);
                }

            }
        }

        public void AddAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Add(auto);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, auto);
                }
            }
        }


        /**
         * Kunden
        */

        public IList<Kunde> GetKunden()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kunden.AsNoTracking().ToList();
            }
        }

        public Kunde GetKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kunden.AsNoTracking().SingleOrDefault(k => k.Id == id);
            }
        }

        public void deleteKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Attach(kunde);
                    context.Kunden.Remove(kunde);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, kunde);
                }
            }
        }

        public void UpdateKunde(Kunde modified, Kunde original)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void AddKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Add(kunde);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, kunde);
                }
            }
        }


        /**
         *  Reservation
        */
        public IList<Reservation> GetReservationen()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.AsNoTracking().ToList();
            }
        }

        public Reservation GetReservation(int reservationNr)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.AsNoTracking().SingleOrDefault(r => r.ReservationNr == reservationNr);
            }
        }

        public void DeleteReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Attach(reservation);
                    context.Reservationen.Remove(reservation);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, reservation);
                }

            }
        }

        public void UpdateReservation(Reservation modified, Reservation original)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }

            }
        }

        public void AddReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Add(reservation);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, reservation);
                }
            }
        }

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }
    }
}