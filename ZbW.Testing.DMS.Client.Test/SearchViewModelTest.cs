using System;
using System.Configuration;
using System.Collections.Generic;
using ZbW.Testing.Dms.Client.ViewModels;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.DMS.Client.Test
{
  [TestFixture]
  public class SearchViewModelTest
  {
    [Test]
    public void TestSuchenMitSuchbegriff()
    {
      var searchViewModel = new SearchViewModel();
      searchViewModel.Suchbegriff = "asd";
      searchViewModel.Suchen();
      Assert.That(searchViewModel.FilteredMetadataItems.Count > 0,Is.EqualTo(true));
    }
    [Test]
    public void TestSuchenMitTyp()
    {
      var searchViewModel = new SearchViewModel();
      searchViewModel.SelectedTypItem = "Verträge";
      searchViewModel.Suchen();
      Assert.That(searchViewModel.FilteredMetadataItems.Count > 0, Is.EqualTo(true));
    }

    [Test]
    public void TestSuchenNichtGefunden()
    {
      var searchViewModel = new SearchViewModel();
      var m = new MetadataItem();
      m.Bezeichnung = "Test";
      m.Typ = "Verträge";
      m.ValutaDatum = new DateTime(2020, 12, 12);
      searchViewModel.SelectedMetadataItem = m;
      searchViewModel.Suchen();
      Assert.That(searchViewModel.FilteredMetadataItems, Is.EqualTo(null));
    }

    [Test]
    public void TestSetList()
    {
      var searchViewModel = new SearchViewModel();
      Assert.That(searchViewModel.FilteredMetadataItems.Count == 2,Is.EqualTo(true));
    }

    [Test]
    public void TestReset()
    {
      var searchViewModel = new SearchViewModel();
      searchViewModel.Reset();
      Assert.That(searchViewModel.FilteredMetadataItems.Count == 0,Is.EqualTo(true));
    }

    [Test]
    public void TestTypItems()
    {
      var searchViewModel = new SearchViewModel();
      Assert.That(searchViewModel.TypItems.Count, Is.EqualTo(2));
    }
  }
}
