﻿using AutoReservation.Common.DataTransferObjects;
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
        IList<AutoDto> Autos();

        [OperationContract]
        AutoDto GetAuto(int id);

        [OperationContract]
        void AddAuto(AutoDto auto);

        [OperationContract]
        void UpdateAuto(AutoDto modified, AutoDto original);

        [OperationContract]
        void DeleteAuto(AutoDto auto);


        /**
         * Kunde
         */

        [OperationContract]
        IList<KundeDto> Kunden();

        [OperationContract]
        KundeDto GetKunde(int id);

        [OperationContract]
        void AddKunde(KundeDto kunde);

        [OperationContract]
        void UpdateKunde(KundeDto modified, KundeDto original);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        /**
         * Reservation
        */

        [OperationContract]
        IList<ReservationDto> Reservationen();

        [OperationContract]
        ReservationDto GetReservation(int id);

        [OperationContract]
        void AddReservation(ReservationDto reservation);

        [OperationContract]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);

    }
}
