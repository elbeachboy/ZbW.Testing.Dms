using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Collections.Generic;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;

    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _filteredMetadataItems;

        private MetadataItem _selectedMetadataItem;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public List<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
          if (OnCanCmdOeffnen())
          {
            var item = this.SelectedMetadataItem;
            System.Diagnostics.Process.Start(item.Path);
          }
        }

        private void OnCmdSuchen()
        {
          if (String.IsNullOrEmpty(this.SelectedTypItem) && !String.IsNullOrEmpty(this.Suchbegriff))
          {
            string search = this.Suchbegriff;
            var result = getList().Where(s => s.Bezeichnung == search || s.Stichwoerter == search);
            List<MetadataItem> tempList = new List<MetadataItem>();
            foreach (var s in result)
            {
              tempList.Add(s);
            }

            this.FilteredMetadataItems = tempList;
          }
          else if(!String.IsNullOrEmpty(this.SelectedTypItem) && String.IsNullOrEmpty(this.Suchbegriff))
          {
            string search = this.Suchbegriff;
            var result = getList().Where(s => (s.Typ == this.SelectedTypItem));
            List<MetadataItem> tempList = new List<MetadataItem>();
            foreach (var s in result)
            {
              tempList.Add(s);
            }

            this.FilteredMetadataItems = tempList;
          }
          else
          {
            MessageBox.Show("Bitte Suchkriterien eingeben.", "Kriterien eingeben", MessageBoxButton.OK,
              MessageBoxImage.Information);
          }
        }
        
        private void OnCmdReset()
        {
          List<MetadataItem> list = new List<MetadataItem>();
          this.FilteredMetadataItems = list;
          this.Suchbegriff = "";
          this.SelectedTypItem = null;

        }

        private List<MetadataItem> getList()
        {
          string[] xmlFiles = Directory.GetFiles(ConfigurationManager.AppSettings["RepositoryDir"], "*.xml", SearchOption.AllDirectories);
          var mySerializer = new XmlSerializer(typeof(MetadataItem));
          List<MetadataItem> list = new List<MetadataItem>();
          foreach (var s in xmlFiles)
          {
            var myFileStream = new FileStream(s, FileMode.Open);
            var item = (MetadataItem)mySerializer.Deserialize(myFileStream);
            list.Add(item);
          }

          return list;
        }
  }
}