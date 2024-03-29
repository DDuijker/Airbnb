﻿using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class EditPropertyViewModel
    {
        public Property SelectedProperty { get; set; }
        public Landlord SelectedLandlord { get; set; }
        public virtual ObservableCollection<Landlord> AllLandlords { get; set; }
        private AirBnbContext Db { get; set; }

        public ICommand SavePropertyCommand { get; set; }


        public EditPropertyViewModel(Property _property, AirBnbContext? _db = null)
        {
            SavePropertyCommand = new RelayCommand(SaveProperty);

            SelectedProperty = _property;
            SelectedLandlord = _property.Landlord;

            if (_db != null)
                Db = _db;
            else
            {
                Db = new();

                Property? prop = Db.Properties.Where(prop => prop.Id == _property.Id).FirstOrDefault();
                if (prop != null)
                {
                    SelectedProperty = prop;
                    SelectedLandlord = prop.Landlord;
                }
            }

            Db.Landlords.Load();
            AllLandlords = Db.Landlords.Local.ToObservableCollection();
        }

        public void SaveProperty()
        {
            Db.SaveChanges();
            OnRequestClose();
        }

        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
