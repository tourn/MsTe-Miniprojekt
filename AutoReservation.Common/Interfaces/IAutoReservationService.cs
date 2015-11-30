using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract] // TODO Namespace?
    public interface IAutoReservationService
    {
        /**
         * Auto 
         */

        [OperationContract]
        IList<AutoDto> GetAutos();

        [OperationContract]
        AutoDto GetAuto(int id);

        [OperationContract]
        void AddAuto(AutoDto auto);

        [OperationContract]
        [FaultContract(typeof(AutoDto))]
        void UpdateAuto(AutoDto modified, AutoDto original);

        [OperationContract]
        void DeleteAuto(AutoDto auto);


        /**
         * Kunde
         */

        [OperationContract]
        IList<KundeDto> GetKunden();

        [OperationContract]
        KundeDto GetKunde(int id);

        [OperationContract]
        void AddKunde(KundeDto kunde);

        [OperationContract]
        [FaultContract(typeof(KundeDto))]
        void UpdateKunde(KundeDto modified, KundeDto original);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        /**
         * Reservation
        */

        [OperationContract]
        IList<ReservationDto> GetReservationen();

        [OperationContract]
        ReservationDto GetReservation(int id);

        [OperationContract]
        void AddReservation(ReservationDto reservation);

        [OperationContract]
        [FaultContract(typeof(ReservationDto))]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);

    }
}
