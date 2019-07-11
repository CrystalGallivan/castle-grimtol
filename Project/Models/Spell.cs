using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  class Spell : ISpell
  {
    public string Name { get; set; }
    public string Description { get; set; }







    public Spell(string name, string description) : base()
    {
      Name = name;
      Description = description;
    }
  }

}