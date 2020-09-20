using System;
using System.IO;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.DMS.Client.Test
{
  [TestFixture]
  public class DocumentDetailViewModelTest
  {
    private readonly Action navigateBack;
    [Test]
    public void TestSpeichern()
    {
      var docDetailViewModel = new DocumentDetailViewModel("simon", null);
      var m = new MetadataItem();
      m.Stichwoerter = "asdasd";
      m.ValutaDatum = new DateTime(2020,12,12);
      m.Typ = "Verträge";
      docDetailViewModel.M = m;
      docDetailViewModel.Bezeichnung = "Simon";
      docDetailViewModel.ValutaDatum = new DateTime(2020,12,12);
      docDetailViewModel.SelectedTypItem = "Verträge";
      docDetailViewModel.Stichwoerter = "asdasdasd";
      docDetailViewModel.Erfassungsdatum = new DateTime(2020,12,12);
      docDetailViewModel.Benutzer = "Simon";
      docDetailViewModel.FilePath = "C:\\Users\\Simon Scherer\\Desktop\\testSave.pdf";
      docDetailViewModel.Speichern();
      Assert.That(docDetailViewModel.M.Bezeichnung, Is.EqualTo("Simon"));
    }
    [Test]
    public void TestValidieren()
    {
      var docDetailViewModel = new DocumentDetailViewModel("simon", navigateBack);
      docDetailViewModel.Bezeichnung = "Simon";
      Assert.That(docDetailViewModel.Validation(),Is.EqualTo(false));
    }
    [Test]
    public void TestIsFileRemoved()
    {
      var docDetailViewModel = new DocumentDetailViewModel("simon", null);
      docDetailViewModel.Bezeichnung = "Simon";
      docDetailViewModel.ValutaDatum = new DateTime(2020, 12, 12);
      docDetailViewModel.SelectedTypItem = "Verträge";
      docDetailViewModel.Erfassungsdatum = new DateTime(2020, 12, 12);
      docDetailViewModel.Benutzer = "Simon";
      docDetailViewModel.FilePath = "C:\\Users\\Simon Scherer\\Desktop\\testDelete.pdf";
      docDetailViewModel.IsRemoveFileEnabled = true;
      docDetailViewModel.Speichern();
      Assert.That(File.Exists(docDetailViewModel.FilePath), Is.EqualTo(false));
    }
  }
}
