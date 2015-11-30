using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;
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

        public IList<AutoDto> GetAutos()
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

        public IList<KundeDto> GetKunden()
        {
            WriteActualMethod();
            return businessComponent.GetKunden().ConvertToDtos();
        }

        public IList<ReservationDto> GetReservationen()
        {
            WriteActualMethod();
            return businessComponent.GetReservationen().ConvertToDtos();
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            try
            {
                WriteActualMethod();
                businessComponent.UpdateAuto(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (Exception e)
            {
                throw new FaultException<AutoDto>(modified, e.Message);
            }
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            try
            {
                WriteActualMethod();
                businessComponent.UpdateKunde(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (Exception e)
            {
                throw new FaultException<KundeDto>(modified, e.Message);
            }
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            try
            {
                WriteActualMethod();
                businessComponent.UpdateReservation(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (Exception e)
            {
                throw new FaultException<ReservationDto>(modified, e.Message);
            }
        }
    }
}