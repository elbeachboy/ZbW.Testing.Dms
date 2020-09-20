using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.DMS.Client.Test
{
  [TestFixture]
  public class MetaDataItemTest
  {
    [Test]
    public void TestBezeichnung()
    {
      var item = new MetadataItem();
      item.Bezeichnung = "Simon";
      Assert.That(item.Bezeichnung, Is.EqualTo("Simon"));
    }
    [Test]
    public void TestStichworter()
    {
      var item = new MetadataItem();
      item.Stichwoerter = "Simon";
      Assert.That(item.Stichwoerter, Is.EqualTo("Simon"));
    }
    [Test]
    public void TestValutaDatum()
    {
      var item = new MetadataItem();
      item.ValutaDatum = new DateTime(2020,12,12);
      Assert.That(item.ValutaDatum, Is.EqualTo(new DateTime(2020,12,12)));
    }
    [Test]
    public void TestTyp()
    {
      var item = new MetadataItem();
      item.Typ = "Verträge";
      Assert.That(item.Typ, Is.EqualTo("Verträge"));
    }

    [Test]
    public void TestPath()
    {
      var item = new MetadataItem();
      item.Path = "C:\\Temp\\DMS\\2020";
      Assert.That(item.Path, Is.EqualTo("C:\\Temp\\DMS\\2020"));
    }
  }
}
