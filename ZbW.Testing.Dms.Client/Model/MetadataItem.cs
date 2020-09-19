using System;

namespace ZbW.Testing.Dms.Client.Model
{
  public class MetadataItem
  {
    private string bezeichnung;
    private DateTime? valutaDatum;
    private string typ;
    private string stichwoerter;
    private string path;

    public string Bezeichnung
    {
      get => bezeichnung;
      set => bezeichnung = value;
    }

    public DateTime? ValutaDatum
    {
      get => valutaDatum;
      set => valutaDatum = value;
    }

    public string Typ
    {
      get => typ;
      set => typ = value;
    }

    public string Stichwoerter
    {
      get => stichwoerter;
      set => stichwoerter = value;
    }
    public string Path
    {
      get => path;
      set => path = value;
    }
  }
}