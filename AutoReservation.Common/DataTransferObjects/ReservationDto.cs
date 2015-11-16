using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;
using System;

namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto : DtoBase<ReservationDto>
    {
        private DateTime von;
        public DateTime Von {
            get { return von; }
            private set
            {
                if(von == value) { return; }
                von = value;
                this.OnPropertyChanged(p => p.von);
            }
        }

        private DateTime bis;
        public DateTime Bis {
            get { return bis; }
            private set
            {
                if(bis == value) { return; }
                bis = value;
                this.OnPropertyChanged(p => p.bis);
            }
        }

        private AutoDto auto;
        public AutoDto Auto {
            get { return auto; }
            private set
            {
                if(auto == value) { return; }
                auto = value;
                this.OnPropertyChanged(p => p.auto);
            }
        }

        private KundeDto kunde;
        public KundeDto Kunde {
            get { return kunde; }
            private set
            {
                if(kunde == value) { return; }
                kunde = value;
                this.OnPropertyChanged(p => p.kunde);
            }
        }

        private int reseravtionNr;
        public int ReservationNr {
            get { return reseravtionNr; }
            private set
            {
                if(reseravtionNr == value) { return; }
                reseravtionNr = value;
                this.OnPropertyChanged(p => p.reseravtionNr);
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override ReservationDto Clone()
        {
            return new ReservationDto
            {
                ReservationNr = ReservationNr,
                Von = Von,
                Bis = Bis,
                Auto = Auto.Clone(),
                Kunde = Kunde.Clone()
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                ReservationNr,
                Von,
                Bis,
                Auto,
                Kunde);
        }
    }
}
