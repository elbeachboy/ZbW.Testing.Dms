using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.Services
{
  public class FileInteraction
  {
    private string savePath;
    private readonly Guid GUID = System.Guid.NewGuid();

    private string pdfFileName;
    private string metaDataFileName;
    private string year;

    public string PdfFileName
    {
      get => pdfFileName;
      set => pdfFileName = value;
    }

    public string MetaDataFileName
    {
      get => metaDataFileName;
      set => metaDataFileName = value;
    }

    public string Year
    {
      get => year;
      set => year = value;
    }

    public string SavePath
    {
      get => savePath;
      set => savePath = value;
    }

    public FileInteraction(string year)
    {
      this.year = year;
      this.pdfFileName = this.GUID + "_Content.pdf";
      this.metaDataFileName = this.GUID + "_Metadata.xml";
      this.checkDirectory();
      this.buildPath(Path.GetExtension(this.MetaDataFileName));
    }

    public void saveFile(string file)
    {
      this.buildPath(Path.GetExtension(file));
      File.Copy(file, this.SavePath, true);
    }

    public void createMetadataFile(MetadataItem data)
    {
      this.buildPath(Path.GetExtension(this.metaDataFileName));
      XmlSerializer x = new XmlSerializer(data.GetType());
      FileStream fs = File.Create(this.SavePath);
      x.Serialize(fs,data);
    }

    private void buildPath(string extension)
    {
      if (Path.GetExtension(extension) == ".xml")
      {
        this.SavePath = ConfigurationManager.AppSettings["RepositoryDir"] + "\\" + this.Year + "\\" + this.MetaDataFileName;
      } 
      else if (Path.GetExtension(extension) == ".pdf")
      {
        this.SavePath = ConfigurationManager.AppSettings["RepositoryDir"] + "\\" + this.Year + "\\" + this.PdfFileName;
      }
    }

    private void checkDirectory()
    {
      if (!Directory.Exists(ConfigurationManager.AppSettings["RepositoryDir"] + "\\" + this.Year))
      {
        Directory.CreateDirectory(ConfigurationManager.AppSettings["RepositoryDir"] + "\\" + this.Year);
      }
    }

    public void deleteFile(string file)
    {
      File.Delete(file);
    }
  }
}
