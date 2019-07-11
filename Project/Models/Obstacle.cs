using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  class Obstacle : IObstacle
  {
    public string Name { get; set; }
    public string Description { get; set; }



    public Obstacle(string name, string description)
    {
      Name = name;
      Description = description;
    }
  }


}