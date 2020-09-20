using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.DMS.Client.Test
{
  [TestFixture]
  public class FileInteractionTest
  {

    [Test]
    public void TestSaveFile()
    {
      var fileInteraction = new FileInteraction("2020");
      fileInteraction.saveFile("C:\\Users\\Simon Scherer\\Desktop\\testSave.pdf");
      Assert.That(File.Exists(fileInteraction.SavePath), Is.EqualTo(true));
    }
   
    [Test]
    public void TestSavePath()
    {
      var fileInteraction = new FileInteraction("2020");
      Assert.That(fileInteraction.SavePath,Is.EqualTo(ConfigurationManager.AppSettings["RepositoryDir"] + "\\" + fileInteraction.Year + "\\" + fileInteraction.Guid + "_Metadata.xml"));
    }
    [Test]
    public void TestCreateMetadataFile()
    {
      var metadataitem = new MetadataItem();
      metadataitem.Bezeichnung = "Simon";
      metadataitem.Stichwoerter = "Hallo";
      metadataitem.Typ = "Quittungen";
      metadataitem.ValutaDatum = new DateTime(2020,12,12);

      var fileInteraction = new FileInteraction("2020");
      fileInteraction.createMetadataFile(metadataitem);

      Assert.That(File.Exists(fileInteraction.SavePath),Is.EqualTo(true));
    }

    [Test]
    public void TestDeleteFile()
    {
      var fileInteraction = new FileInteraction("2020");
      fileInteraction.deleteFile("C:\\Users\\Simon Scherer\\Desktop\\testDelete.pdf");
      Assert.That(!File.Exists("C:\\Users\\Simon Scherer\\Desktop\\testDelete.pdf"), Is.EqualTo(true));
    }

  }
}
