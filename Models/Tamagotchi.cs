using System.Collections.Generic;

namespace Tamagotchi.Models
{
    public class Pet
    {
        private string _name;
        private int _id;
        private int _health;
        private int _age;
        private static List<Pet> _instances = new List<Pet> {};

        public Pet(string name)
        {
            _name = name;
            _instances.Add(this);
            _id = _instances.Count;
            _health = 100;
            _age = 1;
        }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetId()
    {
      return _id;
    }

    public int GetHealth()
    {
      return _health;
    }

    public int GetAge()
    {
      return _age;
    }

    public void Feed()
    {
        _health += 10;
    }

    public void Play()
    {
        _health += 5;
    }

   public void Sleep()
    {
        _health += 10;
    }

    public void PassTime()
    {
        _health -= 20;
        _age += 1;
    }
    
      public static List<Pet> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }

    }
}