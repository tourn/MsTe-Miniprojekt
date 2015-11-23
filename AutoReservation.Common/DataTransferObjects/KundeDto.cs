﻿using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;
using System.Text;
using System;
using System.Runtime.Serialization;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class KundeDto : DtoBase<KundeDto>
    {

        private int id;
        [DataMember]
        public int Id
        {
            get { return id; }
            set
            {
                if (id == value)
                {
                    return;
                }
                id = value;
                this.OnPropertyChanged(p => p.Id);
            }
        }

        private string nachname;
        [DataMember]
        public string Nachname
        {
            get { return nachname; }
            set
            {
                if(nachname == value)
                {
                    return;
                }
                nachname = value;
                this.OnPropertyChanged(p => p.Nachname);
            }
        }

        private string vorname;
        [DataMember]
        public string Vorname
        {
            get { return vorname; }
            set
            {
                if (vorname == value)
                {
                    return;
                }
                vorname = value;
                this.OnPropertyChanged(p => p.Vorname);
            }
        }

        private DateTime geburtsdatum;
        [DataMember]
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set
            {
                if (geburtsdatum == value)
                {
                    return;
                }
                geburtsdatum = value;
                this.OnPropertyChanged(p => p.Geburtsdatum);
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Nachname))
            {
                error.AppendLine("- Nachname ist nicht gesetzt.");
            }
            if (string.IsNullOrEmpty(Vorname))
            {
                error.AppendLine("- Vorname ist nicht gesetzt.");
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                error.AppendLine("- Geburtsdatum ist nicht gesetzt.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override KundeDto Clone()
        {
            return new KundeDto
            {
                Id = Id,
                Nachname = Nachname,
                Vorname = Vorname,
                Geburtsdatum = Geburtsdatum
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}",
                Id,
                Nachname,
                Vorname,
                Geburtsdatum);
        }
    }
}
