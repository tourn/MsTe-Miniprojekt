using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        AutoReservationBusinessComponent businessComponent = new AutoReservationBusinessComponent();

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public IList<AutoDto> Autos()
        {
            WriteActualMethod();
            return businessComponent.GetAutos().ConvertToDtos();
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.DeleteAuto(auto.ConvertToEntity());
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.DeleteKunde(kunde.ConvertToEntity());
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.DeleteReservation(reservation.ConvertToEntity());
            throw new NotImplementedException();
        }

        public AutoDto GetAuto(int id)
        {
            WriteActualMethod();
            return businessComponent.GetAuto(id).ConvertToDto();
        }

        public KundeDto GetKunde(int id)
        {
            WriteActualMethod();
            return businessComponent.GetKunde(id).ConvertToDto();
        }

        public ReservationDto GetReservation(int id)
        {
            WriteActualMethod();
            return businessComponent.GetReservation(id).ConvertToDto();
        }

        public void AddAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.AddAuto(auto.ConvertToEntity());
        }

        public void AddKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.AddKunde(kunde.ConvertToEntity());
        }

        public void AddReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.AddReservation(reservation.ConvertToEntity());
        }

        public IList<KundeDto> Kunden()
        {
            WriteActualMethod();
            return businessComponent.GetKunden().ConvertToDtos();
        }

        public IList<ReservationDto> Reservationen()
        {
            WriteActualMethod();
            return businessComponent.GetReservationen().ConvertToDtos();
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            businessComponent.UpdateAuto(modified.ConvertToEntity(), original.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            businessComponent.UpdateKunde(modified.ConvertToEntity(), original.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            businessComponent.UpdateReservation(modified.ConvertToEntity(), original.ConvertToEntity());
        }
    }
}