﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Extensions;
using AutoReservation.Ui.Factory;

namespace AutoReservation.Ui.ViewModels
{
    public class KundeViewModel : ViewModelBase
    {
        private readonly List<KundeDto> kundenOriginal = new List<KundeDto>();
        public KundeViewModel(IServiceFactory factory) : base(factory)
        {
            
        }

        public ObservableCollection<KundeDto> kunden;
        public ObservableCollection<KundeDto> Kunden
        {
            get
            {
                if (kunden == null)
                {
                    kunden = new ObservableCollection<KundeDto>();
                }
                return kunden;
            }
        }

        private KundeDto selectedKunde;
        public KundeDto SelectedKunde
        {
            get { return selectedKunde; }
            set
            {
                if (selectedKunde != value)
                {
                    selectedKunde = value;
                    this.OnPropertyChanged(p => p.selectedKunde);
                }
            }
        }


        #region Load-Command

        private RelayCommand loadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (loadCommand == null)
                {
                    loadCommand = new RelayCommand(
                        param => Load(),
                        param => CanLoad()
                    );
                }
                return loadCommand;
            }
        }

        protected override void Load()
        {
            Kunden.Clear();
            kundenOriginal.Clear();
            foreach (KundeDto kunde in Service.GetKunden())
            {
                Kunden.Add(kunde);
                kundenOriginal.Add((KundeDto)kunde.Clone());
            }
            SelectedKunde = Kunden.FirstOrDefault();
        }

        private bool CanLoad()
        {
            return ServiceExists;
        }

        #endregion

        #region Save-Command

        private RelayCommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new RelayCommand(
                        param => SaveData(),
                        param => CanSaveData()
                    );
                }
                return saveCommand;
            }
        }

        private void SaveData()
        {
            foreach (KundeDto kunde in Kunden)
            {
                if (kunde.Id == default(int))
                {
                    Service.AddKunde(kunde);
                }
                else
                {
                    KundeDto original = kundenOriginal.FirstOrDefault(ao => ao.Id == kunde.Id);
                    Service.UpdateKunde(kunde, original);
                }
            }
            Load();
        }

        private bool CanSaveData()
        {
            if (!ServiceExists)
            {
                return false;
            }

            return Validate(Kunden);
        }

        #endregion

        #region New-Command

        private RelayCommand newCommand;
        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                {
                    newCommand = new RelayCommand(
                        param => New(),
                        param => CanNew()
                    );
                }
                return newCommand;
            }
        }

        private void New()
        {
            Kunden.Add(new KundeDto { Geburtsdatum = DateTime.Today });
        }

        private bool CanNew()
        {
            return ServiceExists;
        }

        #endregion

        #region Delete-Command

        private RelayCommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(
                        param => Delete(),
                        param => CanDelete()
                    );
                }
                return deleteCommand;
            }
        }

        private void Delete()
        {
            Service.DeleteKunde(SelectedKunde);
            Load();
        }

        private bool CanDelete()
        {
            return
                SelectedKunde != null &&
                SelectedKunde.Id != default(int) &&
                ServiceExists;
        }

        #endregion
    }
}
